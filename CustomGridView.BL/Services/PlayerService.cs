using CustomGridView.BL.Services.Interfaces;
using CustomGridView.DAL;
using CustomGridView.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridView.BL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Player player)
        {
            await _unitOfWork.Player.AddByStoredProcedureAsync(player);
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _unitOfWork.Player.GetAllAsync();
        }

        public async Task RemoveAsync(int playerId)
        {
            await _unitOfWork.Player.DeleteByStoredProcedureAsync(playerId);
        }

        public async Task UpdateAsync(Player player)
        {
            await _unitOfWork.Player.UpdateByStoredProcedureAsync(player);
        }

        public async Task<List<vwGetPlayer>> GetPlayersAsync()
        {
            return await _unitOfWork.Player.GetPlayersAsync();
        }

        public async Task<PaginatedPlayerList> GetFilteredPlayers(PlayerFilter playerFilter)
        {
            List<Player> players = await _unitOfWork.Player.FilterPlayersAsync(playerFilter);
            return GetPageItems(players, playerFilter.PageIndex, playerFilter.PageSize);
        }

        private PaginatedPlayerList GetPageItems(List<Player> source, int pageIndex, int pageSize)
        {
            PaginatedPlayerList paginatedPlayerList = new PaginatedPlayerList();
            paginatedPlayerList.Players = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            paginatedPlayerList.Total = source.Count() % pageSize == 0 ? source.Count() / pageSize : (source.Count() / pageSize) + 1;

            return paginatedPlayerList;
        }
    }
}
