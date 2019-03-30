﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.SqlServer.Repositories
{
    internal class GameRentalsRepository : IGameRentalsRepository
    {
        private readonly BoardGameRentalMsSqlContext _msSqlContext;

        public GameRentalsRepository(BoardGameRentalMsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }

        public void Add(GameRental entity)
        {
            _msSqlContext.GameRentals.Add(entity);
        }

        public async Task AddAsync(GameRental entity)
        {
            await _msSqlContext.GameRentals.AddAsync(entity);
        }

        public void Remove(GameRental entity)
        {
            _msSqlContext.GameRentals.Remove(entity);
        }

        public GameRental Get(int? id)
        {
            return _msSqlContext.GameRentals.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameRental> GetAll()
        {
            return _msSqlContext.GameRentals.Include(x => x.BoardGame).Include(x => x.Client).ToList();
        }

        public void Update(GameRental entity)
        {
            _msSqlContext.GameRentals.Update(entity);
        }
    }
}