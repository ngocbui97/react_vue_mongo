import request from '../common/request';

const UserAPI = {
  signIn: (params) => {
    const url = '/user/login';
    return request.post(url, params);
  }
};

export default UserAPI;
