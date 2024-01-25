using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatus
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoLaudexContext context = new DL.EsantiagoLaudexContext())
                {
                    var query = (from estado in context.Estatuses select new {IdEstatus = estado.IdEstatus, Estado = estado.Estado}).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Estatus estatus = new ML.Estatus();
                            estatus.IdEstatus = item.IdEstatus;
                            estatus.Estado = item.Estado;
                            result.Objects.Add(estatus);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los estatus.";
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
    }
}
