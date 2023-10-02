using Microsoft.AspNetCore.Identity;

namespace TPBitwise.Models
{
    public class AppUsuario : IdentityUser
    {
        public string Nombre { get; set; }
    }
}
