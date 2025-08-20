
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
namespace Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IProductRepository _productRepository;

        private IUserRepository _userRepository;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_dbContext);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        public async Task<int> SaveChangeAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
    }
}
