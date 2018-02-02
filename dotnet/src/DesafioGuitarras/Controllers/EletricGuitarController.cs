using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Interfaces.Services;
using DesafioGuitarras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioGuitarras.Controllers
{
    public class EletricGuitarController : MvcController
    {
        private readonly IEletricGuitarService _service;

        public EletricGuitarController(IEletricGuitarService service) => _service = service;

        public ActionResult Index() => View();

        public ActionResult Search() => PartialView("_Result", _service.GetAll());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(EletricGuitar model)
        {
            if (ModelState.IsValid)
            {
                model = _service.Add(model);
                if (model.Validation.IsValid)
                {
                    AddNotification($"O registro [{model.Name}] foi criado com sucesso", NotificationModel.Types.SUCCESS);
                    return View("Edit", model);
                }

                AddNotification(model.Validation);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                AddNotification($"Parâmetros GET inválidos!", NotificationModel.Types.WARNING);
                return View("Index");
            }

            var model = _service.GetByPrimaryKey(id);
            if(model == null)
            {
                AddNotification($"Registro de id [{id}] não foi encontrado!", NotificationModel.Types.WARNING);
                return View("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EletricGuitar model)
        {
            if (ModelState.IsValid)
            {
                model = _service.Edit(model);
                if (model.Validation.IsValid)
                {
                    AddNotification($"O registro [{model.Name}] foi editado com sucesso", NotificationModel.Types.SUCCESS);
                    return View("Edit", model);
                }

                AddNotification(model.Validation);
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                AddNotification($"Parâmetros GET inválidos!", NotificationModel.Types.WARNING);
                return View("Index");
            }

            if (_service.Delete(id))
                AddNotification($"Registro de id [{id}] excluído com sucesso!", NotificationModel.Types.SUCCESS);
            else
                AddNotification($"OOPS, não foi possivel excluir o registro de id [{id}]!", NotificationModel.Types.WARNING);

            return PartialView("_Notification");
        }
    }
}