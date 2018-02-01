using DesafioGuitarras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioGuitarras.Controllers
{
    public class EletricGuitarController : MvcController
    {
        public ActionResult Index() => View();

        public ActionResult Create(EletricGuitar guitar)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Update(EletricGuitar guitar)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}