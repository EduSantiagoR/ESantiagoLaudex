namespace BL
{
    public class Tarea
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    var query = (from tarea in context.Tareas
                                 join estatus in context.Estatuses on tarea.IdEstatus equals estatus.IdEstatus
                                 select new
                                 {
                                     IdTarea = tarea.IdTarea,
                                     Titulo = tarea.Titulo,
                                     Descripcion = tarea.Descripcion,
                                     FechaVencimiento = tarea.FechaVencimiento,
                                     Importante = tarea.Importante,
                                     IdEstatus = estatus.IdEstatus,
                                     Estado = estatus.Estado
                                 }).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Tarea tarea = new ML.Tarea();
                            tarea.Estatus = new ML.Estatus();

                            tarea.IdTarea = item.IdTarea;
                            tarea.Titulo = item.Titulo;
                            tarea.Descripcion = item.Descripcion;
                            tarea.FechaVencimiento = item.FechaVencimiento;
                            tarea.Importante = item.Importante;
                            tarea.Estatus.IdEstatus = item.IdEstatus;
                            tarea.Estatus.Estado = item.Estado;

                            result.Objects.Add(tarea);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al recuperar las tareas.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int idTarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    var query = (from tarea in context.Tareas
                                 join estatus in context.Estatuses on tarea.IdEstatus equals estatus.IdEstatus
                                 where tarea.IdTarea == idTarea
                                 select new
                                 {
                                     IdTarea = tarea.IdTarea,
                                     Titulo = tarea.Titulo,
                                     Descripcion = tarea.Descripcion,
                                     FechaVencimiento = tarea.FechaVencimiento,
                                     Importante = tarea.Importante,
                                     IdEstatus = estatus.IdEstatus,
                                     Estado = estatus.Estado
                                 }).AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        result.Object = new object();

                        ML.Tarea tarea = new ML.Tarea();
                        tarea.Estatus = new ML.Estatus();

                        tarea.IdTarea = query.IdTarea;
                        tarea.Titulo = query.Titulo;
                        tarea.Descripcion = query.Descripcion;
                        tarea.FechaVencimiento = query.FechaVencimiento;
                        tarea.Importante = query.Importante;
                        tarea.Estatus.IdEstatus = query.IdEstatus;
                        tarea.Estatus.Estado = query.Estado;

                        result.Object = tarea;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al recuperar la tarea.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int idTarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    var query = (from tarea in context.Tareas where tarea.IdTarea == idTarea select tarea).First();
                    context.Tareas.Remove(query);
                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al eliminar la tarea.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Tarea tarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    DL.Tarea nuevaTarea = new DL.Tarea();
                    nuevaTarea.Titulo = tarea.Titulo;
                    nuevaTarea.Descripcion = tarea.Descripcion;
                    nuevaTarea.FechaVencimiento = tarea.FechaVencimiento;
                    nuevaTarea.Importante = tarea.Importante;
                    nuevaTarea.IdEstatus = tarea.Estatus.IdEstatus;

                    context.Tareas.Add(nuevaTarea);
                    int rowsAffected = context.SaveChanges();
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar la tarea.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Tarea tarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    var query = (from tar in context.Tareas where tar.IdTarea == tarea.IdTarea select tar).SingleOrDefault();
                    if(query != null)
                    {
                        query.Titulo = tarea.Titulo;
                        query.Descripcion = tarea.Descripcion;
                        query.FechaVencimiento = tarea.FechaVencimiento;
                        query.Importante = tarea.Importante;
                        query.IdEstatus = tarea.Estatus.IdEstatus;

                        int rowsAffected = context.SaveChanges();
                        if(rowsAffected > 0 )
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "Error al actualizar la tarea.";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al recuperar la tarea.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result ChangeStatus(int idTarea, int idEstatus)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    var query = (from tar in context.Tareas where tar.IdTarea == idTarea select tar).SingleOrDefault();
                    if(query != null)
                    {
                        query.IdEstatus = idEstatus;
                        query.Importante = false;
                        int rowsAffected = context.SaveChanges();
                        if(rowsAffected > 0 )
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "Error al cambiar el estatus.";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al recuperar la tarea.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
