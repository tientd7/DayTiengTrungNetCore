using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanTri.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IAccountManager _account;
        public UsersController(IAccountManager account)
        {
            _account = account;
        }
        // GET: Users
        public ActionResult Index()
        {
            var rst = _account.GetAll(null, null);
            return View(rst);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            var rst = _account.GetByUserName(id);
            return View(rst);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterDto register)
        {
            try
            {
                // TODO: Add insert logic here
                string message = _account.CreateUser(register);
                if (string.IsNullOrEmpty(message))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrMsg = message;
                    return View(register);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrMsg = ex.Message;
                return View(register);
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            var rst = _account.GetByUserName(id);
            return View(rst);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDto user)
        {
            try
            {
                // TODO: Add update logic here
                string msg = _account.UpdateUser(user);
                if (string.IsNullOrEmpty(msg))
                    return RedirectToAction(nameof(Index));
                ViewBag.ErrMsg = msg;
                return View(user);
            }
            catch(Exception ex)
            {
                ViewBag.ErrMsg = ex.Message;
                return View(user);
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete()//int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}