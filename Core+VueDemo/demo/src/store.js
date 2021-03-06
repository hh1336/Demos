import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
  // 初始化的数据
  state: {
    formDatas: null,//定义一个变量 formDatas
    token:'1'
  },
  // 改变state里面的值得方法
  mutations: {
    getFormData(state, data) {
      state.formDatas = data;
    },
    saveToken(state,data){
      state.token = data;
      window.localStorage.setItem("Token",data);//保存到了 localStorage 中
    }
  }
});
// 输出模块
export default store;