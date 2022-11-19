using CustomGridView.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CustomGridView.DAL.Repository.PlayerRepository
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task AddByStoredProcedureAsync(Player player)
        {
            await DataContext.Players.FromSqlRaw("EXECUTE dbo.InsertPlayer {0}, {1}, {2}, {3}, {4}", player.FirstName, player.LastName, player.Age, player.StatusId, player.Img).ToListAsync();
        }

        public async Task UpdateByStoredProcedureAsync(Player player)
        {
            await DataContext.Players.FromSqlRaw("EXECUTE dbo.UpdatePlayer {0}, {1}, {2}, {3}, {4}, {5}", player.Id, player.FirstName, player.LastName, player.Age, player.StatusId, player.Img).ToListAsync();
        }

        public async Task DeleteByStoredProcedureAsync(int playerId)
        {
            await DataContext.Players.FromSqlRaw("EXECUTE dbo.DeletePlayer {0}", playerId).ToListAsync();
        }

        public async Task<List<vwGetPlayer>> GetPlayersAsync()
        {
            return await DataContext.VwGetPlayers.ToListAsync();
        }

        public async Task<List<Player>> FilterPlayersAsync(PlayerFilter playerFilter)
        {
            var result = await DataContext.Players.FromSqlRaw("EXECUTE dbo.FilterPlayers {0}, {1}, {2}, {3}, {4}", playerFilter.FirstName, playerFilter.LastName, playerFilter.Age.HasValue ? playerFilter.Age.Value : null, playerFilter.StatusId.HasValue ? playerFilter.StatusId.Value : null, playerFilter.OrderColumn).ToListAsync();

            return result;
        }
    }
}
