using GameAm.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;

namespace GameAm.Database.Configuration
{
    public class WebPointConfiguration : IEntityTypeConfiguration<WebPoint>
    {
        public void Configure(EntityTypeBuilder<WebPoint> builder)
        {
            builder.HasOne<Game>(wp => wp.Game)
            .WithMany(g => g.WebPoints)
            .HasForeignKey(wp => wp.GameId);
        }
    }
}
