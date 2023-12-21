using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DrugWarehouseManagement_API.Entities
{
    public class User :IdentityUser<Guid>
    {
        [MaxLength(256)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(256)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(256)]
        public string? FullName { get; set; }

        [MaxLength(256)]
        [Required]
        public override string UserName{ get; set; }
        
        [MaxLength(256)]
        [Required]
        public override string Email { get; set; }

        [MaxLength()]
        [Required]
        public override string PasswordHash { get; set; }

    }
}
