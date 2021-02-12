using AssessmentFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ActionResult IndexDepartments()
        {
            DataTable dt = new DataTable();
            using (con)
            {
                con.Open();
                SqlCommand sc = new SqlCommand("Sp_indexDepartments", con);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            return View(dt);
        }


        [HttpGet]
        public ActionResult AddEmployeeDetails()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=Assessment;integrated security=true");
            string query = "select * from Department";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ViewBag.DeptName = ds.Tables[0];

            //AddEmployeeDetails aed = new AddEmployeeDetails();
            var DeptNames = new List<SelectListItem>();

            foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
            {
                DeptNames.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });

            }
            ViewBag.Department = DeptNames;
            con.Close();
            return View("AddEmployeeDetails");
        }

        // Post: ShowDataController/AddEmployeeeDetails
        [HttpPost]
        public ActionResult AddEmployeeDetails(AddEmployeeDetails aed)
        {

            using (con)
            {
                con.Open();
                //Console.WriteLine("DeptName" + aed.DeptName);
                SqlCommand com = new SqlCommand("Sp_empAdd", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(com);

                com.Parameters.AddWithValue("@EmpName", aed.EmpName);
                //com.Parameters.AddWithValue("@DeptId", aed.DeptId);
                com.Parameters.AddWithValue("@DeptName", aed.DeptName);
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
            //using (con)
            //{
            //    //con.Open();
                
            //    SqlCommand com1 = new SqlCommand("Sp_InsertZero", con);
            //    com1.CommandType = CommandType.StoredProcedure;
            //    SqlDataAdapter sda = new SqlDataAdapter(com1);
                             
            //    com1.ExecuteNonQuery();
            //}

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
            DataSet ds = new DataSet();
            using (con)
            {
                con.Open();
                //string query = "select * from Employee where EmpId=@EmpId";
                SqlCommand cmd = new SqlCommand("Sp_EditBasicInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.SelectCommand.Parameters.AddWithValue("@EmpId", id);
                sqlda.Fill(tblda);
                //ViewBag.DeptName = ds.Tables[0]; 

                //List<SelectListItem> getDeptName = new List<SelectListItem>();

                //foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
                //{
                //    getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });
                //}
                //ViewBag.Department = getDeptName;
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
        //[ValidateAntiForgeryToken]
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

        public ActionResult DeleteDepartment(int id)
        {
            using (con)
            {
                con.Open();
                //string query = "delete from Employee where EmpId=@EmpId";
                SqlCommand cmd = new SqlCommand("Sp_DeleteDept", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlCommand sqlcom = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DeptId", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("IndexDepartments");
        }


        //public ActionResult IndexScroll()
        //{
        //    DropdownViewModel dropdownViewModel = new DropdownViewModel();
        //    using (var context = new ShowDataController())
        //    {
        //        //create SelectListItem
        //        dropdownViewModel.DeptList = context.DeptName.
        //                                   Select(a => new SelectListItem
        //                                   {
        //                                       Text = a.DeptName, // name to show in html dropdown
        //                                       Value = a.DeptName // value of html dropdown
        //                                   }).ToList();
        //    }
        //    //pass Model to view
        //    return View(dropdownViewModel);
        //}

        //public IActionResult IndexDDL()
        //{
        //    //SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=Assessment;integrated security=true");
        //    string query = "select * from Department";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    con.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    ViewBag.DeptName = ds.Tables[0];

        //    List<SelectListItem> getDeptName = new List<SelectListItem>();

        //    foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
        //    {
        //        getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });

        //    }
        //    ViewBag.Department = getDeptName;
        //    con.Close();

        //    return View();
        //}
        //[HttpGet]
        public IActionResult IndexDDL()
        {
            //EditEmployee ee = new EditEmployee();
            //ee.Departments = PopulateDepartments();
            //return View(ee);
            SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=Assessment;integrated security=true");
            string query = "select * from Department";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ViewBag.DeptName = ds.Tables[0];

            List<SelectListItem> getDeptName = new List<SelectListItem>();

            foreach (System.Data.DataRow dr in ViewBag.DeptName.Rows)
            {
                getDeptName.Add(new SelectListItem { Text = @dr["DeptName"].ToString(), Value = @dr["DeptName"].ToString() });

            }
            ViewBag.Department = getDeptName;
            con.Close();

            return View();
        }

        //        [HttpPost]
        //        public ActionResult IndexDDL(EditEmployee ee)
        //        {
        //            ee.Departments = PopulateDepartments();
        //            var selectedItem = ee.Departments.Find(p => p.Value == ee.DeptId.ToString());
        //            if (selectedItem != null)
        //            {
        //                selectedItem.Selected = true;
        //                ViewBag.Message = "Departments: " + selectedItem.Text;
        //                //ViewBag.Message += "\\nQuantity: " + ee.DeptNo;
        //            }

        //            return View(ee);
        //        }

        //        private static List<SelectListItem> PopulateDepartments()
        //        {
        //            List<SelectListItem> items = new List<SelectListItem>();
        //            string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
        //            using (SqlConnection con = new SqlConnection(constr))
        //            {
        //                string query = " SELECT DeptName, DeptId FROM Department";
        //                using (SqlCommand cmd = new SqlCommand(query))
        //                {
        //                    cmd.Connection = con;
        //                    con.Open();
        //                    using (SqlDataReader sdr = cmd.ExecuteReader())
        //                    {
        //                        while (sdr.Read())
        //                        {
        //                            items.Add(new SelectListItem
        //                            {
        //                                Text = sdr["DeptName"].ToString(),
        //                                Value = sdr["DeptId"].ToString()
        //                            });
        //                        }
        //                    }
        //                    con.Close();
        //                }
        //            }

        //            return items;
        //        }
    }
}
