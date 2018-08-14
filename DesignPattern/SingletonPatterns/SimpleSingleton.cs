using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.SingletonPatterns
{

    public enum InstanceType
    {
        /// <summary>
        /// 单线程执行之后，你会发现构造函数只执行了一次，而静态实例方法执行了很多次，也就是相当于实例化了一次
        /// </summary>
        Singlethread_SimpleSingleton,
        /// <summary>
        /// 多线程执行后，你会发现执行了多次构造函数
        /// </summary>
        Multithread_SimpleSingleton,
        /// <summary>
        /// 多线程执行后，你会发现执行了1次构造函数,而静态实例方法执行了很多次
        /// </summary>
        Multithread_SingleLockedSingleton,
        /// <summary>
        /// 多线程执行后，你会发现执行了1次构造函数,静态实例方法也只执行1次
        /// </summary>
        Multithread_DoubleLockedSingleton
    }
    /// <summary>
    /// 线程不安全
    /// </summary>
    public sealed class SimpleSingleton
    {

        private static SimpleSingleton uniqueInstance;

        private static int BuildCount = 0;
        private static int CreateCount = 0;
        private static int MethodCount = 0;

        private SimpleSingleton()
        {
            Console.WriteLine($"第{++BuildCount}次执行构造函数");
        }

        public static SimpleSingleton Instance
        {
            get
            {
                if (null == uniqueInstance)//无锁
                {
                    uniqueInstance = new SimpleSingleton();
                }

                Console.WriteLine($"第{++CreateCount}次执行CreateInstance");

                return uniqueInstance;
            }
        }

        public void CallMethod()
        {
            Console.WriteLine($"我是第{++MethodCount}次调用,但是我是第{BuildCount}次构造函数的对象");
        }




    }


   
}
   
 