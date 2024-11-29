using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=localhost; Database=DotNetCourseDatabase; Trusted_Connection=true; TrustServerCertificate=true;";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand); // QuerySingle returns a single value from the database

            Console.WriteLine(rightNow.ToString());

           Computer myComputer = new Computer() 
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

           string sql = @"INSERT INTO TutorialAppSchema.Computer (
            Motherboard, 
            HasWifi, 
            HasLTE, 
            ReleaseDate, 
            Price, 
            VideoCard
            )
            VALUES ('" + myComputer.Motherboard 
            + "', " + "'" + myComputer.HasWifi 
            + "', " + "'" + myComputer.HasLTE 
            + "', " + "'" + myComputer.ReleaseDate.ToString("yyyy-MM-dd") //REMEMBER TO FORMAT THE DATE
            + "', " + "'" + myComputer.Price 
            + "', " + "'" + myComputer.VideoCard 
            + "')";
            
            Console.WriteLine(sql);
            dbConnection.Execute(sql, myComputer);
            
            List<Computer> computers = dbConnection.Query<Computer>("SELECT * FROM TutorialAppSchema.Computer").ToList();

            foreach (Computer computer in computers)
            {
                Console.WriteLine(computer.ToString());
            }
        }
    }
}