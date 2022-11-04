using EXU2_Herrera.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXU2_Herrera.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public static EMPLEADO objEMPLEADO = new EMPLEADO();
        public ActionResult Index()
        {

                return View(objEMPLEADO.Listar());

        }
        public ActionResult Visualizar(int id)
        {
            return View(objEMPLEADO.Obtener(id));
        }

        //public ActionResult Buscar(string criterio)
        //{
        //    return View(
        //        criterio == null || criterio == ""
        //        ? objEMPLEADO.Listar()
        //        : objEMPLEADO.Buscar(criterio)
        //        );
        //}

        public ActionResult AgregarEditar(int id = 0)
        {

            return View(
                id == 0
                ? new EMPLEADO()
                : objEMPLEADO.Obtener(id)
                );
        }

        public ActionResult Guardar(EMPLEADO model)
        {
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Empleado/");
            }
            else
            {
                return View("~/Views/Empleado/AgregarEditar", objEMPLEADO);
            }
        }

        public ActionResult Eliminar(int id)
        {
            var data = objEMPLEADO.Obtener(id);
            data.ESTADO = "I";
            data.Guardar();
            return Redirect("~/Empleado/Index");
        }
    }
}