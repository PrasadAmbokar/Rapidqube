using AssessmentQuora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace AssessmentQuora.Controllers
{
    public class LoginPageController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=AssessmentQuora;integrated security=true ");
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginPage lp)
        {
            string query = "select userId,password,name from UserDetail where userId=@userId and password=@password";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", lp.Username);
            cmd.Parameters.AddWithValue("@password", lp.Password);
            //cmd.Parameters.AddWithValue("@name", lp.Name);
            lp.Name = set;
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.Read())
            {
                //FormsAuthentication.SetAuthCookie()
                HttpContext.Session.SetString("name",lp.Name);
                //Session["username"]= lp.Username.ToString();
                return RedirectToAction("welcome");
            }
            else
            {
                ViewData["Message"] = "Username/Password will be wrong";
            }
            con.Close();
            return View();


        }

        public ActionResult welcome()
        {
            ViewBag.show=HttpContext.Session.GetString("name");
            return View();
        }
        public ActionResult FirstPage()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(NewLogin nl)
        {
            //try
            //{
                string query = "insert into UserDetail(userId,password,name) values(@userId,@password,@name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", nl.userName);
                cmd.Parameters.AddWithValue("@password", nl.password);
                cmd.Parameters.AddWithValue("@name", nl.name);
            try
            {
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read() != true)
                {
                    //FormsAuthentication.SetAuthCookie()
                    //HttpContext.Session.SetString("username", lp.Username);
                    //Session["username"]= lp.Username.ToString();
                    return RedirectToAction("Index");
                }
            }

            catch (Exception e)
            {
                ViewData["Message"] = "User already registered";
            }
            //else
            //{
            //    ViewData["Message"] = "User already registered";
            //}
            con.Close();
            return View();
        }
    }
}
