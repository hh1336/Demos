import store from '../store';
import router from '../router.js';

//api接口
var root = 'http://123.206.33.109:8081/api';

var axios = require('axios');

function toType(obj) {
  return {}.toString
  .call(obj)
  .match(/\s([a-zA-Z]+)/)[1]
  .toLowerCase();
}

function filterNull(o) {
  for (var key in o) {
    if (o[key] === null) {
      delete o[key]
    }
    if (toType(o[key]) === 'string') {
      o[key] = o[key].trim()
    } else if (toType(o[key]) === 'object') {
      o[key] = filterNull(o[key])
    } else if (toType(o[key]) === 'array') {
      o[key] = filterNull(o[key])
    }
  }
  return o
}

// http request 拦截器
axios.interceptors.request.use(
  config => {
    if (window.localStorage.Token&&window.localStorage.Token.length>=128) {//store.state.token 获取不到值？？
      // 判断是否存在token，如果存在的话，则每个http header都加上token
      config.headers.Authorization ="Bearer "+ window.localStorage.Token;
    }
    return config;
  },
  err => {
    return Promise.reject(err);
  }
);
// http response 拦截器
axios.interceptors.response.use(
  response => {
    return response;
  },
  error => {
    if (error.response) {
      switch (error.response.status) {
        case 401:
          // 返回 401 清除token信息并跳转到登录页面
          router.replace({
            path: "login",
            query: { redirect: router.currentRoute.fullPath }
          });
      }
    }
    return Promise.reject(error.response.data); // 返回接口返回的错误信息
  }
);



/*
  接口处理函数
  这个函数每个项目都是不一样的，我现在调整的是适用于
  https://cnodejs.org/api/v1 的接口，如果是其他接口
  需要根据接口的参数进行调整。参考说明文档地址：
  https://cnodejs.org/topic/5378720ed6e2d16149fa16bd
  主要是，不同的接口的成功标识和失败提示是不一致的。
  另外，不同的项目的处理方法也是不一致的，这里出错就是简单的alert
*/

function apiAxios(method, url, params, success, failure) {
  if (params) {
    params = filterNull(params)
  }
  axios({
    method: method,
    url: url,
    data: method === 'POST' || method === 'PUT' ? params : null,
    params: method === 'GET' || method === 'DELETE' ? params : null,
    //headers 是即将被发送的自定义请求头，还记得我们的jwt验证么，可以封装进来，注意!这里如果要添加 headers ，一定要是正确的值
    headers: { "Authorization": "Bearer xxxxxxx" },
    baseURL: root,
    withCredentials: false
  })
    .then(function (res) {
      success(res.data)
    })
    .catch(function (err) {
      let res = err.response
      if (err) {
        window.alert('api error, HTTP CODE: ' + res)
      }
    })
}

// 返回在vue模板中的调用接口
export default {
  get: function (url, params, success, failure) {
    return apiAxios('GET', url, params, success, failure)
  },
  post: function (url, params, success, failure) {
    return apiAxios('POST', url, params, success, failure)
  },
  put: function (url, params, success, failure) {
    return apiAxios('PUT', url, params, success, failure)
  },
  delete: function (url, params, success, failure) {
    return apiAxios('DELETE', url, params, success, failure)
  }
}
