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
    public class PairConfiguration : IEntityTypeConfiguration<Pair>
    {
        public void Configure(EntityTypeBuilder<Pair> builder)
        {
            builder.HasKey(e => new { e.BaseCurrencyId, e.TradeCurrencyId });

            builder.Property(e => e.BaseCurrencyId)
                .HasColumnName("BaseCurrencyId")
                .HasField("_baseCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.TradeCurrencyId)
                .HasColumnName("TradeCurrencyId")
                .HasField("_tradeCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.PositionInList)
                .HasColumnName("PositionInList")
                .HasField("_positionInList")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            //

            builder.HasOne(d => d.BaseCurrency)
                .WithMany(p => p.PairsAsBaseCurrency)
                .HasForeignKey(d => d.BaseCurrencyId);

            builder.HasOne(d => d.TradeCurrency)
                .WithMany(p => p.PairsAsTradeCurrency)
                .HasForeignKey(d => d.TradeCurrencyId);
        }
    }
}
