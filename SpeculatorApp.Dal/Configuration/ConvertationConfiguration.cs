using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeculationApp.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Dal.Configuration
{
    public class ConvertationConfiguration : IEntityTypeConfiguration<Convertation>
    {
        public void Configure(EntityTypeBuilder<Convertation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasField("_id")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.BaseCurrencyId)
                .HasColumnName("BaseCurrencyId")
                .HasField("_baseCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.TradeCurrencyId)
                .HasColumnName("TradeCurrencyId")
                .HasField("_tradeCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.BaseCurrencyAmount)
                .HasColumnName("BaseCurrencyAmount")
                .HasField("_baseCurrencyAmount")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.TradeCurrencyAmount)
                .HasColumnName("TradeCurrencyAmount")
                .HasField("_tradeCurrencyAmount")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            //

            builder.HasOne(d => d.Pair)
                .WithMany(p => p.Convertations)
                .HasForeignKey(d => new { d.BaseCurrencyId, d.TradeCurrencyId });
        }
    }
}
