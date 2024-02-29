#nullable disable
namespace TradingOrchid.Model.DTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Owner { get; set; }
        public int RoleID { get; set; }
    }
}
