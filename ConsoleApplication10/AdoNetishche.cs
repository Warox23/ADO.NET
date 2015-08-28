using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;


namespace ConsoleApplication10
{
 


    class AdoNetishche
    {
        public void addElemet(string NameOfConStr,Items items)
        {
            var a = ConfigurationManager.ConnectionStrings[NameOfConStr].ConnectionString;
           
            SqlConnection sconn = new SqlConnection(a);


            SqlCommand sItems = new SqlCommand(string.Format("INSERT into Items(FirstName,LastName) values (@FirstName,@LastName);SELECT CAST(scope_identity() AS INT) "), sconn);
            SqlCommand sJobs = new SqlCommand(string.Format("INSERT into jobs(Time,decription,Phone,UserId,Item_Id) values (@Time,@decription,@Phone,@UserId,@Item_Id)"), sconn);
            SqlCommand sPoss = new SqlCommand(string.Format("INSERT into positions(Latitude,Longitude,Accuracy,time,Item_Id) values (@Latitude,@Longitude,@Accuracy,@time,@Item_Id)"), sconn);
            sconn.Open();

            foreach (var it in items.Itms)
            {

               


             //   sItems.Parameters.AddWithValue("@Id",it.Id);
                sItems.Parameters.AddWithValue("@FirstName",it.FirstName);
                sItems.Parameters.AddWithValue("@LastName",it.LastName);
                
               var newID = sItems.ExecuteScalar();
             

                foreach (var job in it.jobHistory)
                {
                    sJobs.Parameters.Clear();
                 //   sJobs.Parameters.AddWithValue("@Id", job.Id);
                    sJobs.Parameters.AddWithValue("@Time", job.time);
                    sJobs.Parameters.AddWithValue("@decription", job.decription);
                    sJobs.Parameters.AddWithValue("@Phone", job.Phone);
                    sJobs.Parameters.AddWithValue("@UserId", job.Userid);
                    sJobs.Parameters.AddWithValue("@Item_Id", newID);
                    sJobs.ExecuteNonQuery();
                    sJobs.Parameters.Clear();

                }


                foreach (var pos in it.positionsHistory)
                {
                    sPoss.Parameters.Clear();
                   // sPoss.Parameters.AddWithValue("@Id", pos.Id);
                    sPoss.Parameters.AddWithValue("@Latitude", pos.Latitude);
                    sPoss.Parameters.AddWithValue("@Longitude", pos.Longitude);
                    sPoss.Parameters.AddWithValue("@Accuracy", pos.Accuracy);
                    sPoss.Parameters.AddWithValue("@time", pos.time);
                    sPoss.Parameters.AddWithValue("@Item_Id", newID);
                    sPoss.ExecuteNonQuery();
                    sPoss.Parameters.Clear();
                }
                sItems.Parameters.Clear();
                sconn.Close();
            }
            
            /*
            using (var con = new SqlConnection(ConnectionString))
            {
                int newID;
                var cmd = "INSERT INTO foo (column_name)VALUES (@Value);SELECT CAST(scope_identity() AS int)";
                using (var insertCommand = new SqlCommand(cmd, con))
                {
                    insertCommand.Parameters.AddWithValue("@Value", "bar");
                    con.Open();
                    newID = (int)insertCommand.ExecuteScalar();
                }
            }
            */


        }


        public void TestPoolConnectionn(string NameOfConStr)
        {
            var a = ConfigurationManager.ConnectionStrings[NameOfConStr].ConnectionString;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                SqlConnection sc = new SqlConnection(a);
                sc.Open();
                sc.Close();
            }
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

        }

    }
}
