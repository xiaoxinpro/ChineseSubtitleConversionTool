using System;
using System.Collections.Generic;
using System.Threading;

namespace ChineseSubtitleConversionTool
{
    public static class WordApplicationPool
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1,Environment.ProcessorCount);
        private static readonly Queue<WordApplication> pool = new Queue<WordApplication>();

        public static void PoolInit(int num)
        {
            for (int i = 0; i < num; ++i)
            {
                WordApplication wordApplication = new WordApplication();
                lock (pool)
                {
                    pool.Enqueue(wordApplication);
                }
            }
        }

        public static void SemaphoreInit(int num)
        {
            int limitSemaphore = Environment.ProcessorCount - semaphore.CurrentCount;

            if (limitSemaphore == 0)
            {
                return;
            }
            num /= 2;
            if (num > limitSemaphore)
            {
                semaphore.Release(limitSemaphore);
            }
            else if(num <= limitSemaphore && num > 0)
            {
                semaphore.Release(num);
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
            return new WordApplication();
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
