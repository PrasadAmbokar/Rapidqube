using AssessmentQuora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
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
            //SqlDataReader sda = cmd.ExecuteReader();

            DataTable tblda = new DataTable();

            SqlDataAdapter sda= new SqlDataAdapter(cmd);
            sda.Fill(tblda);
            //if (tblda.Rows.Count == 1)
            //{
            //    lp.Name = tblda.Rows[0][2].ToString();
            //}


            if (tblda.Rows.Count == 1)
            {
                lp.Name = tblda.Rows[0][2].ToString();
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

        [HttpGet]
        public ActionResult Question()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=AssessmentQuora;integrated security=true");
            string query = "select * from Topic";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ViewBag.topic = ds.Tables[0];

            //AddEmployeeDetails aed = new AddEmployeeDetails();
            var topics = new List<SelectListItem>();

            foreach (System.Data.DataRow dr in ViewBag.topic.Rows)
            {
                topics.Add(new SelectListItem { Text = @dr["topicname"].ToString(), Value = @dr["topicname"].ToString() });

            }
            ViewBag.showtopics = topics;
            con.Close();
            return View("Question");
        }

        [HttpPost]
        public ActionResult Question(AddQuestion aq)
        {
            using (con)
            {
                con.Open();
                
                SqlCommand com = new SqlCommand("Sp_AddQuestion", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(com);

                com.Parameters.AddWithValue("@topicname", aq.topic);
                com.Parameters.AddWithValue("@question", aq.question);
                
                com.ExecuteNonQuery();
            }
                return View("Index");
        }

        [HttpGet]
        public ActionResult Answer(AddQuestion aq)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=AssessmentQuora;integrated security=true");
            string query = "select queId from Question" /*where question=@question"*/;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            
            //cmd.Parameters.AddWithValue("@question", aq.question);                  

            DataTable tblda = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tblda);
            
            con.Close();
            return View("Answer");
        }

        [HttpPost]
        public ActionResult Answer(AddAnswer aq)
        {
            using (con)
            {
                con.Open();

                SqlCommand com = new SqlCommand("Sp_AddQuestion", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(com);

                //com.Parameters.AddWithValue("@topicname", aq.topic);
                //com.Parameters.AddWithValue("@question", aq.question);

                com.ExecuteNonQuery();
            }
            return View("Index");
        }
    }
}
