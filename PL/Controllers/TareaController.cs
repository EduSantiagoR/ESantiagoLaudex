using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.Tarea.GetAll();
            ML.Tarea tarea = new ML.Tarea();
            tarea.Tareas = result.Objects;
            return View(tarea);
        }
        public IActionResult Delete(int idTarea)
        {
            ML.Result result = BL.Tarea.Delete(idTarea);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Tarea eliminada.";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar la tarea.";
            }
            return PartialView("Modal");
        }
        [HttpGet]
        [Route("/Tarea/GetTareas")]
        public ActionResult GetTareas()
        {
            ML.Result result = BL.Tarea.GetAll();
            return Json(result.Objects);
        }
        [HttpGet]
        [Route("/Tarea/ChangeStatus")]
        public ActionResult ChangeStatus(int idTarea, int idEstatus)
        {
            ML.Result result = BL.Tarea.ChangeStatus(idTarea, idEstatus);
            return Json(result.Correct);
        }
        [HttpGet]
        [Route("/Tarea/GetById")]
        public ActionResult GetById(int idTarea)
        {
            ML.Result result = BL.Tarea.GetById(idTarea);
            return Json(result.Object);
        }
        [HttpPost]
        [Route("/Tarea/Post")]
        public ActionResult Post(ML.Tarea tarea)
        {
            if(tarea.IdTarea == 0)
            {
                ML.Result result = BL.Tarea.Add(tarea);
                return Json(result.Correct);
            }
            else
            {
                ML.Result result = BL.Tarea.Update(tarea);
                return Json(result.Correct);
            }
        }
    }
}
