using System;
using System.Collections.Generic;

namespace ConnectMe.UserMicroService.Data;

public partial class UserProfileDetail
{
    public int UserProfileDetailsId { get; set; }

    public int UserProfileId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public bool? IsEmailConfirmed { get; set; }

    public bool? IsPasswordConfirmed { get; set; }

    public virtual UserProfile UserProfile { get; set; } = null!;
}
