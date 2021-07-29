using Site.Extensoes;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        #region Colabores Session
        public List<ColaboradorViewModel> ColaboradoresList
        {
            get
            {
                if (Session["Colaboradores"] == null)
                    return new List<ColaboradorViewModel>();
                return (List<ColaboradorViewModel>)Session["Colaboradores"];
            }
            set
            {
                Session["Colaboradores"] = value;
            }
        }

        #endregion

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            List<SelectListItem> itensCombo = Enum.GetValues(typeof(TiposTelefone))
                .Cast<TiposTelefone>()
                .Select(c => new SelectListItem()
                {
                    Text = c.GetDescription(),
                    Value = c.GetDefaultValue()
                }).ToList();

            ViewBag.ItensCombo = itensCombo;

            return View("Colaboradores");
        }
        
        [HttpPost()]
        public JsonResult Cadastrar(ColaboradorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var colaboradores = new List<ColaboradorViewModel>();
                colaboradores.AddRange(ColaboradoresList);
                model.Codigo = ColaboradoresList.Count + 1;
                colaboradores.Add(model);

                ColaboradoresList = colaboradores;

                return Json(new { status = "OK", data = colaboradores });
            }

            return Json(new { status = "NOK", errors = ModelState.Values.SelectMany(c => c.Errors) });
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var colaboradores = new List<ColaboradorViewModel>();
            colaboradores.AddRange(ColaboradoresList);

            colaboradores.RemoveAt(colaboradores.FindIndex(c => c.Codigo == id));

            ColaboradoresList = colaboradores;

            return Json(new { status = "OK", data = ColaboradoresList });
        }

        [HttpPost]
        public JsonResult BuscarPorId(int id)
        {
            var colaborador = ColaboradoresList.FirstOrDefault(c => c.Codigo == id);

            return Json(new { status = "OK", data = colaborador });
        }

        [HttpPost]
        public JsonResult Listar()
        {
            return Json(new { status = "OK", data = ColaboradoresList });
        }

        [HttpPost]
        public JsonResult Alterar(ColaboradorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var colaboradores = new List<ColaboradorViewModel>();
                colaboradores.AddRange(ColaboradoresList);

                colaboradores[colaboradores.FindIndex(c => c.Codigo == model.Codigo)] = model;

                ColaboradoresList = colaboradores;

                return Json(new { status = "OK", data = colaboradores });
            }

            return Json(new { status = "NOK", errors = ModelState.Values.SelectMany(c => c.Errors) });
        }

    }
}