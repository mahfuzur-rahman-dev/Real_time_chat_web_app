using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.ApplicationIdentity.Context;
using ChatAppSignalR.DataAccess.Repositories;
using ChatAppSignalR.Models;
using ChatAppSignalR.Models.IRepositories;
using ChatAppSignalR.Models.Others;

namespace ChatAppSignalR.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationIdentityDbContext _dbContext;
        public UnitOfWork(ApplicationIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = new UserRepository(_dbContext);
            UserConnections = new UserConnectionRepository(_dbContext);
        }

        public IUserRepository Users { get; private set; }
        public IUserConnectionRepository UserConnections { get; private set; }

        public async Task SaveAsync()
        {
            _dbContext.SaveChanges();
        }
    }
}
