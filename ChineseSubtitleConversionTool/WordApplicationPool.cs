using System;
using System.Collections.Generic;
using System.Threading;

namespace ChineseSubtitleConversionTool
{
    public static class WordApplicationPool
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(0,Environment.ProcessorCount);
        private static readonly Queue<WordApplication> pool = new Queue<WordApplication>();
        public static bool CreatingWordApplication = false;

        public static void InitPool()
        {
            if (pool.Count == 0)
            {
                CreateWordApplicationAsync(1);
            }
        }
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
