using GymManagmentSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.DAL.Configurations
{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("Varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnType("Varchar")
                .HasMaxLength (100);

            builder.OwnsOne(x =>x.Address, Address =>
            {
                Address.Property(x => x.Street)
                       .HasColumnType("Varchar")
                       .HasMaxLength(30);

                Address.Property(x => x.City)
                       .HasColumnType("Varchar")
                       .HasMaxLength(30);
            });

            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("GymUser_EmailCheck", "Email LIKE '_%@_%._%'");
                t.HasCheckConstraint("GymUser_PhoneCheck", "[Phone] LIKE '010%' OR [Phone] LIKE '011%' OR [Phone] LIKE '012%' OR [Phone] LIKE '015%'");
            });
            

             
        }
    }
}
