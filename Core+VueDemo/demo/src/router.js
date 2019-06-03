import Vue from "vue";
import Router from 'vue-router';

// 导入Home页面,这是导入页面的方式1
import home from './views/Home.vue';
import about from './views/About.vue';
import FormVuex from './views/FormVuex.vue';
import Login from './views/Login.vue';
import store from './store';

Vue.use(Router);

const routes = [
    {
        path: "/home",
        component: home,
        meta: {
            requireAuth: true // 添加该字段，表示进入这个路由是需要登录的
        }
    },
    {
        path: "/about",
        component: about
    },
    {
        path: '/',
        redirect: '/home'
    },
    {
        path: '/Vuex',
        name: 'Vuex',
        component: FormVuex
    },
    {
        path: '/Login',
        name: 'Login',
        component: Login
    }
]

var router = new Router({
    routes
})
var storeTemp = store;
router.beforeEach((to, from, next) => {
    if (!storeTemp.state.token) {  // 判断该路由是否需要登录权限
        storeTemp.commit("saveToken",window.localStorage.Token);
        // if (window.localStorage.Token&&window.localStorage.Token.length>=128) {  // 通过vuex state获取当前的token是否存在
        //     next();
        // }
        // else {
        //     next({
        //         path: '/login',
        //         query: {redirect: to.fullPath}  // 将跳转的路由path作为参数，登录成功后跳转到该路由
        //     })
        // }
    }
    else {
        next();
    }
})
export default router;

// export default new Router({
//     mode: "history",
//     base: process.env.BASE_URL,
//     routes: [
//         {
//             path: "/",
//             name: "home",
//             component: Home
//         },
//         {
//             path: "/about",//路径
//             name: "about",//名字
//             component: () => //导入页面的方式2
//                 import("./views/About.vue")
//         },
//         {
//             path: '/tourcard',
//             icon: 'android-settings',
//             name:'tourcard',
//             title:'父级路由',
//             component:Main,
//             children:[{
//                 path:'tourcard-saleOrder',
//                 title:'子路由',
//                 name:'tourcard-saleOrder',
//                 component:()=>
//                 import('@/views/Aourcard.vue')
//             }]
//         }
//     ]
// })