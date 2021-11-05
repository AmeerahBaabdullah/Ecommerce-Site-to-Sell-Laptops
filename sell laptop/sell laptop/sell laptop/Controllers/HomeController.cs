using sell_laptop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace sell_laptop.Controllers
{
    public class HomeController : Controller
    {





        public ActionResult Checkout()
        {
            if (Session["email"] != null)
            {
                string d = Session["email"].ToString();
                dynamic mymodel = new ExpandoObject();
                mymodel.data = Adduser.LoadUser(d);
                mymodel.data2 = Adduser.LoadCart(d);

                List<user> users = new List<user>();
                List<Cart> MyCart = new List<Cart>();
                //List<product> Myproduct = new List<product>();

                foreach (var row in mymodel.data)
                {
                    users.Add(new user
                    {
                        Fname = row.Fname,
                        Lname = row.Lname,
                        address = row.address,
                        city = row.city,
                        country = row.country,
                        phone = row.phone,
                        password = row.password,

                    });
                }
                foreach (var row in mymodel.data2)
                {
                    var desc = Adduser.LoadDProduct(row.lapId);

                    foreach (var rowP in desc)
                    {

                        MyCart.Add(new Cart
                        {
                            lapId = row.lapId,

                            quantity = row.quantity,
                            desc = rowP.name,
                            price = rowP.price
                        });


                    }
                }
                mymodel.data2 = MyCart;
                return View(mymodel);
            }
            else {
                return RedirectToAction("LogIn");

            }
        }

        public ActionResult MyCart()
        {
            if (Session["email"]!=null) { 
            string id = Session["email"].ToString();
            var data = Adduser.LoadCart(id);
            string s=Environment.NewLine;
            List<Cart> Mycart = new List<Cart>();
            
            foreach (var row in data)
            {
                var desc = Adduser.LoadDProduct(row.lapId);
                foreach (var rowP in desc)
                {
                    Mycart.Add(new Cart
                    {

                        lapId = row.lapId,
                        price=rowP.price,
                        quantity = row.quantity,
                        desc = "Name :"+ rowP.name+ "Description:" + rowP.decs  ,


                    });
                }

            }

            return View(Mycart);
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }


        public JsonResult ChangeUser(Cart model)
        {
            // Update model to your db  
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }


       
        public ActionResult Delete(int lapid)
        {


            string id = Session["email"].ToString();
            var data = Adduser.DeleteCart(id,lapid);
            TempData["Message"] = "Delete successfully";

            return RedirectToAction("MyCart");
        }
   
        public ActionResult Edit(int lapid)
        {
            
            string id = Session["email"].ToString();

           int q = Convert.ToInt32(Request["t"].ToString());
            var data = Adduser.EditCart(id,lapid,q);
            TempData["Message"] = "Edit successfully";

            return RedirectToAction("MyCart");
        }

        public ActionResult Order(string lapid)
        {

            string id = Session["email"].ToString();
            var order = Adduser.AddOrder(id,lapid);

          
            TempData["Message"] = " The order is completed ";

            return RedirectToAction("Checkout");
        }

        public ActionResult Product(int id)
        {
            if (Session["email"] != null)
            {
                ViewBag.NameTransfer = id;
                //product y=  repository.Get(id);
                ViewBag.Name = "dddddddddddddddddddddd";
                var data = Adduser.LoadDProduct(id);
                List<product> p = new List<product>();
                foreach (var row in data)
                {
                    p.Add(new product
                    {
                        name = row.name,
                        brand = row.brand,
                        color = row.color,
                        price = row.price,
                        decs = row.decs,
                        stauts = row.stauts,
                        category = row.category,
                        offer = row.offer,
                        pic = row.pic,
                        id = row.id,
                        quantity = row.quantity,
                        SelectedPropertyType = row.SelectedPropertyType


                    });
                }

                return View(p);
            }
            else
            {


                return RedirectToAction("LogIn");
            }
        }


        [HttpPost]

        public ActionResult AddCart(int p,int ch,product pr)
        {
            int q;
          
            if (Session["email"] != null)
            {
                string id = Session["email"].ToString();
                ViewBag.NameTransfer = p;
                ViewBag.NameTransfer = ch;
                bool check = Adduser.checkCart(id, p);
                if (check == true)
                {
                    TempData["Message"] = "Item is already added to your cart";
                    return RedirectToAction("Shop");
                    //return RedirectToAction("product", new { id = p });

                }
                else
                {
                    if (ch == 1)
                    {
                        q = 1;
                        int data = Adduser.Cart(id, p, q);
                        TempData["Message"] = "Item successfully added to your cart";
                        return RedirectToAction("Shop");

                    }
                    else
                    {
                        q = Convert.ToInt32(Request["t"].ToString());
                        //q = Convert.ToInt32("t");
                        int data = Adduser.Cart(id, p, q);
                        TempData["Message"] = "Item successfully added to your cart";

                        return RedirectToAction("Shop");
                    }

                }
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        
        }

        public ActionResult Popup()
        {
            return View();
        }
        [HttpGet]

        public ActionResult Shop()
        {

            
            var data = Adduser.LoadProduct();
            List<product> p = new List<product>();
            foreach (var row in data)
            {
                p.Add(new product
                {

                    name = row.name,
                    brand = row.brand,
                    color = row.color,
                    price = row.price,
                    decs = row.decs,
                    stauts = row.stauts,
                    category = row.category,
                    offer = row.offer,
                    pic = row.pic,
                    id = row.id,
                    quantity = row.quantity
                });
            }

            return View(p);
        }
      

        public ActionResult SingUp()
        {
            ViewBag.Message = "User Sing Up";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SingUp(user model)
        {

            if (ModelState.IsValid)
            {

                int record = Adduser.Addusers(
                    model.Id,
                    model.Fname,
                    model.Lname,
                    model.Email,
                    model.address,
                    model.city,
                    model.country,
                    model.phone,
                    model.password);
                Session["email"] = model.Email;

                return RedirectToAction("index");
            }
            return View();
        }




        public ActionResult LogIn()

        {

            if (Session["email"] != null)
            {

                return RedirectToAction("Index", "Home", new { email = Session["email"].ToString() });

            }
            else
            {

                return View();


            }


        }
        [HttpPost]

        public ActionResult LogIn(user model)

        {
            ViewBag.Name = "f";

            ViewBag.Name = "b";

            bool v = Adduser.LoginUser(
                model.Email, model.password);

            
            if (v == true)
            {
                Session["email"] = model.Email;

                return RedirectToAction("Index","Home", new { email = model.Email});

            }
            else
            {
                ///    ViewBag.error = "Invalid Account";
                ViewBag.Name = "nienter";
                ///    
                //  return RedirectToAction("SingUp");



            }


            return View();
        }


        public ActionResult Viewuser()
        {
            if (Session["email"] != null) { 
           string d = Session["email"].ToString();
            ViewBag.Message = "userbnmk,l.;lkjnhbvc." + d;
            
            var data = Adduser.LoadUser(d);
            List<user> users = new List<user>();
            foreach (var row in data)
            {
                users.Add(new user
                {
                    Fname = row.Fname,
                    Lname = row.Lname,
                    Email = row.Email,
                    address = row.address,
                    city=row.city,
                    country=row.country,
                    phone = row.phone,
                    password = row.password,




                });
            }

            return View(users);
            }
            else {

                return RedirectToAction("LogIn");

            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Laptop()
        {
            ViewBag.Message = "Display Laptop.";

            return View();
        }



        public ActionResult Index(string email)
        {

                        var data = Adduser.LoadProduct();
                List<product> p = new List<product>();
                foreach (var row in data)
                {
                    p.Add(new product
                    {

                        name = row.name,
                        brand = row.brand,
                        color = row.color,
                        price = row.price,
                        decs = row.decs,
                        stauts = row.stauts,
                        category = row.category,
                        offer = row.offer,
                        pic = row.pic,
                        id = row.id,
                        quantity = row.quantity
                    });
                }

                return View(p);
            }


       
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }
    } }