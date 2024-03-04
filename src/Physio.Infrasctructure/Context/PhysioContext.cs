using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Physio.Domain;
using Physio.Domain.Entities;
using Physio.Infrasctructure.Context.EntitiesConfiguration;
using Physio.Infrastructure.Context.EntitiesConfiguration;

namespace Physio.Infrasctructure.Context;

internal class PhysioContext : IdentityDbContext<UserEntity>
{
    public DbSet<PatientEntity> Patients { get; set; }
    public DbSet<ProtocolEntity> Protocols { get; set; }
    public DbSet<ProfessionalEntity> Professionals { get; set; }
    public DbSet<SchedulingEntity> Schedulings { get; set; }
    public DbSet<MedicalAppointmentEntity> MedicalAppointments { get; set; }
    public DbSet<StatusSchedulingEntity> SchedulingStatuses { get; set; }
    public DbSet<SchedulingTypeEntity> SchedulingTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<ClinicProfessionalEntity> ProfessionalClinics { get; set; }
    public DbSet<ClinicPatientEntity> ClinicPatients { get; set; }
    public DbSet<ClinicSchedulingEntity> ClinicSchedulings { get; set; }
    public DbSet<ProfessionalPatientEntity> ProfessionalPatients { get; set; }
    public DbSet<ProfessionalSchedulingEntity> ProfessionalSchedulings { get; set; }

    public DbSet<ClinicEntity> Clinics { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }

    public PhysioContext(DbContextOptions<PhysioContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<AddressEntity>());
        new ContactEntityTypeConfiguration().Configure(modelBuilder.Entity<ContactEntity>());

        new ClinicEntityTypeConfiguration().Configure(modelBuilder.Entity<ClinicEntity>());
        new ClinicPatientEntityTypeConfiguration().Configure(modelBuilder.Entity<ClinicPatientEntity>());
        new ProfessionalPatientEntityTypeConfiguration().Configure(modelBuilder.Entity<ProfessionalPatientEntity>());
        new ClinicProfessionalEntityTypeConfiguration().Configure(modelBuilder.Entity<ClinicProfessionalEntity>());

        new MedicalAppointmentEntityTypeConfiguration().Configure(modelBuilder.Entity<MedicalAppointmentEntity>());

        new PatientEntityTypeConfiguration().Configure(modelBuilder.Entity<PatientEntity>());
        new ProtocolEntityTypeConfiguration().Configure(modelBuilder.Entity<ProtocolEntity>());
        new ProfessionalEntityTypeConfiguration().Configure(modelBuilder.Entity<ProfessionalEntity>());
        
        new SchedulingEntityTypeConfiguration().Configure(modelBuilder.Entity<SchedulingEntity>());

        new StatusSchedulingEntityTypeConfiguration().Configure(modelBuilder.Entity<StatusSchedulingEntity>());
        new SchedulingTypeEntityTypeConfiguration().Configure(modelBuilder.Entity<SchedulingTypeEntity>());


        var clinicRole = new RoleEntity { Id= "ca29a123-1a4b-4d75-84eb-6f39dd886f70", Name = "Clinic", NormalizedName = "CLINIC" };
        var patientRole = new RoleEntity { Id = "5f75bc70-66e9-4360-a5f5-60cd4d60dbee", Name = "Patient", NormalizedName = "PATIENT" };
        var professionalRole = new RoleEntity { Id = "645eb3bb-ab2a-4542-a3e1-8bd8ef945bda", Name = "Professional", NormalizedName = "PROFESSIONAL" };

        modelBuilder.Entity<RoleEntity>().HasData(clinicRole, patientRole, professionalRole);


        modelBuilder.Entity<StatusSchedulingEntity>().HasData(
            new StatusSchedulingEntity { Id = Guid.Parse("016f13e5-e543-49f4-891d-ac2567ebf190"), Name = "Cancelado", CreatedOn = DateTime.UtcNow, Status = StatusSchedulingEnum.Cancelado },
            new StatusSchedulingEntity { Id = Guid.Parse("d3c26666-1e31-460e-ba5f-4310735358c9"), Name = "Finalizado", CreatedOn = DateTime.UtcNow, Status = StatusSchedulingEnum.Finalizado },
            new StatusSchedulingEntity { Id = Guid.Parse("267e1ac0-05db-4cd2-9cb3-a9f262aadde1"), Name = "Remarcado", CreatedOn = DateTime.UtcNow, Status = StatusSchedulingEnum.Remarcado },
            new StatusSchedulingEntity { Id = Guid.Parse("e0c50144-28e6-480a-b414-7ccb8c77aafe"), Name = "Agendado", CreatedOn = DateTime.UtcNow, Status = StatusSchedulingEnum.Agendado }
        );
    }
}
