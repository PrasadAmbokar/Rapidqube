using AssessmentFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Controllers
{
    public class ShowDataController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=Assessment;integrated security=true");
        // GET: ShowDataController
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (con)
            {
                con.Open();
                SqlCommand sc = new SqlCommand("Sp_index", con);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            return View(dt);
        }

        [HttpGet]
        public ActionResult Information(int id)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                con.Open();
                SqlCommand sc = new SqlCommand("Sp_ShowAllInformation2", con);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.SelectCommand.Parameters.AddWithValue("@EmpId", id);
                //var itemId = GetUrlKeyValue("ID", false, location.href);
                sda.Fill(dt);
            }
            return View(dt);

        }


        [HttpGet]
        public ActionResult AddEmployeeDetails()
        {
            return View("AddEmployeeDetails");
        }

        // Post: ShowDataController/AddEmployeeeDetails
        [HttpPost]
        public ActionResult AddEmployeeDetails(AddEmployeeDetails aed)
        {

            using (con)
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_empAdd", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(com);

                com.Parameters.AddWithValue("@EmpName", aed.EmpName);
                com.Parameters.AddWithValue("@DeptId", aed.DeptId);
                //com.Parameters.AddWithValue("@DOB", aed.DOB);
                //com.Parameters.AddWithValue("@Designation", aed.Designation);
                //com.Parameters.AddWithValue("@GrossSalary", aed.GrossSalary);
                //com.Parameters.AddWithValue("@Acc_No", aed.BankAccount);
                //com.Parameters.AddWithValue("@Bank_Name", aed.BankName);
                //com.Parameters.AddWithValue("@Degree", aed.Degree);
                //com.Parameters.AddWithValue("@POY", aed.POY);
                //com.Parameters.AddWithValue("@DOJ", aed.DOJ);

                //List<ListItem> items = new List<ListItem>();
                //items.Add(new ListItem("Item 2", "Value 2"));
                //items.Add(new ListItem("Item 1", "Value 1"));
                //items.Add(new ListItem("Item 3", "Value 3"));
                //items.Sort(delegate (ListItem item1, ListItem item2) { return item1.Text.CompareTo(item2.Text); });
                //dropdown.Items.AddRange(items.ToArray());
                com.ExecuteNonQuery();
            }

            return RedirectToAction("AddEmployeeDetails");
        }
        [HttpGet]
        public ActionResult AddDepartmentDetails()
        {
            return View("AddDepartmentDetails");
        }

        // Post: ShowDataController/AddEmployeeeDetails
        [HttpPost]
        public ActionResult AddDepartmentDetails(AddDepartmentDetails add)
        {

            using (con)
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_deptAdd", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(com);

                com.Parameters.AddWithValue("@DeptName", add.DeptName);

                com.ExecuteNonQuery();
            }

            return RedirectToAction("AddDepartmentDetails");
        }
        // GET: ShowDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: ShowDataController/Edit/5
        public ActionResult EditEmployee(int id)
        {
            EditEmployee dataModel = new EditEmployee();
            DataTable tblda = new DataTable();
            using (con)
            {
                con.Open();
                //string query = "select * from Employee where EmpId=@EmpId";
                SqlCommand cmd = new SqlCommand("Sp_EditBasicInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.SelectCommand.Parameters.AddWithValue("@EmpId", id);
                sqlda.Fill(tblda);
            }
            if (tblda.Rows.Count == 1)
            {

                dataModel.EmpId = (int)tblda.Rows[0][0];
                dataModel.EmpName = tblda.Rows[0][1].ToString();
                dataModel.DeptId = (int)tblda.Rows[0][2];
                //    dataModel.Designation = tblda.Rows[0][3].ToString();
                //    dataModel.GrossSalary = (float)tblda.Rows[0][4];
                //    dataModel.BankAccount = (int)tblda.Rows[0][5];
                //    dataModel.BankName = tblda.Rows[0][6].ToString();
                //    dataModel.Degree = tblda.Rows[0][7].ToString();
                //    dataModel.POY = tblda.Rows[0][8].ToString();
                //    dataModel.DOJ = tblda.Rows[0][9].ToString();
                return View(dataModel);
            }
            else
                return RedirectToAction("Index");
        }

        //[HttpGet]
        //// GET: ShowDataController/Edit/5
        //public ActionResult EditEmployee2(int id)
        //{
        //    ShowAllInformation dataModel = new ShowAllInformation();
        //    DataTable tblda = new DataTable();
        //    using (con)
        //    {
        //        con.Open();
        //        SqlCommand sc = new SqlCommand("Sp_ShowAllInformation2", con);
        //        sc.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter sqlda = new SqlDataAdapter(sc);
        //        sqlda.SelectCommand.Parameters.AddWithValue("@EmpId", id);
        //        sqlda.Fill(tblda);
        //    }
        //    if (tblda.Rows.Count == 1)
        //    {

        //        //dataModel.EmpId = (int)tblda.Rows[0][1];
        //        dataModel.EmpName = tblda.Rows[0][2].ToString();
        //        dataModel.DeptName = tblda.Rows[0][3].ToString();
        //        dataModel.DOJ = Convert.ToDateTime(tblda.Rows[0][4]);
        //        dataModel.Designation = tblda.Rows[0][5].ToString();
        //        dataModel.DOB = Convert.ToDateTime(tblda.Rows[0][6]);                
        //        dataModel.Degree = tblda.Rows[0][7].ToString();
        //        //dataModel.POY = Convert.ToDateTime(tblda.Rows[0][8]);
        //        dataModel.BankName = tblda.Rows[0][9].ToString();
        //        dataModel.AccNo = (int)tblda.Rows[0][10];
        //        dataModel.GrossSalary = (int)tblda.Rows[0][11];


        //        return View(dataModel);


        //    }
        //    else
        //        return RedirectToAction("Index");
        //}

        // POST: ShowDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(EditEmployee ee)
        {
            using (con)
            {
                con.Open();
                //string query = "update Employee set EmpName=@EmpName,DeptId=@DeptId where EmpId=@EmpId";
                SqlCommand cmd = new SqlCommand("Sp_UpdateBasicInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@EmpId", ee.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", ee.EmpName);
                //sqlcom.Parameters.AddWithValue("@DOB", ee.DOB);
                cmd.Parameters.AddWithValue("@DeptId", ee.DeptId);
                //sqlcom.Parameters.AddWithValue("@Designation", ee.Designation);
                //sqlcom.Parameters.AddWithValue("@GrossSalary", ee.GrossSalary);
                //sqlcom.Parameters.AddWithValue("@BankAccount", ee.BankAccount);
                //sqlcom.Parameters.AddWithValue("@Degree", ee.Degree);
                //sqlcom.Parameters.AddWithValue("@POY", ee.POY);
                //sqlcom.Parameters.AddWithValue("@DOJ", ee.DOJ);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: ShowDataController/Delete/5
        public ActionResult DeleteEmployee(int id)
        {
            using (con)
            {
                con.Open();
                //string query = "delete from Employee where EmpId=@EmpId";
                SqlCommand cmd = new SqlCommand("Sp_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlCommand sqlcom = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpId", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


    }
}
