using System;

namespace MusicX.Web.Controllers;

public class LikeClickedBindingModel
{
    bool ShouldLike { get; set; }

    Guid UserId { get; set; }
}