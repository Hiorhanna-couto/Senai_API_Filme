﻿using api_filmes_senai.Domains;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Context
{
    public class Filme_Context : DbContext
    {
        public Filme_Context() 
        { 
        
        }


        public Filme_Context(DbContextOptions<Filme_Context> options): base(options)
        {
        }

        /// <summary>
        /// Define que as classes se transforma em tabeles na bd
        /// 
        /// Id Usar = sa; Pwd = Senai@134
        /// </summary>

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public object Generos { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            { 
            optionsBuilder.UseSqlServer("Server=NOTE18-S28\\SQLEXPRESS; Database = filme_senai; user id=sa; pwd=Senai@134; TrustServerCertificate = true;");
            
            }
            
        }

    }

}
