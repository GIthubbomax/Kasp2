using System;
using System.Collections;
using System.Threading;
using Kasp;

namespace Kasp
{
    class Synhronizedqueue
    {
        private Queue queue;

        public Synhronizedqueue()
        {
            queue = Queue.Synchronized(new Queue());
        }

        public Synhronizedqueue(int capacity)
        {
            queue = Queue.Synchronized(new Queue(capacity));
        }

        public Synhronizedqueue(int capacity, float growFactor)
        {
            queue = Queue.Synchronized(new Queue(capacity, growFactor));
        }

        public void push(Object o)
        {
            queue.Enqueue(o);
        }

        public Object pop()
        {
            bool flag = true;
            while (queue.Count == 0)
            {
                if (flag)
                    Console.WriteLine(Thread.CurrentThread.Name + " ожидаю элемент");
                flag = false;
            }
            flag = true;
            Object o = queue.Dequeue();
            queue.TrimToSize();
            return o;
        }
    }
}

// Тестовые классы потоков для pop и push
/*
class MypopThread
{
    public int Count;
    public Thread Thrd;


    public MypopThread(string name, Synhronizedqueue q)
    {
        Count = 0;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;

        Thrd.Start(q);
    }

    void Run(object q)
    {
        while (Count < 20)
        {
            Synhronizedqueue queue = (Synhronizedqueue) q;

            string s = (string) queue.pop();
            Console.WriteLine(Thread.CurrentThread.Name+" взял " + s);
            Thread.Sleep(10);
            Count++;
        }
    }
}


class MypushThread
{
    public int Count;
    public Thread Thrd;


    public MypushThread(string name, Synhronizedqueue q)
    {
        Count = 0;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;

        Thrd.Start(q);
    }

    void Run(object q)
    {
        while (Count < 5)
        {
            Synhronizedqueue queue = (Synhronizedqueue) q;
            string s = "поток" + Thrd.Name + " записал " + Count + " в очередь";
            Console.WriteLine(s);
            queue.push(s);
            Thread.Sleep(5);
            Count++;
        }
    }
}


class MyClass
{
    static void Main(string[] args)
    {
        Synhronizedqueue synhronizedqueue = new Synhronizedqueue();
        MypushThread mypushThread = new MypushThread("1", synhronizedqueue);
        MypushThread mypushThread1 = new MypushThread("2", synhronizedqueue);
        MypopThread mypopThread = new MypopThread("читатель1", synhronizedqueue);
        MypopThread mypopThread2 = new MypopThread("читатель2", synhronizedqueue);

        Thread.Sleep(1000);
        Console.WriteLine();
        Console.ReadLine();
    }
}
*/