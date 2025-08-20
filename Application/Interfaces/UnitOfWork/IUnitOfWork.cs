using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repository;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {

        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangeAsync();
    }
}
