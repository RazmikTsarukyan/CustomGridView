using CustomGridView.BL.Services.Interfaces;
using CustomGridView.Entities;
using CustomGridView.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomGridView.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerService _playerService;
        public HomeController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetPlayers", new { pageIndex = 1, pageSize = 4 });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetPlayers(int pageIndex, int pageSize, string firstname = null, string lastname = null, byte? age = null, int? statusId = null, string orderColumn = null)
        {
            PaginatedPlayerList paginatedPlayerList = await _playerService.GetFilteredPlayers(new PlayerFilter 
            {
                PageIndex = pageIndex, PageSize = pageSize, 
                FirstName =  firstname,
                LastName = lastname,
                Age = age,
                StatusId = statusId,
                OrderColumn = orderColumn
            });

            ViewBag.PagesCount = paginatedPlayerList.Total;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            return View("Index", paginatedPlayerList);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(AddPlayerModel addPlayerModel)
        {
            try
            {
                string fileName = await GetFileName(addPlayerModel.Image);

                Player player = new Player()
                {
                    FirstName = addPlayerModel.FirstName,
                    LastName = addPlayerModel.LastName,
                    Age = addPlayerModel.Age,
                    StatusId = addPlayerModel.StatusId,
                    Img = "/img/" + fileName
                };

                await _playerService.AddAsync(player);
            }
            catch (Exception ex)
            {
                BadRequest(new ResponseModel { Success = false, Error = ex.Message });
            }

            return Ok(new ResponseModel { Success = true, Error = string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerModel updatePlayerModel)
        {
            try
            {
                var fileName = await GetFileName(updatePlayerModel.Image);

                Player player = new Player()
                {
                    Id = updatePlayerModel.Id,
                    FirstName = updatePlayerModel.FirstName,
                    LastName = updatePlayerModel.LastName,
                    Age = updatePlayerModel.Age,
                    StatusId = updatePlayerModel.StatusId,
                    Img = "/img/" + fileName
                };

                await _playerService.UpdateAsync(player);
            }
            catch (Exception ex)
            {
                BadRequest(new ResponseModel { Success = false, Error = ex.Message });
            }

            return Ok(new ResponseModel { Success = true, Error = string.Empty });
        }


        [HttpPost]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                await _playerService.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                BadRequest(new ResponseModel { Success = false, Error = ex.Message });
            }

            return Ok(new ResponseModel { Success = true , Error = string.Empty});
        }

        private async Task<string> GetFileName(IFormFile formFile)
        {
            var fileName = Path.GetFileName(formFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}

