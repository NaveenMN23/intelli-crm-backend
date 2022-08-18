using ClosedXML.Excel;
using IntelliCRMAPIService.Attribute;
using IntelliCRMAPIService.DBContext;
using IntelliCRMAPIService.Model;
using IntelliCRMAPIService.Repository;
using System.Data;

namespace IntelliCRMAPIService.Services
{
    public class SuperAdminRepository : ISuperAdminRepository
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDBContext _applicationDBContext;

        public SuperAdminRepository(IUserDetailsRepository userDetailsRepository, IUserRepository userRepository, ApplicationDBContext applicationDBContext)
        {
            _userDetailsRepository = userDetailsRepository;
            _userRepository = userRepository;
            _applicationDBContext = applicationDBContext;
        }
        public async Task<bool> CreateCustomer(UserResponse userResponse)
        {
            return await SaveUserDetails(userResponse);

        }

        public async Task<bool> CreateSubAdmin(SubAdminResponse userResponse)
        {
            return await SaveSubAdminDetails(userResponse);
        }

        public async Task<UserResponse> GetCustomer(int userID)
        {
            return await GetUserDetails(userID);
        }

        public async Task<UserResponse> GetSubAdmin(int userID)
        {
            return await GetUserDetails(userID);
        }

        private async Task<bool> SaveUserDetails(UserResponse userResponse)
        {
            var checkExistinguser = _userRepository.FindByCondition(e => e.UserId == userResponse.UserId).FirstOrDefault();
            int userId;

            if (checkExistinguser == null)
            {
                var customer = new Users()
                {
                    AccountStatus = userResponse.AccountStatus.ToLower() == "active" ? 1 : 0,
                    ContactNumber = userResponse.ContactNumber,
                    Email = userResponse.Email,
                    FirstName = userResponse.FirstName,
                    LastName = userResponse.LastName,
                    Password = userResponse.Password,
                    Salt = userResponse.Salt,
                    AccountType = userResponse.AccountType,
                    RightsForCustomerAccount = userResponse.RightsForCustomerAccount,
                    CreatedBy = userResponse.RequestedBy,
                    CreatedDate = DateTime.Now,
                    Role = (Role)Enum.Parse(typeof(Role), userResponse.Role),
                    RoleName = userResponse.Role

                };
                var user = _userRepository.Create(customer);
                userId = user.UserId;
            }
            else
            {
                checkExistinguser.AccountStatus = userResponse.AccountStatus.ToLower() == "active" ? 1 : 0;
                checkExistinguser.ContactNumber = userResponse.ContactNumber;
                checkExistinguser.Email = userResponse.Email;
                checkExistinguser.FirstName = userResponse.FirstName;
                checkExistinguser.Salt = userResponse.Salt;
                checkExistinguser.LastName = userResponse.LastName;
                //checkExistinguser.Password = userResponse.Password;
                checkExistinguser.AccountType = userResponse.AccountType;
                checkExistinguser.RightsForCustomerAccount = userResponse.RightsForCustomerAccount;
                checkExistinguser.ModifiedDate = DateTime.Now;
                checkExistinguser.ModifiedBy = userResponse.RequestedBy;

                checkExistinguser.Role = (Role)Enum.Parse(typeof(Role), userResponse.Role);
                _userRepository.Update(checkExistinguser);

                userId = checkExistinguser.UserId;
            }

            var checkExistinguserdetails = _userDetailsRepository.FindByCondition(e => e.UserId_Fk == userResponse.UserId).FirstOrDefault();

            if (checkExistinguserdetails == null)
            {

                var customerDetails = new UserDetails()
                {
                    Address = userResponse.Address,
                    City = userResponse.City,
                    Coutry = userResponse.Country,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userResponse.RequestedBy,
                    CreditLimit = userResponse.CreditLimit,
                    SoareceviedAmount = userResponse.SoareceviedAmount,
                    State = userResponse.State,
                    UserId_Fk = userId
                };

                _userDetailsRepository.Create(customerDetails);
            }
            else
            {
                checkExistinguserdetails.Address = userResponse.Address;
                checkExistinguserdetails.City = userResponse.City;
                checkExistinguserdetails.Coutry = userResponse.Country;
                checkExistinguserdetails.CreditLimit = userResponse.CreditLimit;
                checkExistinguserdetails.SoareceviedAmount = userResponse.SoareceviedAmount;
                checkExistinguserdetails.State = userResponse.State;
                checkExistinguserdetails.ModifiedDate = DateTime.Now;
                checkExistinguserdetails.ModifiedBy = userResponse.RequestedBy;

                _userDetailsRepository.Update(checkExistinguserdetails);
            }

            return true;
        }
        private async Task<bool> SaveSubAdminDetails(SubAdminResponse userResponse)
        {
            var checkExistinguser = _userRepository.FindByCondition(e => e.UserId == userResponse.UserId).FirstOrDefault();
            int userId;

            if (checkExistinguser == null)
            {
                var customer = new Users()
                {
                    AccountStatus = userResponse?.AccountStatus.ToLower() == "active" ? 1 : 0,
                    ContactNumber = userResponse.ContactNumber,
                    Email = userResponse.Email,
                    FirstName = userResponse.FirstName,
                    LastName = userResponse.LastName,
                    Password = userResponse.Password,
                    Salt = userResponse.Salt,
                    AccountType = userResponse.AccountType,
                    RightsForCustomerAccount = userResponse.RightsForCustomerAccount,
                    CreatedBy = userResponse.RequestedBy,
                    CreatedDate = DateTime.Now,
                    Role = (Role)Enum.Parse(typeof(Role), userResponse.Role),
                    RoleName = userResponse.Role

                };
                var user = _userRepository.Create(customer);
                userId = user.UserId;
            }
            else
            {
                checkExistinguser.AccountStatus = userResponse.AccountStatus.ToLower() == "active" ? 1 : 0;
                checkExistinguser.ContactNumber = userResponse.ContactNumber;
                checkExistinguser.Email = userResponse.Email;
                checkExistinguser.FirstName = userResponse.FirstName;
                checkExistinguser.Salt = userResponse.Salt;
                checkExistinguser.LastName = userResponse.LastName;
                //checkExistinguser.Password = userResponse.Password;
                checkExistinguser.AccountType = userResponse.AccountType;
                checkExistinguser.RightsForCustomerAccount = userResponse.RightsForCustomerAccount;
                checkExistinguser.ModifiedDate = DateTime.Now;
                checkExistinguser.ModifiedBy = userResponse.RequestedBy;
                checkExistinguser.RoleName = userResponse.Role;

                checkExistinguser.Role = (Role)Enum.Parse(typeof(Role), userResponse.Role);
                _userRepository.Update(checkExistinguser);

                userId = checkExistinguser.UserId;
            }

            return true;
        }
        private async Task<UserResponse> GetUserDetails(int userID)
        {
            var checkExistinguserdetails = _userDetailsRepository.FindByCondition(e => e.UserId_Fk == userID).FirstOrDefault();
            var checkExistinguser = _userRepository.FindByCondition(e => e.UserId == userID).FirstOrDefault();

            var customerResponse = new UserResponse
            {
                UserId = checkExistinguser.UserId,
                AccountStatus = checkExistinguser.AccountStatus == 1 ? "Active" :"Hold",
                ContactNumber = checkExistinguser.ContactNumber,
                Email = checkExistinguser.Email,
                FirstName = checkExistinguser.FirstName,
                LastName = checkExistinguser.LastName,
                AccountType = checkExistinguser.AccountType,
                Address = checkExistinguserdetails?.Address,
                City = checkExistinguserdetails?.City,
                Country = checkExistinguserdetails?.Coutry,
                RightsForCustomerAccount = checkExistinguser.RightsForCustomerAccount,
                CreditLimit = checkExistinguserdetails?.CreditLimit,
                SoareceviedAmount = checkExistinguserdetails?.SoareceviedAmount,
                State = checkExistinguserdetails?.State
            };

            return customerResponse;
        }

        public async Task<IList<UserResponse>> GetAllUserDetails(int userType)
        {
           return _applicationDBContext.Users.Where(u => u.AccountType == userType ).Join(_applicationDBContext.UserDetails, i => i.UserId, o => o.UserId_Fk,
                    (i, o) => new UserResponse()
                    {
                        UserId = i.UserId,
                        AccountStatus = i.AccountStatus == 1 ? "Active" : "Hold",
                        ContactNumber = i.ContactNumber,
                        Email = i.Email,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        AccountType = i.AccountType,
                        Address = o.Address,
                        City = o.City,
                        Country = o.Coutry,
                        RightsForCustomerAccount = i.RightsForCustomerAccount,
                        CreditLimit = o.CreditLimit,
                        SoareceviedAmount = o.SoareceviedAmount,
                        State = o.State
                    }
                ).ToList();

        }

        public async Task<IList<UserResponse>> GetAllSubAdminUserDetails(int userType)
        {
            return _applicationDBContext.Users.Where(u => u.AccountType == userType).Select( i => new UserResponse()
                     {
                         UserId = i.UserId,
                         AccountStatus = i.AccountStatus == 1 ? "Active" : "Hold",
                         ContactNumber = i.ContactNumber,
                         Email = i.Email,
                         FirstName = i.FirstName,
                         LastName = i.LastName,
                         AccountType = i.AccountType,
                         RightsForCustomerAccount = i.RightsForCustomerAccount,

                     }
                 ).ToList();

        }
    }
}
