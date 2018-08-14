using DesignPattern.SingletonPatterns;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singletons(InstanceType.Singlethread_SimpleSingleton);

            Console.ReadLine();
        }

        public static void Singletons(InstanceType instanceType)
        {
            switch (instanceType)
            {
                case InstanceType.Singlethread_SimpleSingleton:
                    {
                        Console.WriteLine("单线程执行之后，你会发现构造函数只执行了一次，而静态实例方法执行了很多次，也就是相当于实例化了一次");
                        for (int i = 0; i < 5; i++)
                        {
                            SimpleSingleton.Instance.CallMethod();
                        }
                    }
                    break;
                case InstanceType.Multithread_SimpleSingleton:
                    {
                        Console.WriteLine("多线程执行后，你会发现执行了多次构造函数");
                        TaskFactory taskFactory1 = new TaskFactory();
                        for (int i = 0; i < 5; i++)
                        {
                            taskFactory1.StartNew(() => { SimpleSingleton.Instance.CallMethod(); });
                        }
                    }
                    break;
                case InstanceType.Multithread_SingleLockedSingleton:
                    {
                        Console.WriteLine("多线程执行后，你会发现执行了1次构造函数,而静态实例方法执行了很多次");

                        TaskFactory taskFactory2 = new TaskFactory();
                        for (int i = 0; i < 5; i++)
                        {
                            taskFactory2.StartNew(() => { SingleLockedSingleton.Instance.CallMethod(); });
                        }
                    }
                    break;

                case InstanceType.Multithread_DoubleLockedSingleton:
                    {
                        Console.WriteLine("多线程执行后，你会发现执行了1次构造函数,静态实例方法也只执行1次");

                        TaskFactory taskFactor3 = new TaskFactory();
                        for (int i = 0; i < 5; i++)
                        {
                            taskFactor3.StartNew(() => { DoubleLockedSingleton.Instance.CallMethod(); });
                        }
                    }
                    break;

            }
        }
    }
}
