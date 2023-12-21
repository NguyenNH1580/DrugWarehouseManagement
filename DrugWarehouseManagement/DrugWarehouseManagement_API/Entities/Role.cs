using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DrugWarehouseManagement_API.Entities
{
    public class Role:IdentityRole<Guid>
    {
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
