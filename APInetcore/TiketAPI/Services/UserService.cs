using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.CustomModels;
using Repository.EF;
using Repository.Interface;
using Repository.Params;
using System;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.Interfaces;
using TiketAPI.Models;
using TiketAPI.Params;
using Method = System.Reflection.MethodBase;


namespace TiketAPI.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IRepository<User> baseRepository,
            IConfiguration config,ILoggerManager logger, IMapper mapper) : base(config, logger, mapper, baseRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseService<ListResult<UserInfo>>> GetUsersInfo(SearchUserParam param)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                ListResult<UserInfo> user =  await _userRepository.GetUsersInfo(param);
                return new ResponseService<ListResult<UserInfo>>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<ListResult<UserInfo>>(ex.Message);
            }
        }
        public async Task<bool> CheckPermission(Guid userId, string namePermission)
        {
            return await _userRepository.CheckPermission(userId, namePermission);
        }
        public async Task<ResponseService<ResponseLoginModel>> Login(string email, string password)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                User user = await _userRepository.GetByEmailAsync(email);
                if (user == null) return new ResponseService<ResponseLoginModel>("Email not exist").BadRequest();

                if (user.password == HashString.HashPasword(password))
                {
                    JwtService jwt = new JwtService(_config);
                    ResponseLoginModel userLogin = _mapper.Map<User, ResponseLoginModel>(user);
                    userLogin.access_token = jwt.GenerateSecurityToken(userLogin.email, false);
                    userLogin.refresh_token = jwt.GenerateSecurityToken(userLogin.email, true);
                    SessionStore.Set(Constants.SESSION_LOGIN, userLogin.email);
                    return new ResponseService<ResponseLoginModel>(userLogin);
                }
                return new ResponseService<ResponseLoginModel>("Wrong email or password").BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<ResponseLoginModel>(ex.Message);
            }
        }
        public async Task<ResponseService<UserModel>> Register(UserParam userModel)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                User userExist = await _userRepository.GetByEmailAsync(userModel.email);
                if (userExist != null) return new ResponseService<UserModel>("This mail is exist!").BadRequest();

                userModel.password = HashString.HashPasword(userModel.password);

                User user = _mapper.Map<UserParam, User>(userModel);
                user = CommonFunc.UpdateInfo<User>(user);
                await _userRepository.Create(user);
                UserModel userView = _mapper.Map<User, UserModel>(user);

                await EmailHelper.SendMail(_config, user.email, Constants.SUBJECT_REGISTER, Constants.CONTENT_REGISTER);

                return new ResponseService<UserModel>(userView);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<UserModel>(ex.Message);
            }
        }
        public async Task<ResponseService<bool>> ForgotPassword(string email)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                User user = await _userRepository.GetByEmailAsync(email);
                if (user == null) return new ResponseService<bool>("This email is not exist!").BadRequest();

                string otp = OTP.Generate();
                string url = $"{_config["UrlResetPassword"]}?code={otp}&email={email}";
                string content = $"{Constants.CONTENT_FORGOT_PASSWORD}{url} with code is {otp}" +
                    $" .Thank for using our service!";

                await _userRepository.Update(user.id, Pros("code", otp));

                await EmailHelper.SendMail(_config, email, Constants.SUBJECT_FORGOT_PASSWORD, content);                
                return new ResponseService<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<bool>(ex.Message);
            }
        }
        public async Task<ResponseService<bool>> ResetPassword(string code,string email, string password)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                User user = await _userRepository.GetByEmailAsync(email);
                if (user == null) return new ResponseService<bool>("This email is not exist!").BadRequest();
                if (user.code != code) return new ResponseService<bool>("This code is wrong!").BadRequest();

                password = HashString.HashPasword(password);
                await _userRepository.Update(user.id, Pros("password", password));
                return new ResponseService<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<bool>(ex.Message);
            }
        }
    }
}
