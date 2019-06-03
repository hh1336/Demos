import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

Vue.use(ElementUI);

// 导入api并绑定到全局
import api from './api/http';
Vue.prototype.$api = api;

Vue.config.productionTip = false

// 将变量挂载到#app上
new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
