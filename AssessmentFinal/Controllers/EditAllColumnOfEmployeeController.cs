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
    public class EditAllColumnOfEmployeeController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-JH7JRHH\\SQLEXPRESS;database=Assessment;integrated security=true");
        // GET: EditAllColumnOfEmployeeController
        public ActionResult Index()
        {
            //return RedirectToAction("EditEmployee3");
            return View();
        }

        // GET: EditAllColumnOfEmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditAllColumnOfEmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditAllColumnOfEmployeeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
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

        // GET: EditAllColumnOfEmployeeController/Edit/5
        [HttpGet]
        public ActionResult EditEmployee3(int id)
        {
            ShowAllInformation dataModel = new ShowAllInformation();
            DataTable tblda = new DataTable();
            using (con)
            {
                con.Open();
                //string query = "SELECT EmpName,DeptName,DOJ,Designation,DOB,Degree,POY,BankName,AccNo,BasicSalary,HRA,OtherAllowance,GrossSalary,PF,MedicalPremium,TDS,NetSalary from Employee e join Department d on d.DeptId = e.DeptId left join EmployeeDetails2 empd on empd.EmpId = e.EmpId left join BankDetails2 bnk on bnk.EmpId = e.EmpId where e.EmpId = @EmpId";
                SqlCommand sc = new SqlCommand("Sp_ShowAllInformation3", con);
                sc.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlda = new SqlDataAdapter(sc);
                sqlda.SelectCommand.Parameters.AddWithValue("@EmpId", id);
                sqlda.Fill(tblda);
            }
            if (tblda.Rows.Count == 1)
            {

                dataModel.EmpId = Convert.ToInt32(tblda.Rows[0][0]);
                dataModel.DeptId = Convert.ToInt32(tblda.Rows[0][1]);
                dataModel.EmpName = tblda.Rows[0][2].ToString();
                //dataModel.DeptName = tblda.Rows[0][2].ToString();
                //if (!String.IsNullOrEmpty(tblda.Rows[0][3].ToString()))
                //    dataModel.DOB = Convert.ToString(tblda.Rows[0][3]).("dd/MM/yyyy");


                //if (!String.IsNullOrEmpty(tblda.Rows[0]["DOB"].ToString()))
                //    dataModel.DOB = Convert.ToDateTime(tblda.Rows[0]["DOB"]).ToString("dd/MM/yyyy");

                //if (!DBNull.Value.Equals(tblda.Rows[0][3]))
                //    dataModel.DOB=Convert.ToDateTime(tblda.Rows[0][3]);
                //else
                //    dataModel.DOB= (DateTime)Convert.ChangeType(tblda.Rows[0][3],TypeCode.DateTime);
                //if (dataModel.DOB is DBNull)
                    dataModel.DOB = tblda.Rows[0][3].ToString();
                
                dataModel.Designation = tblda.Rows[0][4].ToString();

                //if (dataModel.DOJ is DBNull)
                    dataModel.DOJ = tblda.Rows[0][5].ToString();
                
                
                dataModel.Degree = tblda.Rows[0][6].ToString();

                //if (dataModel.POY is DBNull)
                    dataModel.POY = tblda.Rows[0][7].ToString();
                
                dataModel.BankName = tblda.Rows[0][8].ToString();

                //if (dataModel.AccNo is DBNull)
                    dataModel.AccNo = tblda.Rows[0][9].ToString();

                //if (dataModel.GrossSalary is DBNull)
                    dataModel.GrossSalary = tblda.Rows[0][10].ToString();

                return View(dataModel);
            }
            else
                return RedirectToAction("Index");
                 
        }

        // POST: EditAllColumnOfEmployeeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditEmployee3(ShowAllInformation sai)
        {
            using (con)
            {
                con.Open();
                //string query = "update Employee set EmpName=@EmpName,DeptName=@DeptName,DOB=@DOB,Designation=@Designation,DOJ=@DOJ,Degree=@Degree,POY=@POY,BankName=@BankName,AccNo=@AccNo,GrossSalary=@GrossSalary where EmpId=@EmpId";
                SqlCommand sqlcom = new SqlCommand("Sp_EditAllInformation5", con);
                sqlcom.CommandType = CommandType.StoredProcedure;
                //SqlCommand sqlcom = new SqlCommand(query, con);

                sqlcom.Parameters.AddWithValue("@EmpId", sai.EmpId);
                sqlcom.Parameters.AddWithValue("@DeptId", sai.DeptId);
                sqlcom.Parameters.AddWithValue("@EmpName", sai.EmpName);
                //sqlcom.Parameters.AddWithValue("@DeptName", sai.DeptName);
                sqlcom.Parameters.AddWithValue("@DOB", sai.DOB);
                sqlcom.Parameters.AddWithValue("@Designation", sai.Designation);
                sqlcom.Parameters.AddWithValue("@DOJ", sai.DOJ);
                sqlcom.Parameters.AddWithValue("@Degree", sai.Degree);
                sqlcom.Parameters.AddWithValue("@POY", sai.POY);
                sqlcom.Parameters.AddWithValue("@BankName", sai.BankName);
                sqlcom.Parameters.AddWithValue("@AccNo", sai.AccNo);
                sqlcom.Parameters.AddWithValue("@GrossSalary", sai.GrossSalary);


                sqlcom.ExecuteNonQuery();
            }
            return RedirectToAction("Index","ShowData");
        }

        // GET: EditAllColumnOfEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditAllColumnOfEmployeeController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
        public ActionResult Distribution(int id)
        {
            DataTable dt = new DataTable();
            using (con)
            {
                con.Open();
                SqlCommand sc = new SqlCommand("Sp_Distribution", con);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.SelectCommand.Parameters.AddWithValue("@EmpId", id);
                //var itemId = GetUrlKeyValue("ID", false, location.href);
                sda.Fill(dt);
            }
            return View(dt);
        }
    }
}
