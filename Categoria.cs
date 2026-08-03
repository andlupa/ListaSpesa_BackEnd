using System.ComponentModel.DataAnnotations;

namespace ListaSpesa_BackEnd
{
    public class Categoria
    {
        [Key] 
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; } = string.Empty;
    }
}