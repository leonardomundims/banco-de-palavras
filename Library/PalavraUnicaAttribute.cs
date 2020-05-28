using BancoDePalavras.Database;
using BancoDePalavras.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDePalavras.Library.Validation {
    public class PalavraUnicaAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var palavra = validationContext.ObjectInstance as Palavra;

            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext)); //cria uma conexão com o banco de dados

            //vrifica se já existe uma palavra com o mesmo nome e id diferente
            var palavraBanco = _db.Palavras.Where(p => p.Nome == palavra.Nome && p.Id != palavra.Id).FirstOrDefault();

            //se o nome for igual e o id também significa que estou alterando a palavra portanto =>
            if (palavraBanco == null) {
                return ValidationResult.Success;
            } else {
                // se a o nome for igual mas o id diferente significa que estou tentando cadastrar uma palavra que já existe, portanto =>
                return new ValidationResult("A palavra '" + palavra.Nome + "' já existe no banco!");
            }
        }
    }
}