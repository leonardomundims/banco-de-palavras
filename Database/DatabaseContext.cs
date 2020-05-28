using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;
using BancoDePalavras.Models;
using System.Data.Sql;


namespace BancoDePalavras.Database

{
    public class DatabaseContext : DbContext
    {

        //criar propiedade a ser armazenada no banco de dados
        public DbSet<Palavra> Palavras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Database\\BancoDePalavras.db");
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

            //EF entity framework
            Database.EnsureCreated(); //assegura que o banco de dados sera criado caso não exista
        }


    }
}