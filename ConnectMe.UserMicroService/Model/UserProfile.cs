using ConnectMe.UserMicroService.Data;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ConnectMe.UserMicroService.Model
{
    public class UserProfile
    {
        /*
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        public DateTime dateofbirth { get; set; }

        public string gender { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; } = string.Empty;
        public string PasswordConfirmed { get; set; }

        public bool IsActive { get; set; }
        */

        ////public int UserProfileId { get; set; }

        [JsonIgnore]
        public int UserTypeId { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        [MaxLength(1)]
        public string? Gender { get; set; }

        [Required]
        public bool? IsActive { get; set; }

        [JsonIgnore]
        public int? StatusId { get; set; }

        [JsonIgnore]
        public ICollection<UserProfileDetail> UserProfileDetails { get; set; } = new List<UserProfileDetail>();


        public UserType UserType { get; set; } = null!;

    }
}
