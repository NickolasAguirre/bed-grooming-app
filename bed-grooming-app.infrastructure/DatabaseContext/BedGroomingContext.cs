using bed_grooming_app.domain.Entities;
using bed_grooming_app.domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bed_grooming_app.repository.DatabaseContext
{
    public class BedGroomingContext: DbContext
    {
        public BedGroomingContext(DbContextOptions<BedGroomingContext> options) : base(options){ }

        public DbSet<AppointmentModel> Appointment{ get; set; }
        public DbSet<PetModel> Bed { get; set; }
        public DbSet<ClientPetModel> ClientBed { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<MasterStateModel> MasterState { get; set; }
        public DbSet<OptionMenuModel> OptionMenu { get; set; }
        public DbSet<OptionMenuPerfilModel> OptionMenuPerfil { get; set; }
        public DbSet<PerfilModel> Perfil { get; set; }
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<ServiceModel> Service { get; set; }
        public DbSet<StateModel> State { get; set; }
        public DbSet<UserModel> User { get; set; }


    }
}
