using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.SingletonPatterns
{
    public sealed class SingleLockedSingleton
    {
        private static SingleLockedSingleton uniqueInstance;

        private static readonly object syncLocked = new object();
        private static int BuildCount = 0;
        private static int CreateCount = 0;
        private static int MethodCount = 0;

        private SingleLockedSingleton()
        {
            Console.WriteLine($"第{++BuildCount}次执行构造函数");
        }

        public static SingleLockedSingleton Instance
        {
            get
            {
                lock (syncLocked)
                {
                    if (null == uniqueInstance)//无锁
                    {
                        uniqueInstance = new SingleLockedSingleton();
                    }
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
