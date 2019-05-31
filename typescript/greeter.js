"use strict";
//引入一个单独的ts文件
/// <reference path = "namespaceTest.ts" />
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
var ex = require("./export");
// 定义一个命名空间
var TestNameSpace;
(function (TestNameSpace) {
    // 向外暴露一个类或接口
    var Color = /** @class */ (function () {
        function Color() {
            this.Red = "Red";
        }
        return Color;
    }());
    TestNameSpace.Color = Color;
})(TestNameSpace || (TestNameSpace = {}));
//一个类
var Common = /** @class */ (function () {
    function Common() {
        //受保护的protected，只有本身和被继承的类可以访问
        this.cName = "Common";
    }
    Common.prototype.GetCName = function () {
        return this.cName;
    };
    return Common;
}());
//继承
var custmer = {
    sayHi: function () {
        return "实现接口";
    }
};
var user = { firstName: "张三", lastName: "李四" };
// 定义一个类，支持多继承
var Student = /** @class */ (function (_super) {
    __extends(Student, _super);
    //构造函数
    function Student(firstName, midel, lastName) {
        var _this = _super.call(this) || this;
        _this.firstName = firstName;
        _this.midel = midel;
        _this.lastName = lastName;
        _this.chilrenName = _super.prototype.GetCName.call(_this);
        _this.fullName = "\u7B2C\u4E00\u4E2A\u540D\u5B57\u53EB:" + firstName + " ,\u4E2D\u95F4\u7684\u540D\u5B57\u53EB:" + midel + ",\u6700\u540E\u4E00\u4E2A\u540D\u5B57\u53EB:" + lastName;
        return _this;
    }
    //实现接口的方法
    Student.prototype.sayHi = function () {
        return "类的接口方法";
    };
    // 一个普通的方法
    Student.prototype.name = function () {
        console.log("无返回值的方法,父类的字段+" + this.chilrenName);
    };
    // 一个静态的带参数的求和方法
    Student.prototype.sum = function (x, y) {
        if (y === void 0) { y = 0.3; }
        return x + y;
    };
    Student.staticMethod = function () {
        console.log("静态的方法");
    };
    //调用方法返回一个异常信息,私有方法
    Student.prototype.error = function (msg) {
        throw new Error(msg);
    };
    return Student;
}(Common));
// 约束变量为string类型
var hello = "你好啊";
// 将anyAttr标记为可接收任意数据类型的变量
var anyAttr = 1;
//约束manyAttr的类型只能为数字和boolean
var manyAttr = true;
// 循环
var aArr = [1, 2, 3, 4, 5, 6];
for (var s in aArr) {
    console.log(aArr[s]);
}
var list = [4, 5, 6];
list.forEach(function (val, idx, array) {
    // val: 当前值
    // idx：当前index
    // array: Array
});
list.every(function (val, idx, array) {
    // val: 当前值
    // idx：当前index
    // array: Array
    return true; // Continues
    // Return false will quit the iteration
});
// for(;;) { 
//     console.log("这段代码会不停的执行") 
// }
// instanceof 运算符用于判断对象是否是指定的类型，如果是返回 true，否则返回 false。
// var isPerson = obj instanceof Person; 
// 方法,可以接收一个string类型的name和多个number类型的数字
function test(name) {
    var restNumber = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        restNumber[_i - 1] = arguments[_i];
    }
    return "\u4F20\u5165\u4E86" + name + "\u548C" + restNumber;
}
function disp(x, y) {
    console.log(x + y);
}
//匿名函数自调用
(function () {
    var x = "Hello!!";
    console.log(x);
})();
// 创建一个对象
var stu = new Student("张三", "李四", "王五");
// 调用对象的方法
stu.name();
console.log(hello);
// 断言
console.log(hello);
console.log(stu.sum(0.1, 0.2) > 0 && 1);
console.log(stu.sum(0.1, 0.2) > 0 || 1);
console.log(test("一个张三", 1, 2, 3, 4, 5));
disp("1");
disp(1, 2);
console.log(custmer.sayHi());
Student.staticMethod();
//调用命名空间中的类
var testcolor = new TestNameSpace.Color();
console.log(testcolor.Red);
//调用引入的dilog类的alert方法
ex.dilog.alert();
console.log($("div"));
