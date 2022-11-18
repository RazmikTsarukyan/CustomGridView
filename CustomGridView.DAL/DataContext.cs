using CustomGridView.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CustomGridView.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<vwGetPlayer> VwGetPlayers { get; set; }
    }
}
