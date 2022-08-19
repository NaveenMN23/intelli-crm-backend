using IntelliCRMAPIService.DBContext;
using IntelliCRMAPIService.Repository;

namespace IntelliCRMAPIService.Services
{
    public class CustomerProduct : RepositoryBase<Users>, IUserRepository
    {
        private readonly PostgresDBContext _applicationDBContext;
        public CustomerProduct(PostgresDBContext applicationDBContext)
            :base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        
    }
}
