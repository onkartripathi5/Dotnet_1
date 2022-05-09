using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdxUsers.Models;
using System;
using System.Collections.Generic;

namespace PdxUsers.Controllers
{
    public class UserController : Controller
    {

        UserDataAccessLayer userDataAccessLayer = null;
        public UserController()
        {
            userDataAccessLayer = new UserDataAccessLayer();
        }
        // GET: userController
        public ActionResult Index()
        {
            IEnumerable<User> users = userDataAccessLayer.GetAllUser();
            return View(users);
        }

        // GET: userController/Details/5
        public ActionResult Details(int id)
        {
            User user = userDataAccessLayer.GetUserData(id);
            return View(user);
        }

        // GET: userController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here  
                userDataAccessLayer.AddUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: userController/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userDataAccessLayer.GetUserData(id);
            return View(user);
        }

        // POST: userController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here  
                userDataAccessLayer.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: userController/Delete/5
        public ActionResult Delete(int id)
        {
            User user = userDataAccessLayer.GetUserData(id);
            return View(user);
        }

        // POST: userController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                // TODO: Add delete logic here  
                userDataAccessLayer.DeleteUser(user.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
