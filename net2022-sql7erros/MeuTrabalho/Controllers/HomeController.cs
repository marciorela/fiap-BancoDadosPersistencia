using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using MeuTrabalho.Repositories;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        static SqlConnection _globalConnection = null;
        readonly LogRepository logRepository;

        public HomeController()
        {
            if(_globalConnection == null)
            {
                _globalConnection = new SqlConnection("Server=martedb.database.windows.net;Database=db2022;User=app;Password=homework-mar22;Max Pool Size=2");
                _globalConnection.Open();
            }

            logRepository = new LogRepository(_globalConnection);
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About([FromQuery]string teste = "")
        {
            try
            {
                if (teste == "")
                {
                    teste = logRepository.TotalRegistros().ToString();
                }

                ViewData["Message"] = "Total de acessos: " + teste;

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('about')", _globalConnection);
                var retorno = sql.ExecuteReader();   
                
                if( retorno == null )
                {
                    return RedirectToAction("RETORNO NULO");
                }
            }
            catch(Exception ex)
            {
                ViewData["Message"] = "ERROR ABOUT";
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            try
            {
                SqlConnection conn1 = _globalConnection;

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('contact')");
                sql.Connection = conn1;

                sql.ExecuteScalar();
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Error");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
