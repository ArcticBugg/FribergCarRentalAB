using System.Collections.Generic;
using FribergCarRentalAB.Models;

namespace FribergCarRentalAB.Data.Repositories
{
    //Interface som definierar metoder för att hantera bil-data.
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
