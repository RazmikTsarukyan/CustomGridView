using CustomGridView.DAL.Repository.PlayerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext DataContext;
        public UnitOfWork(DataContext context)
        {
            DataContext = context;
            Player = new PlayerRepository(context);
        }

        public IPlayerRepository Player { get; private set; }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
