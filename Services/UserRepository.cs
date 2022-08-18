using IntelliCRMAPIService.DBContext;
using IntelliCRMAPIService.Repository;

namespace IntelliCRMAPIService.Services
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserRepository(ApplicationDBContext applicationDBContext)
            :base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
            //_appSettings = appSettings.Value;
        }
        
    }
}
