using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugWarehouseManagement_ViewModel.ViewModels.User
{
    public class CreateUserViewModel
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
        public  string UserName { get; set; }

        [MaxLength(256)]
        [Required]
        [EmailAddress(ErrorMessage = "This email is invalid")]
        public string Email { get; set; }

        [MaxLength()]
        [Required]
        public string PasswordHash { get; set; }
    }
}
