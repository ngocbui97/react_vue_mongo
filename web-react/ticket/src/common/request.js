import axios from 'axios';
import queryString from 'query-string';
import LocalStorage from './localStorage';
import * as constants from '../constants';

const localStorageService = LocalStorage.getService();

const request = axios.create({
  baseURL: constants.BASE_URL_API,
  headers: {
    'content-type': 'application/json'
  },
  paramsSerializer: (params) => queryString.stringify(params)
});

// Add a request interceptor
request.interceptors.request.use(
  (config) => {
    const token = localStorageService.getAccessToken();
    if (token) {
      config.headers['Authorization'] = 'Bearer ' + token;
    }
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

//Add a response interceptor
request.interceptors.response.use(
  (response) => {
    if (response && response.data) {
      return response.data;
    }
    return response;
  },
  (error) => {
    const originalRequest = error.config;

    // if (
    //   error.response.status === 401 &&
    //   originalRequest.url === 'http://13.232.130.60:8081/v1/auth/token'
    // ) {
    //   router.push('/login');
    //   return Promise.reject(error);
    // }

    if (error.response.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true;
      const refreshToken = localStorageService.getRefreshToken();
      return axios
        .post('/auth/token', {
          refresh_token: refreshToken
        })
        .then((res) => {
          if (res.status === 201) {
            localStorageService.setToken(res.data);
            axios.defaults.headers.common['Authorization'] =
              'Bearer ' + localStorageService.getAccessToken();
            return axios(originalRequest);
          }
        });
    }
    return Promise.reject(error);
  }
);
export default request;
