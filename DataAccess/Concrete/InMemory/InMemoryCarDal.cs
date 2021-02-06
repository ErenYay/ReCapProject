using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{CarId=1, BrandId=2, ColorId=2, ModelYear=2017, DailyPrice=260, Description="A180d AMG"},
                new Car{CarId=2, BrandId=1, ColorId=1, ModelYear=2019, DailyPrice=210, Description="1.16i Comfort"},
                new Car{CarId=3, BrandId=3, ColorId=2, ModelYear=2020, DailyPrice=280, Description="A3 Sedan 1.6 TDI"},
                new Car{CarId=4, BrandId=1, ColorId=3, ModelYear=2016, DailyPrice=250, Description="3.20d Techno Plus"},
                new Car{CarId=4, BrandId=2, ColorId=1, ModelYear=2018, DailyPrice=320, Description="C200d BlueTEC AMG"}
            };
        }
        
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Car> GetAllByColor(int ColorId)
        {
            return _cars.Where(c => c.ColorId == ColorId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        void IEntityRepository<Car>.Add(Car entity)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<Car>.Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        List<Car> IEntityRepository<Car>.GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        void IEntityRepository<Car>.Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
