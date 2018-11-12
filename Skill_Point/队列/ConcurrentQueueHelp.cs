using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils工具;

namespace Skill_Point.队列
{
    public class ConcurrentQueueHelp
    {
       
      

        public ConcurrentQueueHelp()
        {
            var taskQueue = new ConcurrentQueue<string>();

            taskQueue.Enqueue("");                               //Enqueue 将元素添加到队列末尾
            taskQueue.TryDequeue(out string str);               //TryDequeue 尝试移除处于队列开头的对象
            taskQueue.TryPeek(out string str1);                 //TryPeek 尝试返回队列开头的对象，但不移除
            taskQueue.ToArray();
           
        }

        public static async Task RunProgram()
        {
            var taskQueue = new ConcurrentQueue<CustomTask>();
            var cts = new CancellationTokenSource();
            //生成任务添加至并发队列
            var taskSource = Task.Run(() => TaskProducer(taskQueue));
            //同时启动四个任务处理队列中的任务
            Task[] processors = new Task[4];
            for (int i = 1; i <= 4; i++)
            {
                string processId = i.ToString();

                processors[i - 1] = Task.Run(() => TaskProcessor(taskQueue, processId, cts.Token));
            }
            await taskSource;
            //向任务发送取消信号
            //cts.CancelAfter(TimeSpan.FromSeconds(2));
            await Task.WhenAll(processors);
        }
        //产生任务
        private static async Task TaskProducer(ConcurrentQueue<CustomTask> queue)
        {
            int len = 1;
            while (len != 100)
            {
                await Task.Delay(50);
                var workItem = new CustomTask { Id = len };
                queue.Enqueue(workItem);
                Console.WriteLine("成功生产对象CustomTask，获取Id ={0}", workItem.Id);
                len++;
                if (queue.Count > 20)
                {
                    await Task.Delay(500);
                }
            }
        }

        //执行任务
        private static async Task TaskProcessor(ConcurrentQueue<CustomTask> queue, string name, CancellationToken token)
        {
            try
            {
                CustomTask workItem;
                bool dequeueSuccesful = false;
                await GetRandomDelay();
                do
                {
                    if (queue.Count == 0) { continue; }
                    dequeueSuccesful = queue.TryDequeue(out workItem);
                    if (dequeueSuccesful)
                    {
                        Console.WriteLine("id ={0}的CustomTask对象被第{1}线程消费", workItem.Id, name);
                    }
                    await GetRandomDelay();
                }
                while (!token.IsCancellationRequested);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }





        class CustomTask
        {
            public int Id { get; set; }
        }
        private static Task GetRandomDelay()
        {
            int delay = new Random(DateTime.Now.Millisecond).Next(1500);
            return Task.Delay(delay);
        }

        public static void start()
        {
            Task t = RunProgram();
            t.Wait();
            Console.ReadKey();
        }
    }
}



