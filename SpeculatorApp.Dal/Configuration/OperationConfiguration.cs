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
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasField("_id")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.OperationTypeId)
                .HasColumnName("OperationTypeId")
                .HasField("_operationTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.CurrencyId)
                .HasColumnName("CurrencyId")
                .HasField("_currencyId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.Amount)
                .HasColumnName("Amount")
                .HasField("_amount")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.Date)
                .HasColumnName("Date")
                .HasField("_date")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            //

            builder.HasOne(d => d.OperationType)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.OperationTypeId);

            builder.HasOne(d => d.Currency)
                .WithMany(p => p.Operations)
                .HasForeignKey(d => d.CurrencyId);
        }
    }
}
