using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class Login_M
    {
        [Required]
        [StringLength(10)]
        public string UserId;
        [Required]
        [StringLength(20)]
        public string UserPsw;
    }
}