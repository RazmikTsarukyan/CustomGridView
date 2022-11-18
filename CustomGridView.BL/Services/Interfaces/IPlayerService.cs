using CustomGridView.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.BL.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllAsync();
        Task AddAsync(Player player);
        Task UpdateAsync(Player player);
        Task RemoveAsync(int playerId);
        Task<List<vwGetPlayer>> GetPlayersAsync();
        Task<PaginatedPlayerList> GetFilteredPlayers(PlayerFilter playerFilter);
    }
}
