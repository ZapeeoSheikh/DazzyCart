﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DazzyCart.Models;

namespace DazzyCart.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DazzyCartContext db = new DazzyCartContext();
        [HttpGet]
        public ActionResult Index()
        {
            List<Products> products = db.products.ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult Index(Products products, HttpPostedFileBase file)
        {
            String domain = "http://zapeeosheikh-001-site1.btempurl.com/";
            string filename = DateTime.UtcNow.Ticks + ".jpg";
            file.SaveAs(Server.MapPath("~/dbImage/") + filename);
            //file.SaveAs(Server.MapPath("~/dbImage/") + filename);
            //file.SaveAs("h:\\root\\home\\zapeeosheikh-001\\www\\DazzyCart\\dbImage\\" + filename);
            products.Image = filename;
            db.products.Add(products);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
        public ActionResult ProductDetails(int Id)
        {
            Products products = db.products.FirstOrDefault(o => o.Id == Id);
            return View(products);
        }
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(User user)
        {
            User dbuser = db.user.Where(m => m.Email == user.Email && m.Password == user.Password).FirstOrDefault();
            if (dbuser == null)
            {
                ViewBag.Error = "Your email or password is incorrect";
                return View();
            }
            FormsAuthentication.SetAuthCookie(user.Email, false);
            HttpCookie mycookie = new HttpCookie("userCookie");
            mycookie.Value = dbuser.AccessToken;
            mycookie.Expires = DateTime.UtcNow.AddDays(5).AddHours(5);
            Response.Cookies.Remove("userCookie");
            Response.Cookies.Add(mycookie);
            return Redirect("/Home/Form");
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            ViewBag.Users = db.user.ToList();

            //user.RoleId = 2;
            user.AccessToken = DateTime.UtcNow.Ticks.ToString();
            db.user.Add(user);
            db.SaveChanges();

            HttpCookie myCookie = new HttpCookie("userCookie");
            myCookie.Value = user.AccessToken;
            myCookie.Expires = DateTime.UtcNow.AddDays(5).AddHours(5);
            Response.Cookies.Remove("userCookie");
            Response.Cookies.Add(myCookie);
            return Redirect("/Home/Login");
        }
        //[HttpGet]
        //public ActionResult Form()
        //{
        //    List<Products> product = db.products.ToList();
        //    return View(product);
        //}
        //[HttpPost]
        [Authorize]
        public ActionResult Form(User user)
        {
            //string filename = DateTime.UtcNow.Ticks + ".jpg";
            //file.SaveAs(Server.MapPath("~/dbImage/") + filename);
            //product.Image = filename;
            //db.products.Add(product);
            //db.SaveChanges();

            //User dbuser = db.user.Where(m => m.Email == user.Email && m.Password == user.Password).FirstOrDefault();
            //if (dbuser != null)
            //{
            return View();
            //}
            //return Redirect("/Home/Index");

        }

    }
}
