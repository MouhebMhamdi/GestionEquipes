using GE.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GE.Data.MyConfiguration
{
    public class TropheeConfiguration :IEntityTypeConfiguration<Trophee>
    {
        public void Configure(EntityTypeBuilder<Trophee> builder)
        {
            builder.HasOne(t => t.Equipe)
                .WithMany(e => e.Trophees)
                .HasForeignKey(t => t.EquipeFk);
        }

    }
}
