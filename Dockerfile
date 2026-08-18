# Usa l'immagine ufficiale Microsoft con .NET SDK 8.
# Lo SDK serve per compilare, ripristinare i pacchetti NuGet
# e pubblicare l'applicazione.
# "AS build" assegna il nome "build" a questa fase.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Imposta /src come cartella di lavoro all'interno
# dell'immagine Docker.
# I comandi successivi verranno eseguiti da questa directory.
WORKDIR /src

# Copia nella cartella /src tutti i file .csproj
# presenti nella cartella da cui viene eseguito docker build.
#
# Viene copiato prima solo il .csproj per permettere a Docker
# di sfruttare meglio la cache del restore NuGet.
COPY *.csproj .

# Pulisce tutte le cache NuGet
RUN dotnet nuget locals all --clear

# Ripristina tutti i pacchetti NuGet richiesti dal progetto.
RUN dotnet restore --force

# Copia tutto il resto del codice sorgente nella cartella /src.
COPY . .

# Compila e pubblica l'applicazione in configurazione Release.
#
# -c Release = compilazione ottimizzata per produzione
# -o /app/publish = mette i file pubblicati in /app/publish
RUN dotnet publish \
	-c Release \
	-o /app/publish \
	--no-restore

# ------------------------------
# SECONDA FASE: RUNTIME
# ------------------------------

# Crea una nuova immagine partendo dal runtime ASP.NET Core 8.
#
# Qui NON utilizziamo più l'SDK completo perché non dobbiamo
# compilare il programma: dobbiamo solamente eseguirlo.
#
# Questo permette di ottenere un'immagine finale più piccola.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Imposta /app come cartella di lavoro del container finale.
WORKDIR /app

# Copia nella nuova immagine solamente il risultato della
# pubblicazione effettuata nella fase "build".
#
# Non vengono quindi copiati SDK, sorgenti e file temporanei
# utilizzati durante la compilazione.
COPY --from=build /app/publish .

# Documenta che il container utilizza la porta 8080.
#
# EXPOSE da solo non pubblica la porta verso il PC:
# per esempio con docker run servirà comunque:
#
# docker run -p 8080:8080 ...
EXPOSE 8080

# Configura ASP.NET Core affinché ascolti sulla porta 8080
# su tutte le interfacce di rete del container.
#
# Il simbolo + significa sostanzialmente "qualsiasi host".
ENV ASPNETCORE_URLS=http://+:8080

# Definisce il comando che viene eseguito quando
# il container viene avviato.
#
# Equivale a:
#
# dotnet ListaSpesa_BackEnd.dll
ENTRYPOINT ["dotnet", "ListaSpesa_BackEnd.dll"]