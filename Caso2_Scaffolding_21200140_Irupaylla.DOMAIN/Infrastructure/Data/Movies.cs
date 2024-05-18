using System;
using System.Collections.Generic;

namespace Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Infrastructure.Data;

public partial class Movies
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string ReleaseYear { get; set; } = null!;
}
