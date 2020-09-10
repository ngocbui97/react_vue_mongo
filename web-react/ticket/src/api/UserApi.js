import request from '../common/request';

class UserApi {
  getAll = (params) => {
    const url = '/products';
    return request.get(url, { params });
  };
}
const userApi = new UserApi();
export default userApi;
