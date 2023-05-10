using System;
using System.Collections.Generic;
using System.Threading;

namespace ChineseSubtitleConversionTool
{
    public static class WordApplicationPool
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(0,Environment.ProcessorCount);//控制数量
        private static readonly Queue<WordApplication> pool = new Queue<WordApplication>();
        public static bool CreatingWordApplication = false;//用于中断word应用创建

        //用户选择高精度时就参加一个word放入池中
        public static void InitPool()
        {
            if (pool.Count == 0)
            {
                CreateWordApplicationAsync(1);
            }
        }
        /// <summary>
        /// 异步创建word
        /// </summary>
        /// <param name="num">要创建的数量</param>
        public static void CreateWordApplicationAsync(int num)
        {
            CreatingWordApplication = true;
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < num; ++i)
                {
                    if(CreatingWordApplication)
                    {
                        WordApplication wordApplication = new WordApplication();
                        lock (pool)
                        {
                            pool.Enqueue(wordApplication);
                        }
                        semaphore.Release();
                    }
                }
            });
        }
        /// <summary>
        /// 根据文件数初始化word，最高不超过系统线程数，生成一个word释放一个信号，不阻塞线程
        /// </summary>
        /// <param name="num"></param>
        public static void InitSemaphore(int num)
        {
            if (num > 0)
            {
                int limitSemaphore = Environment.ProcessorCount - semaphore.CurrentCount;
                if (limitSemaphore == 0)
                {
                    return;
                }
                if (num > semaphore.CurrentCount)
                {
                    int releaseNum = 0;
                    if(num <= Environment.ProcessorCount)
                    {
                        releaseNum = num - semaphore.CurrentCount;
                    }
                    else if (num > Environment.ProcessorCount)
                    {
                        releaseNum = limitSemaphore;
                    }
                    CreateWordApplicationAsync(releaseNum);
                }

            }
        }
        /// <summary>
        /// 获取word
        /// </summary>
        /// <returns></returns>
        public static WordApplication Get()
        {
            semaphore.Wait();

            lock (pool)
            {
                if (pool.Count > 0)
                {
                    return pool.Dequeue();
                }
            }
            return new WordApplication();//正常情況不会在这里创建WordApplication()
        }
        /// <summary>
        /// 归还word
        /// </summary>
        /// <param name="obj"></param>
        public static void Return(WordApplication obj)
        {
            lock (pool)
            {
                pool.Enqueue(obj);
            }
            semaphore.Release();
        }
    }
}
