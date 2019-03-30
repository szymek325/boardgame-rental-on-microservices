﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameRentalApp.Core.Entities;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqLite.Context;

namespace BoardGameRentalApp.DataAccess.SqLite.Repositories
{
    internal class BoardGamesRepository : IBoardGamesRepository
    {
        private readonly BoardGameRentalSqLiteContext _sqLiteContext;

        public BoardGamesRepository(BoardGameRentalSqLiteContext sqLiteContext)
        {
            _sqLiteContext = sqLiteContext;
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _sqLiteContext.BoardGames.ToList();
        }

        public BoardGame Get(int? id)
        {
            return _sqLiteContext.BoardGames.FirstOrDefault(x => x.Id == id);
        }

        public void Add(BoardGame entity)
        {
            _sqLiteContext.BoardGames.Add(entity);
        }

        public async Task AddAsync(BoardGame entity)
        {
            await _sqLiteContext.BoardGames.AddAsync(entity);
        }

        public void Remove(BoardGame entity)
        {
            _sqLiteContext.BoardGames.Remove(entity);
        }

        public void Update(BoardGame entity)
        {
            _sqLiteContext.BoardGames.Update(entity);
        }
    }
}