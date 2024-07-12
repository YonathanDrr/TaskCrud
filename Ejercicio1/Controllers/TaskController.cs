using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio1.Controllers
{
    public class TaskController : Controller
    {

        AccesoDatos.Task taskAccess = new AccesoDatos.Task();


        // GET: Task
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]

        public JsonResult TaskList()
        {

            try
            {
                return Json(new { data = taskAccess.TaskList() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }



        public JsonResult TaskIngresa(Models.Task task){

            try
            {
                    var resultado = taskAccess.TaskIngresa(task);
                    return Json(new { resultado }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult TaskActualiza(Models.Task task)
        {

            try
            {
              

                var resultado = taskAccess.TaskActualiza(task);
                return Json(new { resultado }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }



        public JsonResult TaskElimina(Models.Task task)
        {

            try
            {
                var resultado = taskAccess.TaskElimina(task);
                return Json(new { resultado }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }



        public JsonResult TaskRetornaTareas(Models.Task task)
        {
            var resultado = taskAccess.TaskRetornaTareas(task);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}