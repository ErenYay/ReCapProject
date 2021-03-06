﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            

            // -- Kiralama Güncelleme --
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Update(new Rental { RentalId = 2, ReturnDate = new DateTime(2021, 02, 15, 12, 12, 12) });
            Console.WriteLine(result.Message);

            // -- Kiralama Ekleme -- Şartlı!
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(new Rental { CarId = 8, CustomerId = 2, RentDate = DateTime.Today });
            //Console.WriteLine(result.Message);

            // -- Araç Ekleme -- Şartlı!
            //CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.Add(new Car { BrandId = 3, CarName = "A5 RS", ColorId = 4, ModelYear = 2018, DailyPrice=435 });
            //Console.WriteLine(result.Message);



        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2}", car.CarName, car.BrandName, car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
