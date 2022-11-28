using System;
using System.Collections.Generic;

namespace Runners.Models;

public partial class Runner
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public double Minutes { get; set; }

    public double Seconds { get; set; }
}
