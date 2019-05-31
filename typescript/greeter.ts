//引入一个单独的ts文件
/*/// <reference path = "namespaceTest.ts" />*/


// import ex =  require('./export');

// 定义一个命名空间
namespace TestNameSpace{
    // 向外暴露一个类或接口
    export class Color{
        Red:string = "Red";
    }
}


// 一个接口
interface IPerson {
    // 返回值为string类型
    sayHi: () => string;
}
//一个类
class Common{
    //受保护的protected，只有本身和被继承的类可以访问
    private cName:string = "Common";
    public GetCName():string{
        return this.cName;
    }
}
//继承
var custmer:IPerson ={
    sayHi:():string => {
        return "实现接口";
    }
}

let user = { firstName: "张三", lastName: "李四" };

// 定义一个类，支持多继承
class Student extends Common implements IPerson/*,onetest.oneTes*/ {
    //实现另一个文件中的属性
    TestRed: string;
    //实现接口的方法
    sayHi():string{
        return "类的接口方法";
    }

    fullName: string;
    chilrenName:string;
    //构造函数
    constructor(public firstName, public midel, public lastName) {
        super();
        this.chilrenName = super.GetCName();
        this.fullName = `第一个名字叫:${firstName} ,中间的名字叫:${midel},最后一个名字叫:${lastName}`;
    }
    // 一个普通的方法
    name(): void {
        console.log("无返回值的方法,父类的字段+" + this.chilrenName);
    }
    // 一个静态的带参数的求和方法
    sum(x: number, y: number = 0.3): number {
        return x + y;
    }
    static staticMethod():void{
        console.log("静态的方法");
    }
    //调用方法返回一个异常信息,私有方法
    private error(msg: string): never {
        throw new Error(msg);
    }
}

// 约束变量为string类型
const hello: string = "你好啊";
// 将anyAttr标记为可接收任意数据类型的变量
let anyAttr: any = 1;
//约束manyAttr的类型只能为数字和boolean
let manyAttr: number | boolean = true;

// 循环
let aArr: Array<Number> = [1, 2, 3, 4, 5, 6];
for (var s in aArr) {
    console.log(aArr[s]);
}
let list = [4, 5, 6];
list.forEach((val, idx, array) => {
    // val: 当前值
    // idx：当前index
    // array: Array
});
list.every((val, idx, array) => {
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
function test(name: string, ...restNumber: Number[]): string {

    return `传入了${name}和${restNumber}`;
}
//函数重载
function disp(s1: string): void;
function disp(n1: number, s1: number): void;
function disp(x: any, y?: any): void {
    console.log(x + y);
}

//匿名函数自调用
(function () {
    var x = "Hello!!";
    console.log(x)
})();

// 创建一个对象
var stu = new Student("张三", "李四", "王五");
// 调用对象的方法
stu.name();
console.log(hello);
// 断言
console.log(hello as string);
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
//ex.dilog.alert();
//编译时不对$号进行编译和检查，会忽略，这样我们就可以通过$来使用jQuery了
declare var $:(selector : string) => any;
declare var jQuery:(selector : string) => any;
console.log($("div"))
$("div").css("background","red");