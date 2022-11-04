using EXU2_Herrera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXU2_Herrera.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        public static DETALLE_PEDIDO objde = new DETALLE_PEDIDO();
        public static PEDIDO objPed = new PEDIDO();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {

                return View(objde.Listar());
            }
            else
            {
                var data = objPed.Obtener(criterio);
                return View(objde.Buscar(data.IDPEDIDO));
            }
        }
    }
}