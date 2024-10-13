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
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Services
{
    public interface IUserService
    {
        Task<IBusinessResult> GetAllUser();
        Task<IBusinessResult> CreateUser(UserModel userModel);
        Task<IBusinessResult> UpdateUser(int Id, UserModel userModel);
        Task<IBusinessResult> GetUserById(int id);
        Task<IBusinessResult> DeleteUserbyId(int id);

        Task<IBusinessResult> SignIn(string email , string password);
    }
    public class UserService : IUserService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }
        public async Task<IBusinessResult> CreateUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            var createdUser = await _unitOfWork.UserRepository.CreateAsync(user);

            return new BusinessResult()
            {
                Data = _mapper.Map<UserModel>(createdUser),
                Message = "creating user successfully.",
                Status = 201
            };
        }

        public async Task<IBusinessResult> DeleteUserbyId(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return new BusinessResult()
            {
                Data = null,
                Message = "not found user.",
                Status = 404
            }; 

            await _unitOfWork.UserRepository.RemoveAsync(user);

            return new BusinessResult()
            {
                Data = _mapper.Map<UserModel>(user),
                Message = "deleting successfully.",
                Status = 204
            };
        }

        public async Task<IBusinessResult> GetAllUser()
        {   
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return new BusinessResult()
            {
                Data = users,
                Message = "getting users successfully.",
                Status =200
            };
        }

        public async Task<IBusinessResult> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null) return new BusinessResult()
            {
                Data = null,
                Status = 404,
                Message = "not found user."
            };

            return new BusinessResult()
            {
                Data = _mapper.Map<UserModel>(user),
                Message = "getting user successfully.",
                Status = 200
            };
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

            var users = await _unitOfWork.UserRepository.GetAllAsync(x => x.Email == email.ToLower().Trim() && x.Password == password);

            if (users.Count == 0)
                return new BusinessResult()
                {
                    Data = null,
                    Message = "email/password is incorrect.",
                    Status = 404
                };
            var user = users.FirstOrDefault();

            JwtSecurityToken accessJwtSecurityToken = JWTHelper.GetToken("USER", user.Id, user.Name, user.Email, 1,null);
            JwtSecurityToken refreshJwtSecurityToken = JWTHelper.GetToken("USER", user.Id, user.Name, user.Email, 3, null);

            SignInModel<UserModel> signInModel = new SignInModel<UserModel>()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessJwtSecurityToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshJwtSecurityToken),
                Data = _mapper.Map<UserModel>(user)
            };
            return new BusinessResult()
            {
                Data = signInModel,
                Status = 200,
                Message = "signing in successfully."
            };
        }

        public async Task<IBusinessResult> UpdateUser(int Id, UserModel userModel)
        {
            var obj = await _unitOfWork.UserRepository.GetByIdAsync(Id);
            if (obj == null) { return new BusinessResult(404, "not found user."); }
            _mapper.Map(userModel, obj);
            var updated = await _unitOfWork.UserRepository.UpdateAsync(obj);
            var result = _mapper.Map<UserModel>(obj);
            return new BusinessResult(200, "updating successfully.", result);
        }
    }
}
