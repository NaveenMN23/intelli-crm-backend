using IntelliCRMAPIService.BL;
using IntelliCRMAPIService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntelliCRMAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly ILogger<SuperAdminController> _logger;
        private readonly ISuperAdminBL _superAdminBL;

        public SuperAdminController(ILogger<SuperAdminController> logger, ISuperAdminBL superAdminBL)
        {
            _logger = logger;
            _superAdminBL = superAdminBL;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<bool> CreatCustomer([FromForm] UserResponse userResponse)
        {
            var result = await _superAdminBL.CreateCustomer(userResponse);

            return result;
        }

        [HttpPost]
        [Route("CreatSuperAdmin")]
        public async Task<bool> CreatSuperAdmin([FromForm] SubAdminResponse userResponse)
        {
            var result = await _superAdminBL.CreateSubAdmin(userResponse);

            return result;
        }

        [HttpGet]
        [Route("GetCustomerDetails/{customerId}")]
        public async Task<UserResponse> GetCustomerDetails(int customerId)
        {
            var result = await _superAdminBL.GetCustomer(customerId);

            return result;
        }

        [HttpGet]
        [Route("GetSubAdminDetails/{customerId}")]
        public async Task<UserResponse> GetSubAdminDetails(int customerId)
        {
            var result = await _superAdminBL.GetSubAdmin(customerId);

            return result;
        }

        [HttpGet]
        [Route("GetAllUserDetails/{userType}")]
        public async Task<IList<UserResponse>> GetAllUserDetails(int userType)
        {
            var result = await _superAdminBL.GetAllUserDetails(userType);

            return result;
        }
    }
}
