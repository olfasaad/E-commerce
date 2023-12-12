using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace E_commerce.Models.ViewModels

{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}