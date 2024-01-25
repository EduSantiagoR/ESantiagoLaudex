using System;
using System.Collections.Generic;

namespace DL;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaVencimiento { get; set; }

    public int IdEstatus { get; set; }

    public bool Importante { get; set; }

    public virtual Estatus IdEstatusNavigation { get; set; } = null!;
}
