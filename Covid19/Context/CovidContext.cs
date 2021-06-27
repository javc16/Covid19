using Covid19.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Context
{
    public class CovidContext : DbContext
    {
        public CovidContext(DbContextOptions<CovidContext> options) : base(options)
        {

        }

        public DbSet<Ciudadano> Ciudadano { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<ControlVacunas> ControlVacunas { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=Covid19;User Id=sa;Password=1234");
        }

    }
}
