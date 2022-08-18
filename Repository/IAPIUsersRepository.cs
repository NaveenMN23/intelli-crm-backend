using IntelliCRMAPIService.AuthModels;

namespace IntelliCRMAPIService.Repository
{
    public interface IAPIUsersRepository
    {
        Task<Users> ValidUser(AuthUser authUser);
        Task<Users> GetUserByEmail(string email);
    }
}
