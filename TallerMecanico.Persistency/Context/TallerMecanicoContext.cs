using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Models.Models;

namespace TallerMecanico.Persistence.Context
{
    public class TallerMecanicoContext : DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Automovil> Automoviles { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }
        public DbSet<Desperfecto> Desperfectos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<DesperfectoRepuesto> DesperfectoRepuestos { get; set; }

        public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>().UseTptMappingStrategy();
            
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculos");
            modelBuilder.Entity<Automovil>().ToTable("Automoviles");
            modelBuilder.Entity<Moto>().ToTable("Motos");


            modelBuilder.Entity<DesperfectoRepuesto>()
                .HasKey(dr => new { dr.DesperfectoId, dr.RepuestoId });

            modelBuilder.Entity<DesperfectoRepuesto>()
                .HasOne(dr => dr.Desperfecto)
                .WithMany(d => d.DesperfectoRepuestos)
                .HasForeignKey(dr => dr.DesperfectoId)
                .OnDelete(DeleteBehavior.Cascade);//cambio reciente

            modelBuilder.Entity<DesperfectoRepuesto>()
                .HasOne(dr => dr.Repuesto)
                .WithMany(r => r.DesperfectoRepuestos)
                .HasForeignKey(dr => dr.RepuestoId)
                .OnDelete(DeleteBehavior.Cascade);//cambio reciente

            modelBuilder.Entity<Presupuesto>()
                 .Property(p => p.Total)
                 .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Precio)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Desperfecto>()
                .Property(r => r.ManoDeObra)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Presupuesto>()
                .HasOne(p => p.Vehiculo)
                .WithOne()
                .HasForeignKey<Presupuesto>(p => p.IdVehiculo)
                .OnDelete(DeleteBehavior.Cascade); //cambio reciente

            modelBuilder.Entity<Presupuesto>()
                .HasMany(p => p.Desperfectos)
                .WithOne(d => d.Presupuesto)
                .HasForeignKey(p => p.IdPresupuesto)
                .OnDelete(DeleteBehavior.Cascade);//cambio reciente

        }

    }
}
