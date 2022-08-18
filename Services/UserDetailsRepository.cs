using IntelliCRMAPIService.DBContext;
using IntelliCRMAPIService.Repository;

namespace IntelliCRMAPIService.Services
{
    public class UserDetailsRepository : RepositoryBase<UserDetails>, IUserDetailsRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserDetailsRepository(ApplicationDBContext applicationDBContext)
            :base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
            //_appSettings = appSettings.Value;
        }
        
    }
}
