using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeculationApp.Dal.Entities;

namespace SpeculationApp.Dal.Configuration
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasField("_id")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasField("_name")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired();

            builder.Property(e => e.IsIncrease)
                .HasColumnName("IsIncrease")
                .HasField("_isIncrease")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
