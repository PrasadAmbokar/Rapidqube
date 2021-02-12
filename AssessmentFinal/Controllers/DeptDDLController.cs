using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Controllers
{
    public class DeptDDLController : Controller
    {
        public IActionResult IndexDDL()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=Assessment;integrated security=true");
            string query = "select * from Department";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ViewBag.DeptName = ds.Tables[0];

            List<SelectListItem> getDeptName = new List<SelectListItem>();

            foreach(System.Data.DataRow dr in ViewBag.DeptName.Rows)
            {
                getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });

            }
            ViewBag.Department = getDeptName;
            con.Close();

            return View();
        }
    }
}
