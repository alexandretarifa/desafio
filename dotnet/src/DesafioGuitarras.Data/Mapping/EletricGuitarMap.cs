using DesafioGuitarras.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DesafioGuitarras.Data.Mapping
{
    public class EletricGuitarMap : EntityTypeConfiguration<EletricGuitar>
    {
        public EletricGuitarMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            Property(t => t.Price)
                .IsRequired()
                .HasColumnType("Money");

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(800);

            Property(t => t.InsertDate).IsRequired();

            Property(t => t.ImageUrl)
                .IsOptional()
                .HasMaxLength(8000);

            Property(t => t.Sku)
                .IsOptional()
                .HasMaxLength(500);

            Ignore(t => t.Validation);
        }
    }
}
