namespace EShop.Service.OrderingInfrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            builder.Property(oi => oi.Quantity).IsRequired();

            builder.Property(oi => oi.Price).IsRequired();
        }
    }
}
