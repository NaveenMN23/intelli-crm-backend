using IntelliCRMAPIService.Model;

namespace IntelliCRMAPIService.BL
{
    public interface ISuperAdminBL
    {
        Task<bool> CreateCustomer(UserResponse userResponse);
        Task<bool> CreateSubAdmin(SubAdminResponse userResponse);
        Task<UserResponse> GetCustomer(int userID);
        Task<UserResponse> GetSubAdmin(int userID);
        Task<IList<UserResponse>> GetAllUserDetails(int userType);
    }
}
