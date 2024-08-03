![](./assets/0.png)

# rookie-csharp

学习入门csharp的记录

**参考: [https://www.runoob.com/csharp/csharp-tutorial.html](https://www.runoob.com/csharp/csharp-tutorial.html)**

> [!TIP]
>
> - C#的构想很接近C++，但是它和JAVA更相似，因为我是写C++比较多，所以这个记录会记录我对C#的，从C++角度的一些理解。
>
> - 如果想通过本文档学习了解C#，需要先熟练编写C++代码，理解面向对象编程思想。
>
> - 本文档提供简单入门，深入了解需要通过项目来学习，通过本文档是不够的。

## 环境

- **[Visual Studio](https://visualstudio.microsoft.com/)**

***

下面代码在文件`Lesson1.cs`中。

## 简单入门

首先我用的目录结构:

`src` 里面是每一章节的代码 `Lessonx.cs`。

`Main.cs`:

```cs
// program entry
namespace rookie_csharp
{
    class Run
    {
        static void Main(string[] args)
        {
            Lesson1 t1 = new Lesson1();
            t1.Test1();
        }
    }
}
```

然后在`Src/Lesson1.cs`里定义一些类和接口。

**先来打印一个`hello world`.**

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Lesson1
{
    internal void Test1()
    {
        // print an hello world
        Console.WriteLine("hello world");
        Console.ReadKey();
    }
}
```

程序的第一行 `using System;` - `using` 关键字用于在程序中包含 `System` 命名空间。 一个程序一般有多个 `using` 语句, 相当于C++的 `using namespace std;`

后面`Test1`就是一个函数了，和C++一样，如果不是`static`方法，需要创建对象才能调用，如果是`static`方法，可以直接通过类名调用。

```csharp
Console.WriteLine("hello world");
```

就是打印语句，`Console`是System命名空间的，要包含上才能用。

```csharp
Console.ReadKey();
```

是针对于VSStudio的，防止命令行快速闪退。

> [!NOTE]
>
> - C# 是大小写敏感的。
> - 所有的语句和表达式必须以分号（;）结尾。
> - 程序的执行从 Main 方法开始。
> - 与 Java 不同的是，文件名可以不同于类的名称。

**编写一个简单的类**

```cs
internal class Lesson1
{
    internal class Circle
    {
        public int __r;
        public int __x;
        public int __y;
        public Circle() { }
        public Circle(int r, int x, int y)
        {
            this.__r = r;
            __x = x;
            __y = y;
        }
        public double Area() { return 3.14 * __r * __r; }
        public void ShowFields()
        {
            Console.WriteLine("r: {0}", __r);
            Console.WriteLine("x: {0}", __x);
            Console.WriteLine("y: {0}", __y);
        }
    }
    internal void Test1()
    {
        // print an hello world
        Console.WriteLine("hello world");
        Console.ReadKey();
    }
    internal void Test2() {
        Circle cir = new Circle();
        cir.ShowFields();
        Circle cir2 = new Circle(1, 2, 3);
        cir2.ShowFields();
        Console.WriteLine("Area: {0}", cir2.Area());
    }
}
```

![](./assets/1.png)

只要会一门面向对象语言其实上面的代码都是很好懂的。

> [!TIP]
>
> - 构造函数要带上`public`不然外面访问不到（细节还没学，后面会详细学）
> - 和C++一样，如果显示编写了构造函数，默认构造就不会自动构造，需要提供无参的构造，不然就不能用`new Circle()`来构造。
> - 如果不初始化字段，会调用自己的构造函数。上面的`int`就会默认构造为0。

## 顶级语句

一句话：可以想像写Python一样写。

**特点：**

- **无需类或方法**：顶级语句允许你直接在文件的顶层编写代码，无需定义类或方法。
- **文件作为入口点**：包含顶级语句的文件被视为程序的入口点，类似于 C# 之前的 `Main` 方法。
- **自动 `Main` 方法**：编译器会自动生成一个 `Main` 方法，并将顶级语句作为 `Main` 方法的主体。
- **支持局部函数**：尽管不需要定义类，但顶级语句的文件中仍然可以定义局部函数。
- **更好的可读性**：对于简单的脚本或工具，顶级语句提供了更好的可读性和简洁性。
- **适用于小型项目**：顶级语句非常适合小型项目或脚本，可以快速编写和运行代码。
- **与现有代码兼容**：顶级语句可以与现有的 C# 代码库一起使用，不会影响现有代码。

> [!WARNING]
>
> - **文件限制：**顶级语句只能在一个源文件中使用。如果在一个项目中有多个使用顶级语句的文件，会导致编译错误。
> - **程序入口：**如果使用顶级语句，则该文件会隐式地包含 Main 方法，并且该文件将成为程序的入口点。
> - **作用域限制：**顶级语句中的代码共享一个全局作用域，这意味着可以在顶级语句中定义的变量和方法可以在整个文件中访问。

```cs
Console.WriteLine("top level statement");
int a = 10;
var b = 20;
Console.WriteLine("a: {0}, b:{1}, a+b:{2}", a, b, a + b);
SayHello.Say(); // static方法用类名调用
class SayHello
{
    public static void Say() { Console.WriteLine("hello"); }
}
// program entry
#if false
namespace rookie_csharp
{
    class Run
    {
        static void Main(string[] args)
        {
            Lesson1 t1 = new Lesson1();
            t1.Test2();
        }
    }
}
#endif
```

![](./assets/2.png)

- `var`跟`auto`一样，推导类型
- `Console.WriteLine("a: {0}, b:{1}, a+b:{2}", a, b, a + b);`就是可变参数，跟`printf`一个道理，012表示第123个参数，看例子就能懂
- 可以像C++一样用条件编译

## 类型

### 值类型

```cs
internal class DataType {
    public bool bool_data;
    public byte byte_data;
    public char char_data;
    public decimal decimal_data;
    public double double_data;
    public float float_data;
    public int int_data;
    public long long_data;
    public sbyte sbyte_data;
    public short short_data;
    public uint uint_data;
    public ulong ulong_data;
    public ushort ushort_data;
}
internal void Test3()
{
    // 数据类型
    DataType dt = new DataType();
    Console.WriteLine("bool type, default: {0}, type size: {1}", dt.bool_data, sizeof(bool));
    Console.WriteLine("byte type, default: {0}, type size: {1}", dt.byte_data, sizeof(byte));
    Console.WriteLine("char type, default: {0}, type size: {1}", dt.char_data, sizeof(char));
    Console.WriteLine("decimal type, default: {0}, type size: {1}", dt.decimal_data, sizeof(decimal));
    Console.WriteLine("double type, default: {0}, type size: {1}", dt.double_data, sizeof(double));
    Console.WriteLine("float type, default: {0}, type size: {1}", dt.float_data, sizeof(float));
    Console.WriteLine("int type, default: {0}, type size: {1}", dt.int_data, sizeof(int));
    Console.WriteLine("long type, default: {0}, type size: {1}", dt.long_data, sizeof(long));
    Console.WriteLine("sbyte type, default: {0}, type size: {1}", dt.sbyte_data, sizeof(sbyte));
    Console.WriteLine("short type, default: {0}, type size: {1}", dt.short_data, sizeof(short));
    Console.WriteLine("uint type, default: {0}, type size: {1}", dt.uint_data, sizeof(uint));
    Console.WriteLine("ulong type, default: {0}, type size: {1}", dt.ulong_data, sizeof(ulong));
    Console.WriteLine("ushort type, default: {0}, type size: {1}", dt.ushort_data, sizeof(ushort));
}
```

通过程序运行结果就可以得出每一种变量的默认值和变量的空间占的大小。

![](./assets/3.png)

**变量的范围: [https://www.runoob.com/csharp/csharp-data-types.html](https://www.runoob.com/csharp/csharp-data-types.html)**

### 浅拷贝还是深拷贝

![](./assets/4.png)

类是浅拷贝。

为了深拷贝，首先需要提供拷贝构造，和cpp一样

```cs
public Circle(Circle c) {
    __r = c.__r;
    __x = c.__x;
    __y = c.__y;
}
```

然后需要显示调用拷贝构造才能构造新对象。

![](./assets/5.png)

> [!CAUTION]
>
> `Circle c2 = c1;` // 就算有拷贝构造，这个也是浅拷贝，不同于C++

### 引用类型

引用类型不包含存储在变量中的实际数据，但它们包含对变量的引用。

换句话说，它们指的是一个内存位置。使用多个变量时，引用类型可以指向一个内存位置。如果内存位置的数据是由一个变量改变的，其他变量会自动反映这种值的变化。内置的引用类型有：`object`、`dynamic` 和 `string`。

**对象（Object）类型**

对象（Object）类型 是 C# 通用类型系统（Common Type System - CTS）中所有数据类型的终极基类。Object 是 System.Object 类的别名。所以对象（Object）类型可以被分配任何其他类型（值类型、引用类型、预定义类型或用户自定义类型）的值。但是，在分配值之前，需要先进行类型转换。

当一个值类型转换为对象类型时，则被称为 **装箱**；另一方面，当一个对象类型转换为值类型时，则被称为 **拆箱**。

**动态（Dynamic）类型**

您可以存储任何类型的值在动态数据类型变量中。这些变量的类型检查是在运行时发生的。

声明动态类型的语法：

```
dynamic <variable_name> = value;
```

例如：

```
dynamic d = 20;
```

动态类型与对象类型相似，但是对象类型变量的类型检查是在编译时发生的，而动态类型变量的类型检查是在运行时发生的。

**字符串（String）类型**

字符串（String）类型 允许您给变量分配任何字符串值。字符串（String）类型是 System.String 类的别名。它是从对象（Object）类型派生的。字符串（String）类型的值可以通过两种形式进行分配：引号和 @引号。

C# string 字符串的前面可以加 @（称作"逐字字符串"）将转义字符（\）当作普通字符对待。

用户自定义引用类型有：class、interface 或 delegate。

**参考: [https://www.runoob.com/csharp/csharp-data-types.html](https://www.runoob.com/csharp/csharp-data-types.html)**

```cs
internal void Test5()
{
    String str = "abcdefg";
    String str2 = str;
    // Console.WriteLine("str addr: {0}, {1}", &str, &str2); // error
    /**
     C#是高级的安全语言，不能访问地址，如果要判断是不是同一个引用，可以用 Object.ReferenceEquals
     */
    Console.WriteLine(Object.ReferenceEquals(str, str2));
    //str2[0] = 'a'; // only read
    StringBuilder mutable_str = new StringBuilder("abcdefgh");
    StringBuilder mutable_str2 = new StringBuilder(mutable_str.ToString()); // deepcopy
    // StringBuilder mutable_str2 = mutable_str; // reference
    mutable_str2[0] = '*';
    Console.WriteLine(mutable_str.ToString());
    Console.WriteLine(mutable_str2.ToString());
}
```

![](./assets/6.png)

- `String`是只读的
- `String str2 = str;`是浅拷贝
- `Console.WriteLine("str addr: {0}, {1}", &str, &str2); // error`是非法操作， C#是高级的安全语言，不能访问地址，如果要判断是不是同一个引用，可以用 `Object.ReferenceEquals`
- `Console.WriteLine(Object.ReferenceEquals(str, str2));`可以判断两个变量是不是指向同一个对象
- `StringBuilder`是可变字符串对象
- `StringBuilder mutable_str2 = new StringBuilder(mutable_str.ToString()); // deepcopy` 是深拷贝
- `StringBuilder mutable_str2 = mutable_str; // reference` 是引用

### 指针类型

后续说明

***

下面代码在`Lesson2.cs`中。

## 类型转换

### 隐式和显式

C#中有两种类型转换：隐式和显式，和CPP一样的，很好理解。

```cs
byte b = 10;
int i = b; // 隐式转换
```

显示就是强转，强转可能会导致丢失数据，这个也很好理解，不赘述。

```cs
int intValue = 42;
float floatValue = (float)intValue; // 强制从 int 到 float，数据可能损失精度
```

### 类型转换方法

| 序号 | 内置方法                                                     |
| ---- | ------------------------------------------------------------ |
| 1    | `ToBoolean` 如果可能的话，把类型转换为布尔型。               |
| 2    | `ToByte` 把类型转换为字节类型。                              |
| 3    | `ToChar` 如果可能的话，把类型转换为单个 Unicode 字符类型。   |
| 4    | `ToDateTime` 把类型（整数或字符串类型）转换为 日期-时间 结构。 |
| 5    | `ToDecimal` 把浮点型或整数类型转换为十进制类型。             |
| 6    | `ToDouble` 把类型转换为双精度浮点型。                        |
| 7    | `ToInt16` 把类型转换为 16 位整数类型。                       |
| 8    | `ToInt32` 把类型转换为 32 位整数类型。                       |
| 9    | `ToInt64` 把类型转换为 64 位整数类型。                       |
| 10   | `ToSbyte` 把类型转换为有符号字节类型。                       |
| 11   | `ToSingle` 把类型转换为小浮点数类型。                        |
| 12   | `ToString`把类型转换为字符串类型。                           |
| 13   | `ToType` 把类型转换为指定类型。                              |
| 14   | `ToUInt16` 把类型转换为 16 位无符号整数类型。                |
| 15   | `ToUInt32` 把类型转换为 32 位无符号整数类型。                |
| 16   | `ToUInt64` 把类型转换为 64 位无符号整数类型。                |

这些方法都定义在 `System.Convert` 类中，使用时需要包含 System 命名空间。它们提供了一种安全的方式来执行类型转换，因为它们可以处理 null值，**并且会抛出异常**，如果转换不可能进行。

**参考：[https://www.runoob.com/csharp/csharp-type-conversion.html](https://www.runoob.com/csharp/csharp-type-conversion.html)**

上面这些都是 `Convert` 类里面的非静态方法。

当然，`System.Convert` 也提供了一些静态的方法可以用。

```cs
public void Test1()
{
    // 使用 Convert 的静态方法
    string str = "123";
    int num = Convert.ToInt32(str);
    Console.WriteLine(num);
    // 使用 Parse 方法
    string str2 = "123.12";
    double d = double.Parse(str2);
    Console.WriteLine(d);
    // 使用 TryParse 方法
    string str3 = "123.12";
    double d2;
    bool if_success = double.TryParse(str3, out d2);
    if(if_success)
    {
        Console.WriteLine("success: {0}", d2);
    } else
    {
        Console.WriteLine("failed: {0}", d2);
    }
}
```

![](./assets/7.png)

- `Parse` 方法用于将字符串转换为对应的数值类型，如果转换失败会抛出异常。
- `TryParse` 方法类似于 `Parse`，但它不会抛出异常，而是返回一个布尔值指示转换是否成功。

### 类型转换重载

C# 还允许你定义自定义类型转换操作，通过在类型中定义 `implicit` 或 `explicit` 关键字。

```cs
internal class MyNumber
{
    public int Value;
    public MyNumber(int value)
    {
        Value = value;
    }
    public static implicit operator int(MyNumber mn)
    {
        return mn.Value;
    }
    public static explicit operator MyNumber(int n)
    {
        return new MyNumber(n);
    }
}
// ...
public void Test2()
{
    MyNumber mn = new MyNumber(1);
    int n = mn;
    MyNumber nm2 = (MyNumber)(n + 1);
    Console.WriteLine(nm2); // result: 2
}
```

相当于重载，很好理解。

- 为什么用 `static`，因为和 `this` 无关。

**详细的类型转换表格总结：[https://www.runoob.com/csharp/csharp-type-conversion.html](https://www.runoob.com/csharp/csharp-type-conversion.html)**

## 从 `stdin` 读数据

`System` 命名空间中的 `Console` 类提供了一个函数 `ReadLine()`，用于接收来自用户的输入，并把它存储到一个变量中。

```cs
public void Test3()
{
    int n = 0;
    n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(n);
}
```

## 一些其他规则

### 变量的生命周期

简单变量的生命周期和CPP一样，不赘述。

### 常量

整数常量可以是十进制、八进制或十六进制的常量。前缀指定基数：0x 或 0X 表示十六进制，0 表示八进制，没有前缀则表示十进制。

整数常量也可以有后缀，可以是 U 和 L 的组合，其中，U 和 L 分别表示 unsigned 和 long。后缀可以是大写或者小写，多个后缀以任意顺序进行组合。

这里有一些整数常量的实例：

```cs
212         /* 合法 */
215u        /* 合法 */
0xFeeL      /* 合法 */
078         /* 非法：8 不是一个八进制数字 */
032UU       /* 非法：不能重复后缀 */
```

以下是各种类型的整数常量的实例：

```cs
85         /* 十进制 */
0213       /* 八进制 */
0x4b       /* 十六进制 */
30         /* int */
30u        /* 无符号 int */
30l        /* long */
30ul       /* 无符号 long */
```

**参考：[https://www.runoob.com/csharp/csharp-constants.html](https://www.runoob.com/csharp/csharp-constants.html)**

一个浮点常量是由整数部分、小数点、小数部分和指数部分组成。您可以使用小数形式或者指数形式来表示浮点常量。这里有一些浮点常量的实例：

```cs
3.14159       /* 合法 */
314159E-5L    /* 合法 */
510E          /* 非法：不完全指数 */
210f          /* 非法：没有小数或指数 */
.e55          /* 非法：缺少整数或小数 */
```

字符常量里面转义字符那些，和其他语言基本相同。

字符串常量：字符串常量是括在双引号 `""` 里，或者是括在 `@""` 里。字符串常量包含的字符与字符常量相似。

定义常量：

```cs
internal class TestConst {
    public const int v1 = 1;
    public int v2 = 2;
}
public void Test4()
{
    TestConst tc = new TestConst();
    Console.WriteLine("const int v1: {0}", TestConst.v1);
    Console.WriteLine("int v2 = {0}", tc.v2);
}
```

> [!NOTE]
>
> **注意：类内常字段用类名访问，而不是用实例化后对象进行访问。**

### 运算符

运算符是一种告诉编译器执行特定的数学或逻辑操作的符号。C# 有丰富的内置运算符，分类如下：

- 算术运算符
- 关系运算符
- 逻辑运算符
- 位运算符
- 赋值运算符
- 其他运算符

**参考：[https://www.runoob.com/csharp/csharp-operators.html](https://www.runoob.com/csharp/csharp-operators.html)**

前面五种运算符和CPP相同，不赘述。

| 运算符     | 描述                                   | 实例                                                         |
| :--------- | :------------------------------------- | :----------------------------------------------------------- |
| `sizeof()` | 返回数据类型的大小                     | `sizeof(int)`，将返回 4.                                     |
| `typeof()` | 返回 class 的类型                      | `typeof(StreamReader);`                                      |
| `&`        | 返回变量的地址                         | `&a;` 将得到变量的实际地址。                                 |
| `*`        | 变量的指针                             | `*a;` 将指向一个变量。                                       |
| `? :`      | 条件表达式                             | 如果条件为真 ? 则为 X : 否则为 Y，和CPP的一样，三目          |
| `is`       | 判断对象是否为某一类型。               | `If( Ford is Car)`  检查 Ford 是否是 Car 类的一个对象。      |
| `as`       | 强制转换，即使转换失败也不会抛出异常。 | `Object obj = new StringReader("Hello"); StringReader r = obj as StringReader;` |

### 循环

`while`, `for`, `do while` 和CPP一样。

`foreach`循环：类似CPP的`for(auto e : v)`语句。

```cs
public void Test5()
{
    int[] arr = new int[] { 1, 2, 3, 4, 5 };
    Console.WriteLine(arr);
    foreach(var e in arr) Console.WriteLine(e);
}
```

![](./assets/8.png)

### 访问限定符和继承

- `public`：所有对象都可以访问；
- `private`：对象本身在对象内部可以访问；
- `protected`：只有该类对象及其子类对象可以访问
- `internal`：同一个程序集的对象可以访问；
- `protected internal`：访问限于当前程序集或派生自包含类的类型。

不写默认是`private`

`protected`相关的用于继承，和CPP一样，不赘述。

### 方法定义（函数定义）

前面已经编写很多函数定义了，不赘述，这里介绍前面没有提到的一些规则。

#### 一个递归调用的例子

用递归求一个阶乘吧

```cs
public int Factorial(int input)
{
    if (input == 0) return 0;
    if (input == 1) return 1;
    return input * Factorial(input - 1);
}
public void Test6()
{
    int input = 6;
    Console.WriteLine(Factorial(input)); // result: 720
}
```

#### 输入参数、输入输出参数、输出参数

这个很好理解，一个优秀的C++工程师在设计三种参数的时候都有讲究，比如：

```cpp
void func(const std::string& input, std::string& input_output, std::string* output);
```

**第一个是输入参数，必须带上`const`，这是优秀的编码习惯，第二个是输入输出参数，第三种是输出参数，一般用指针来写，这种规范是一定要在编码中体现出来的。**

**对应C#：**

```cs
public void Func(int a, ref int b, out int c) {}
```

`ref`表示传引用，`out`表示纯输出参数。

> [!NOTE]
>
> 在 C++ 和 C# 中，参数传递的机制和关键字使用存在一些显著的差异，特别是关于引用和 `const` 的使用。这些差异主要源于两种语言在设计哲学和运行时行为上的不同。
>
> **C++ 中的 `const` 和引用**
>
> 在 C++ 中，`const` 关键字和引用 (`&`) 被广泛用于参数传递，主要原因是：
> - **性能优化**：通过传递引用来避免复制大型对象，例如 `std::string`，同时使用 `const` 保证函数不会修改传入的对象。
> - **确保不可变性**：`const` 关键字确保函数内部不能修改输入参数，增加代码的安全性和可预测性。
>
> **C# 中的参数传递**
>
> C# 设计时采用了不同的方法：
> - **引用语义**：C# 中的类类型（引用类型）默认就是通过引用传递的，但这是引用的副本，而非对象本身的直接引用。这意味着你可以修改对象的内部状态，但不能修改对象本身的引用。
> - **值类型的传递方式**：值类型（如 `int`, `struct` 等）默认是通过值传递的，即创建原始数据的副本。如果你需要通过函数修改原始值类型数据，可以使用 `ref` 或 `out`。
> - **不支持 `const`**：C# 没有直接等价于 C++ 中的 `const` 修饰符。C# 不能声明一个方法的参数为 `const`，意味着不像在 C++ 中那样在编译时强制禁止修改参数。如果需要保证不修改数据，只能依靠开发者的约定或通过使用不可变对象来实现。
>
> **设计哲学差异**
>
> - **简化语言复杂度**：C# 设计时尽可能简化语言特性，避免了 C++ 中的一些复杂性，如指针算术和复杂的引用传递规则。
> - **安全性**：C# 强调内存和执行安全，自动内存管理（垃圾收集）减少了直接内存操作的需要，也就减少了 `const` 和指针的必要性。
>
> 总结来说，虽然 C# 在设计上不支持像 C++ 那样的 `const` 修饰符或相同的引用传递语义，但它提供了其它机制（如 `readonly` 修饰符、不可变集合等）来实现类似的目标。C# 的设计选择更强调简洁性和安全性，虽然这导致了一些灵活性的牺牲。

```cs
public void Func(int a, ref int b, out int c) {
    int aa = a;
    int bb = b;
    c = b;
}
public void Test7()
{
    int a = 10, b = 10, c;
    Func(a, ref b, out c);
}
```

### 可空类型 `Nullable`

简单说明：`?` 单问号用于对 `int、double、bool` 等无法直接赋值为 `null` 的数据类型进行 `null` 的赋值，意思是这个数据类型是 `Nullable` 类型的。

```cs
int i; // default: 0
int? i; // default: null
```

`??` 双问号用于判断一个变量在为 `null` 的时候返回一个指定的值。

> [!TIP]
>
> `int? i = 3;` 等同于 `Nullable<int> i = new Nullable<int>(3);`

**`?`的用法：**

```cs
public void Test8()
{
    int? a = null;
    int? b = 10;
    int? c = new int();
    int? d = new int?();
    Console.WriteLine("{0}, {1}, {2}, {3}", a, b, c, d); // result: , 10, 0,
}
```

**`??`的用法：**

简单来说就是，如果为`null`则返回预设值，否则返回原有的非`null`值。

```cs
public void Test9()
{
    int? a = null;
    int res1 = a ?? -1;
    a = 10;
    int res2 = a ?? -1;
    Console.WriteLine("{0}, {1}", res1, res2); // -1, 10
}
```

