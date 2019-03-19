using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DamianPortfolio.Models;
using Newtonsoft.Json;
using SQLitePCL;

namespace DamianPortfolio.Controllers
{

    public class ProjectItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public bool isFinished { get; set; }
        // could be an enum
        public string ProjectType { get; set; }
    }

    public class HomeController : Controller
    {
        string baseURL = "https://localhost:44393/";

        public async Task<ActionResult> Index()
        {
            List<ProjectItem> projects = new List<ProjectItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/project");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var projectsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    projects = JsonConvert.DeserializeObject<List<ProjectItem>>(projectsResponse);

                }
                //returning the employee list to view  
                return View(projects);

            }
        }

        public async Task<ActionResult> AdminPage()
        {
            List<ProjectItem> projects = new List<ProjectItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/project");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var projectsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    projects = JsonConvert.DeserializeObject<List<ProjectItem>>(projectsResponse);

                }
                //returning the employee list to view  
                return View(projects);

            }
        }



        [Route("project/{name}", Name = "ProjectByName")]
        public async Task<ActionResult> GetProjectByName(string name)
        {
            var project = new ProjectItem();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"api/project/{name}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var projectsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    project = JsonConvert.DeserializeObject<ProjectItem>(projectsResponse);

                }
                //returning the employee list to view  
                return View(project);

            }
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
