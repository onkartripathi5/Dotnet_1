using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentM.Models;
using System;
using System.Collections.Generic;

namespace StudentM.Controllers
{
    public class CarController : Controller


    {
        CarDataAccessLayer carDataAccessLayer = null;
        public CarController()
        {
            carDataAccessLayer = new CarDataAccessLayer();
        }
        // GET: CarController
        public ActionResult Index()
        {
            IEnumerable<Car> cars = carDataAccessLayer.GetAllCar();
            return View(cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            Car car = carDataAccessLayer.GetCarData(id);
            return View(car);
        }
        //shdewyfywefyewvfeff

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                // TODO: Add insert logic here  
                carDataAccessLayer.AddCar(car);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = carDataAccessLayer.GetCarData(id);
            return View(car);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            try
            {
                // TODO: Add update logic here  
               carDataAccessLayer.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            Car car = carDataAccessLayer.GetCarData(id);
            return View(car);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Car car)
        {
            try
            {
                // TODO: Add delete logic here  
                carDataAccessLayer.DeleteCar(car.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
