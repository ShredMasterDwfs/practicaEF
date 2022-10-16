using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using practica.EF.API.Models;
using practica.EF.Services.Models;

namespace practica.EF.API.Controllers
{
    public class ExternalAPIController : Controller
    {
        ExternalAPIService service = new ExternalAPIService();
        // GET: ExternalAPI
        public async Task<ActionResult> Index()
        {
            var usuario = await service.ListAPI();
            var lista = usuario.Select(u => new ExternalAPIModel
            {
                postId = u.postId,
                name = u.name,
                email = u.email,
                body = u.body
            }).Take(25).ToList();

            return View(lista);
        }
    }
}