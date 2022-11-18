using CustomGridView.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.DAL.Repository.PlayerRepository
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        Task<List<vwGetPlayer>> GetPlayersAsync();
        Task AddByStoredProcedureAsync(Player player);
        Task UpdateByStoredProcedureAsync(Player player);
        Task DeleteByStoredProcedureAsync(int playerId);
        Task<List<Player>> FilterPlayersAsync(PlayerFilter playerFilter);
    }
}
