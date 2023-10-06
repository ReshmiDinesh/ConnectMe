using System;
using System.Collections.Generic;

namespace ConnectMe.UserMicroService.Data;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string UserType1 { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
