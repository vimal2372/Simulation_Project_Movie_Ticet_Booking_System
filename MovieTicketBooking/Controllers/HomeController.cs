using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MovieTicketBooking.Helper;
using MovieTicketBooking.Models;
using Newtonsoft.Json;

namespace MovieTicketBooking.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));

        public HomeController()
        {
            //_logger = logger;
        }

        [HttpGet]
        public IActionResult demo()
        {
            return View("demo");
        }
        [HttpPost]
        public IActionResult demo(UserData a)
        {

            string name = "demo1";
           
            return Content(name);
        }


        UserAPI _api = new UserAPI();
       
        public async Task<ActionResult> Index()
        {

            TempData["username"] = null;
            List<MovieData> movies = new List<MovieData>();

            HttpClient client = _api.Initalmovie();
            HttpResponseMessage res = await client.GetAsync("api/Movie");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                movies = JsonConvert.DeserializeObject<List<MovieData>>(results);
            }
            _log4net.Info("index method invoked");
            TempData.Keep();
            return View(movies);
        }

       /* public async Task<IActionResult> Details(int Id)
        {
            var user = new UserData();
            HttpClient client = _api.Initaluser();
            HttpResponseMessage res = await client.GetAsync($"api/User/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserData>(results);
            }
            return View(user);
        }*/



        public IActionResult Privacy()
        {
            return View();
        }



        public ActionResult create1()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult create1(MovieData movie)
        {
            HttpClient client = _api.Initalmovie();
            var postTask = client.PostAsJsonAsync<MovieData>($"api/Movie", movie);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                _log4net.Info("creat1 method invoked");
                return RedirectToAction("Index");
            }
            return View();
        }




        public ActionResult create()
        {
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public IActionResult create(UserData user)
        {
            HttpClient client = _api.Initaluser();
            var postTask = client.PostAsJsonAsync<UserData>($"api/User", user);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData.Keep();
                return RedirectToAction("userlogin");
            }
            return View();
        }

      
        public IActionResult gotobooknow()
        {
            return RedirectToAction("BookNow");
        }




        [HttpGet]
        public async Task<ActionResult> adminlogin()
        {

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> adminlogin(AdminData a)
        {
            List<AdminData> admins = new List<AdminData>();

            HttpClient client = _api.Initaladmin();
            HttpResponseMessage res = await client.GetAsync("api/Admin");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                admins = JsonConvert.DeserializeObject<List<AdminData>>(results);
            }
            foreach (var item in admins)
            {
                if (item.UserName== a.UserName && item.Password == a.Password)
                {
                    return RedirectToAction("create1");

                }
                else
                {
                    _log4net.Error("invalid admin");
                    ViewBag.msg = "Invalid admin name or password";
                }
            }

            return View();


        }

        [HttpGet]
        public async Task<ActionResult> userlogin()
        {

            return  View();
        }
        
       
        [HttpPost]
        public async Task<ActionResult> userlogin(UserData a)
        {

            List<UserData> users = new List<UserData>();

            HttpClient client = _api.Initaluser();
           
            HttpResponseMessage res = await client.GetAsync("api/User");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserData>>(results);
            }
            foreach (var item in users)
            {
                if (item.Email == a.Email && item.Password==a.Password)
                {
                    HttpClient clientt = _api.Initalauthorization();
                    var contentType = new MediaTypeWithQualityHeaderValue
      ("application/json");
                    clientt.DefaultRequestHeaders.Accept.Add(contentType);

                    UserData userModel = new UserData();
                    userModel.Id = 1;
                    userModel.UserName = "Anuj";
                    userModel.Password = "1234";
                    string stringData = JsonConvert.SerializeObject(userModel);
                    var contentData = new StringContent(stringData,
                System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage postTask = clientt.PostAsync
                ("/api/Account", contentData).Result;

                   // HttpResponseMessage postTask= await client.GetAsync("api/Account");

                    string stringJWT = postTask.Content.ReadAsStringAsync().Result;
                    JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);

                    HttpContext.Session.SetString("token", jwt.Token);

                   /* if (!result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("login");
                    }
                    string apiResponse1 =await  result.Content.ReadAsStringAsync();
                  //  JWT jwt= JsonConvert.DeserializeObject<JWT>(apiResponse1);
                    */

                    TempData["username"] = item.UserName.ToString();
                    TempData.Keep();

                    
                    return RedirectToAction("BookNow");
                    
                }
                else
                {
                    ViewBag.msg = "Invalid username or  password";
                }
            }
            
            return View();


        }
        public IActionResult gettoken()
        {
            string s = HttpContext.Session.GetString("token");
            return Content(s);
        }

       
        [HttpGet]
        public async Task<ActionResult> BookNow(int Id)
        {
            _log4net.Info("token has generated");
            if (TempData["username"] == null || HttpContext.Session.GetString("token") == null)
            {
                TempData["MovieId"] = Id;
                TempData.Keep();
                return RedirectToAction("userlogin");
            }
           
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> BookNow(Booking vm)
        {
            int Id = Convert.ToInt32(TempData["MovieId"]);
            string c = "no";

            List<Booking> bookings = new List<Booking>();
           
            HttpClient client = _api.Initalbookingt();
            HttpResponseMessage ress = await client.GetAsync("api/Bookingt");
            if (ress.IsSuccessStatusCode)
            {
                var results = ress.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<Booking>>(results);
                foreach (var item in bookings)
                {
                    if (item.seatno== vm.seatno&&item.MovieDetailsId==Id)
                    {
                        c = "yes";
                        break;
                    }
                    else
                    {
                        c = "no";
                    }
                }
            }
            if (c == "yes")
            {
                ViewBag.msg = "This seat is already booked go for another";
            }
            else
            {
                Booking vmm = new Booking();

                
                string UserN = TempData["username"].ToString();
                vmm.MovieDetailsId = Id;
                vmm.UserName = UserN;
                vmm.seatno = vm.seatno;
                List<MovieData> movies = new List<MovieData>();
                HttpClient clientttt = _api.Initalmovie();
                HttpResponseMessage res = await clientttt.GetAsync("api/Movie");
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    movies = JsonConvert.DeserializeObject<List<MovieData>>(results);
                }
                foreach (var itemm in movies)
                {
                    if (itemm.Id == Id)
                    {

                        vmm.Datetopresent = itemm.DateAndTime;
                        vmm.MovieName = itemm.Movie_Name;
                        break;
                    }
                }
                HttpClient clientt = _api.Initalbookingt();
                var postTask = clientt.PostAsJsonAsync<Booking>($"api/Bookingt", vmm);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData.Keep();
                    return RedirectToAction("cart");
                }
            }
       
            return View();
            }
           
        public async Task<IActionResult> cart()
        {
            string adid = TempData["username"].ToString();

            List<Booking> bookings = new List<Booking>();
           List<Booking> li = new List<Booking>();
            HttpClient client = _api.Initalbookingt();
            HttpResponseMessage res = await client.GetAsync("api/Bookingt");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<Booking>>(results);
                foreach (var item in bookings)
                {
                    if (item.UserName == adid)
                    {
                        li.Add(item);
                    }
                    ViewBag.msg = "This seat is  booked and this is your cart";
                }
            }
            else
            {
                ViewBag.msg = "This seat is  booked and this is your cart";
            }
            
           
            return View(li);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId=Activity.Current?.Id??HttpContext.TraceIdentifier});
        }
        
    }
    public class JWT
    {
        public string Token { get; set; }
    }

}
