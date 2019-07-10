﻿using System.Collections.Generic;
using MongoDB.Driver;
using Rentals.Api.Configuration;
using Rentals.Api.DataAccess.Entities;

namespace Rentals.Api.DataAccess
{
    public interface IRentalsRepository
    {
        IList<Rental> GetAll();
        Rental Get(string id);
        Rental Create(Rental rental);
    }

    public class RentalsRepository : IRentalsRepository
    {
        private readonly IMongoCollection<Rental> _rentals;

        public RentalsRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _rentals = database.GetCollection<Rental>(settings.BooksCollectionName);
        }

        public IList<Rental> GetAll()
        {
            return _rentals.Find(rental => true).ToList();
        }

        public Rental Create(Rental rental)
        {
            _rentals.InsertOne(rental);
            return rental;
        }

        public Rental Get(string id)
        {
            return _rentals.Find(rental => rental.Id == id).FirstOrDefault();
        }

        public void Update(string id, Rental bookIn)
        {
            _rentals.ReplaceOne(rental => rental.Id == id, bookIn);
        }

        public void Remove(Rental bookIn)
        {
            _rentals.DeleteOne(rental => rental.Id == bookIn.Id);
        }

        public void Remove(string id)
        {
            _rentals.DeleteOne(rental => rental.Id == id);
        }
    }
}