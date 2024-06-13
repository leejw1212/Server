using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class MainClass
    {
        volatile static bool _stop = false; // volatile = 최적화 노!, 캐시 무시하고 최신 값 읽게 함 

        static void ThreadMain()
        {
            Console.WriteLine("쓰레드 시작 !");

            while (_stop == false)
            {

            }

            //release 모드로 최적화 하면 아래와 같이 
            //if (_stop == false)
            //{
            //    while (true) { }
            //}

            Console.WriteLine("쓰레드 종료 !");
        }

        static void Main(string[] args)
        {
            Task t = new Task(ThreadMain);
            t.Start();

            Thread.Sleep(1000);

            _stop = true;

            Console.WriteLine("Stop 호출 ");
            Console.WriteLine("종료 대기 중");

            t.Wait(); // 종료 대기 = thread join

            Console.WriteLine("종료 성공");
        }
    }
}