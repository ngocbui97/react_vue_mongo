﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Repository.CustomModels;
using Repository.EF;
using Repository.Interface;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.Interfaces;
using TiketAPI.Models;
using Method = System.Reflection.MethodBase;
using Profile = Repository.EF.Profile;

namespace TiketAPI.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepositoty _userRepositoty;
        private readonly IProfileRepository _profileRepository;

        public UserService(IUserRepositoty userRepositoty, IProfileRepository profileRepository, IConfiguration config,
            ILoggerManager logger, IMapper mapper) : base(config, logger, mapper)
        {
            _userRepositoty = userRepositoty;
            _profileRepository = profileRepository;

        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepositoty.AddAsync(user);
        }

        public async Task<bool> CheckPermission(int userId, string namePermission)
        {
            return await _userRepositoty.CheckPermission(userId, namePermission);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepositoty.DeleteAsync(id);
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepositoty.GetByIdAsync(id);
        }

        public async Task<ResponseService<ListResult<User>>> GetListAsync(QueryParram parram)
        {
            ListResult<User> users = await _userRepositoty.GetListAsync(parram);
            return new ResponseService<ListResult<User>>(users);
        }

        public async Task<ResponseService<UserLoginModel>> Login(string email, string password)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                User user = await _userRepositoty.GetByEmailAsync(email);
                if (user == null) return new ResponseService<UserLoginModel>("User not exist");
                if (user.Password == HashMD5.HashStringMD5(password)) 
                {
                    JwtService jwt = new JwtService(_config);
                    UserLoginModel userLogin = _mapper.Map<User, UserLoginModel>(user);
                    userLogin.AccessToken = jwt.GenerateSecurityToken(userLogin.Email, false);
                    userLogin.RefreshToken = jwt.GenerateSecurityToken(userLogin.Email, true);            
                    return new ResponseService<UserLoginModel>(userLogin);
                }
                return new ResponseService<UserLoginModel>("Wrong email or password");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<UserLoginModel>(ex.Message);
            }
        }

        public async Task<ResponseService<User>> Register(UserModel userModel)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                User userExist = await _userRepositoty.GetByEmailAsync(userModel.Email);
                if (userExist != null) return new ResponseService<User>("This mail is exist in system!");

                User user = _mapper.Map<UserModel, User>(userModel);
                user.Password = HashMD5.HashStringMD5(user.Password);
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.Active = true;
                var userInfo = await _userRepositoty.AddAsync(user);

                Profile profile = new Profile();
                profile.Status = Constants.DEFAULT_STATUS_PROFILE;
                profile.UserId = userInfo.Id;
                profile.CreatedAt = DateTime.Now;
                profile.UpdatedAt = DateTime.Now;
                profile.Active = true;
                await _profileRepository.AddAsync(profile);

                return new ResponseService<User>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<User>(ex.Message);
            }
           
        }

        public async Task<User>Update(User user)
        {
            return await _userRepositoty.UpdateAsync(user);
        }

    }
}
