using PrintShop.GlobalData.Data;

namespace PrintShop.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public ApiResponse EmailVerification();
    }
}
