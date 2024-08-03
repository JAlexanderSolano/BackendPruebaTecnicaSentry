using System;
using System.Collections.Generic;

namespace PruebaTecnicaSentry.Models.Db;

public partial class TbTask
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool? Iscompleted { get; set; }
}
