using System;
using System.Collections.Generic;

namespace ConnectMe.UserMicroService.Data;

public partial class UserProfile
{
    public int UserProfileId { get; set; }

    public int? UserTypeId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public bool? IsActive { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<UserProfileDetail> UserProfileDetails { get; set; } = new List<UserProfileDetail>();

    public virtual UserType? UserType { get; set; }
}
