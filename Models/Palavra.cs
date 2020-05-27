namespace BancoDePalavras.Models
{
    public class Palavra
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Nivel { get; set; }
    }

    public class Nivel
    {
        public int Id { get; set; }
        public string Valor { get; set; }
    }
}