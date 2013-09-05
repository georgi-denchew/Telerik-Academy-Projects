using StudentsDb.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:35390/") };

        static void Main(string[] args)
        {
            //InitializeHeader();
            
            //var mark = new MarkFullModel() { Value = 2.3, Subject = "Math" };
            //var student = new StudentFullModel() { FirstName = "Gosho", LastName = "Goshev", Age = 15, Grade = 2 };
            //student.Marks.Add(mark);

            //var school = new SchoolFullModel() { Name = "Telerik School", Location = "Sofia" };
            //school.Students.Add(student);
            //var result = client.PostAsJsonAsync("api/schools/", school).Result;

            //Console.WriteLine(result.StatusCode);
        }

        private static void InitializeHeader()
        {
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
