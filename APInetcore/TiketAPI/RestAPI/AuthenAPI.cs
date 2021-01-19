using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.Models;

namespace TiketAPI.RestAPI
{
    public class AuthenAPI
    {
        private readonly RequestAPI _requestAPI;
        private HttpResponseMessage _response;
        private readonly string PATH_PRE_API = "permission/";

        public AuthenAPI(string token)
        {
            _requestAPI = new RequestAPI(null, Constants.CONF_HOST_CRM, token);
        }
        public async Task<BaseResponse<UserModel>> ValidateToken()
        {
            BaseResponse<UserModel> resAuthen = new BaseResponse<UserModel>();
            try
            {
                _response = await _requestAPI.client.PostAsJsonAsync(PATH_PRE_API + "validate", string.Empty);
                if (_response.IsSuccessStatusCode)
                {
                    resAuthen = await _response.Content.ReadAsAsync<BaseResponse<UserModel>>();
                    resAuthen.success = true;
                }
                else
                {
                    resAuthen.success = false;
                    resAuthen.mess = "Authen fail!";
                }
                resAuthen.statusCode = _response.StatusCode;

            }
            catch (Exception ex)
            {
                resAuthen.success = false;
                resAuthen.mess = ex.Message;
            }
            return resAuthen;
        }
    }
}
