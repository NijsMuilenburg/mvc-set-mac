using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MvcPvxMachines.Models;

namespace MvcPvxMachines.Controllers
{
    public class PvxMachinesController : Controller
    {
        string connectionstring = @"Data Source = DESKTOP-9QT6SVM\SQLEXPRESS; Initial Catalog = XmmLiveSync_acceptatie; Integrated Security=True";
   
        // GET: PvxMachines
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblPvxMachines = new DataTable();
            using (SqlConnection sqlconn = new SqlConnection(connectionstring))
            {
                sqlconn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * from PvxMachines", sqlconn);
                sqlDa.Fill(dtblPvxMachines);

               

            }
                return View(dtblPvxMachines);
        }


        [HttpGet]
    
        // GET: PvxMachines/Create
        public ActionResult Create()
        {
            return View(new PvxMachinesModel());
        }

        // POST: PvxMachines/Create
        [HttpPost]
        public ActionResult Create(PvxMachinesModel pvxMachinesModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "INSERT INTO PvxMachines VALUES (@PVXID,@Name,@GeoLocation, @MacAddress)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.Parameters.AddWithValue("@PVXID", pvxMachinesModel.PvxID);
                sqlCmd.Parameters.AddWithValue("@Name", pvxMachinesModel.Name);
                sqlCmd.Parameters.AddWithValue("@GeoLocation", pvxMachinesModel.GeoLocation);
                sqlCmd.Parameters.AddWithValue("@MacAddress", pvxMachinesModel.MacAddress);
                sqlCmd.ExecuteNonQuery();
            }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PvxMachinesModel pvxMachinesModel = new PvxMachinesModel();
            DataTable dtblPvxMachines = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "SELECT * FROM PvxMachines where PVXID = @PVXID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                 sqlDa.SelectCommand.Parameters.AddWithValue("@PVXID", id);
                sqlDa.Fill(dtblPvxMachines);



            }


            if (dtblPvxMachines.Rows.Count == 1)
            {

                pvxMachinesModel.PvxID = Convert.ToInt32(dtblPvxMachines.Rows[0][0].ToString());
                pvxMachinesModel.Name = dtblPvxMachines.Rows[0][1].ToString();
                pvxMachinesModel.GeoLocation = dtblPvxMachines.Rows[0][2].ToString();
                pvxMachinesModel.MacAddress = dtblPvxMachines.Rows[0][3].ToString();
                return View(pvxMachinesModel);
            }
            else
                return RedirectToAction("Index");
        }

        // GET: PvxMachines/Edit/5
       
        [HttpPost]
        public ActionResult Edit(PvxMachinesModel pvxMachinesModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "UPDATE PvxMachines SET Name = @Name, Geolocation = @GeoLocation, MacAddress = @MacAddress where PVXID = @PVXID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.Parameters.AddWithValue("@PVXID", pvxMachinesModel.PvxID);
                sqlCmd.Parameters.AddWithValue("@Name", pvxMachinesModel.Name);
                sqlCmd.Parameters.AddWithValue("@GeoLocation", pvxMachinesModel.GeoLocation);
                sqlCmd.Parameters.AddWithValue("@MacAddress", pvxMachinesModel.MacAddress);
                sqlCmd.ExecuteNonQuery();
            }



            return RedirectToAction("Index");
        }

        // POST: PvxMachines/Edit/5

     //   [HttpPost]
      /*  public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: PvxMachines/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PvxMachines/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
