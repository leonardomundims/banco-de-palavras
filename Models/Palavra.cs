using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using BancoDePalavras.Library.Validation;


namespace BancoDePalavras.Models
{   
    public class Palavra
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Palavra' é obrigatório")]
        [PalavraUnica]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Nivel' é obrigatório")]
        public int Nivel { get; set; }
    }

    public class Nivel
    {
        public int Id { get; set; }
        public string Valor { get; set; }

        public Nivel(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public Nivel() { }
    }
}