using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace League_WebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AddMatchResult()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult AddMatchResult(string matchid, string teamname1, string teamname2, string status,string winningteam, string points)
        {
            String constring = "Data Source=anujavm;Initial Catalog=master;Integrated Security=True";
            SqlConnection sqlconn =new SqlConnection(constring);
            String name = "Records";
            sqlconn.Open();
            SqlCommand command=new SqlCommand(name, sqlconn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MathID", Convert.ToInt32(matchid));
            command.Parameters.AddWithValue("@TeamName1",teamname1);
            command.Parameters.AddWithValue("@Teamname2", teamname2);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@WinningTeam", winningteam);
            command.Parameters.AddWithValue("@POints", points);
            command.ExecuteNonQuery();
            sqlconn.Close();
            ViewBag.result = "Record has been saved successfully";
            return View();

        }

       
    }
}