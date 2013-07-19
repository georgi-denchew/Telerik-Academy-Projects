using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TASK 05
// Write a program that retrieves the images for
// all categories in the Northwind database and
// stores them as JPG files in the file system.

namespace _05.NorthwindCategoriesImageExtract
{
    class ImageGetter
    {
        static void Main(string[] args)
        {
            OpenConnection();

            string query = "SELECT Picture FROM Categories";
            
            SqlCommand cmd = new SqlCommand(query, dbCon);
            SqlDataReader reader = cmd.ExecuteReader();

            ExtractImages(reader);
        }

        private static void ExtractImages(SqlDataReader reader)
        {
            using (reader)
            {
                int count = 1;

                while (reader.Read())
                {
                    byte[] imageFromDb = (byte[])reader["Picture"];

                    FileStream stream = File.OpenWrite("D:\\pciture" + count.ToString() + ".jpg");

                    using (stream)
                    {
                        stream.Write(imageFromDb, 0, imageFromDb.Length);
                    }
                    count++;
                }
            }
        }

        private static SqlConnection dbCon;
        private static void OpenConnection()
        {
            dbCon = new SqlConnection("Server=LOCALHOST; Database=Northwind; Integrated Security=true");
            dbCon.Open();
        }
    }
}
