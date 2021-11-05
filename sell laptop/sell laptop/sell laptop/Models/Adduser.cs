using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sell_laptop.Models
{
    public class Adduser
    {
        public static int Addusers(int id,string fname, string lname, string email, string add,string city,string country, int phone, string pass)
        {

            user data = new user
            {
                Id=id,
                Fname = fname,
                Lname = lname,
                Email = email,
                address = add,
                city=city,
                country=country,
                phone = phone,
                password = pass


            };

            string sql = @"insert into dbo.users (Fname,Lname,email,address,city,country,phone,password)
        values(@Fname,@Lname,@Email,@address,@city,@country,@phone,@password);";
            return SqlDataAccess.SaveData(sql, data);

        }

        public static int Cart (string email,int lapId, int q)
        {

            Cart data = new Cart
            {
                email=email,
                lapId= lapId,
                quantity=q

            };

            string sql = @"insert into dbo.cart (userid,lapid,quantity)
        values(@email,@lapId,@quantity);";
            return SqlDataAccess.SaveData(sql, data);

        }

        public static int AddOrder(string email, string details)
        {

            Order data = new Order
            {
               
                email = email,
                details= details

            };

            string sql = @"insert into dbo.setOrder (userid,details)
        values(@email,@details);";
            return SqlDataAccess.SaveData(sql, data);

        }
        public static int DeleteCart(string email, int lapId)
        {

            Cart data = new Cart
            {
                email = email,
                lapId = lapId,
               

            };

            string sql = @"delete from dbo.cart where userId='" + email + "'  and lapId ='" + lapId + "' ;";
            return SqlDataAccess.SaveData(sql, data);

        }
        public static int EditCart(string email, int lapId,int quantity)
        {

            Cart data = new Cart
            {
                email = email,
                lapId = lapId,
                quantity = quantity

            };

            string sql = @"update cart set quantity = '"+quantity+"'   where userId='" + email + "'  and lapId ='" + lapId + "' ;";
            return SqlDataAccess.SaveData(sql, data);

        }


        public static bool LoginUser(string Email, string password)
        {
            user data = new user
            {
                Email = Email,
                password = password
            };

            string sql = @"select * from dbo.users where email='" + Email + "'  and password ='" + password + "' ;";


            var d= SqlDataAccess.LoadData<user>(sql);
            if (d.Count > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public static bool checkCart(string email, int lapId)
        {
            Cart data = new Cart
            {
                email = email,
                lapId = lapId
            };

            string sql = @"select * from dbo.cart where userId='" + email + "'  and lapId ='" + lapId + "' ;";


            var d = SqlDataAccess.LoadData<Cart>(sql);
            if (d.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<user> LoadUser(string email)
        {
            user data = new user
            {
               Email = email,
            };

            string sql = @"select Fname,Lname,address,city,country,phone,password ,id from dbo.users where email='" +email + "' ;";

            return SqlDataAccess.LoadData<user>(sql);

        }

        public static List<product> LoadProduct()
        {
        

            string sql = @"select name,brand,color,price,decs,stauts,category,offer,pic,id ,quantity from lap ;";

            return SqlDataAccess.LoadProduct<product>(sql);

        }

        public static List<Cart> LoadCart(string email)
        {


            string sql = @"select LapId ,quantity from cart where userId='" + email + "'  ;";

            return SqlDataAccess.LoadData<Cart>(sql);

        }
     

        public static List<product> LoadDProduct(int id)
        {


            string sql = @"select name,brand,color,price,decs,stauts,category,offer,pic ,quantity,id  from lap  where id='" + id+"';";

            return SqlDataAccess.LoadProduct<product>(sql);

        }
    }
}
