using AutoMapper;
using DineinEasy.Data.Models;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Untils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Services
{

    public interface ICustomerService
    {
        Task<IBusinessResult> CreateCustomer(CustomerModel model);
        Task<IBusinessResult> UpdateCustomer(CustomerModel customer, Guid id);
        Task<IBusinessResult> DeleteCustomer(Guid id);
        Task<IBusinessResult> GetAllCustomers();
        Task<IBusinessResult> GetCustomerById(Guid id);
        Task<IBusinessResult> SignIn(string email, string password);
        Task<IBusinessResult> ChangeStatus(int status, Guid id);
        Task<IBusinessResult> DashboardCustomer();
    }
    public class CustomerService : ICustomerService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CustomerService(IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> CreateCustomer(CustomerModel model)
        {
            var obj = _mapper.Map<Customer>(model);
            obj.Status = true;
            obj.CreatedAt = DateTime.Now;
            obj.UpdatedAt = DateTime.Now;
            var created = await _unitOfWork.CustomerRepository.CreateAsync(obj);
            var result = _mapper.Map<CustomerModel>(created);
            return new BusinessResult(200, "Create successfully", result);
        }

        public async Task<IBusinessResult> DeleteCustomer(Guid id)
        {
            var obj = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Customer"); }
            var result = await _unitOfWork.CustomerRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Delete Customer by Id successfully", result);
        }

        public async Task<IBusinessResult> GetAllCustomers()
        {
            var list = await _unitOfWork.CustomerRepository.GetAllAsync();
            var data = _mapper.Map<List<CustomerModel>>(list);
            var result = new BusinessResult(200, "Get All Customer", data);
            return result;
        }

        public async Task<IBusinessResult> GetCustomerById(Guid id)
        {
            var obj = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Customer"); }
            var result = _mapper.Map<CustomerModel>(obj);
            return new BusinessResult(200, "Get Customer by Id successfully", result);
        }

        public async Task<IBusinessResult> UpdateCustomer(CustomerModel customer, Guid id)
        {
            var obj = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (obj == null) { return new BusinessResult(404, "Can not find Customer"); }
  
            customer.UpdatedAt = DateTime.Now.Date;
            _mapper.Map(customer, obj);
            var updated = await _unitOfWork.CustomerRepository.UpdateAsync(obj);
            var result = _mapper.Map<CustomerModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }

        public async Task<IBusinessResult> SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return new BusinessResult()
                {
                    Data = null,
                    Message = "email is empty.",
                    Status = 400
                };

            if (string.IsNullOrEmpty(password))
                return new BusinessResult()
                {
                    Data = null,
                    Message = "password is empty.",
                    Status = 400
                };

            var customers = await _unitOfWork.CustomerRepository.GetAllAsync(x => x.Email == email.ToLower().Trim() && x.Password == password);

            if (customers.Count == 0)
                return new BusinessResult()
                {
                    Data = null,
                    Message = "email/password is incorrect.",
                    Status = 404
                };
            var customer = customers.FirstOrDefault();

            JwtSecurityToken accessJwtSecurityToken = JWTHelper.GetToken("CUSTOMER", null, customer.Name, customer.Email, 1, customer.Id);
            JwtSecurityToken refreshJwtSecurityToken = JWTHelper.GetToken("CUSTOMER", null, customer.Name, customer.Email, 3, customer.Id);

            SignInModel<CustomerModel> signInModel = new SignInModel<CustomerModel>()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessJwtSecurityToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshJwtSecurityToken),
                Data = _mapper.Map<CustomerModel>(customer)
            };
            return new BusinessResult()
            {
                Data = signInModel,
                Status = 200,
                Message = "signing in successfully."
            };

        }

        public async Task<IBusinessResult> ChangeStatus(int status, Guid id)
        {
            var obj = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (obj == null) { return new BusinessResult(404, "Can not find Customer"); }
            obj.Status = status == 1;

            var updated = await _unitOfWork.CustomerRepository.UpdateAsync(obj);
            var result = _mapper.Map<CustomerModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }

        public async Task<IBusinessResult> DashboardCustomer()
        {
            var obj = await _unitOfWork.CustomerRepository.GetNewCustomers();
            return new BusinessResult(200, "Get Dashboard Successfully", obj);
        }


    }
}
