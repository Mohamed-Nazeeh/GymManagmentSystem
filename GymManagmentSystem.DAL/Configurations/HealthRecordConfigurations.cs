using GymManagmentSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.DAL.Configurations
{
    public class HealthRecordConfigurations : IEntityTypeConfiguration<HealthRecord>
    {
        void IEntityTypeConfiguration<HealthRecord>.Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.Property(x => x.bloodType)
                .HasMaxLength(5);

            builder.Property(x => x.Note)
                .HasMaxLength(500);


        }
    }
}
