using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Context;



namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>,IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context): base(context) {
        
            _context = context;
        }
    }
}
