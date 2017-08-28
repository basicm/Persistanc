using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public abstract class BaseTemplate:ICore
    {
        private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        private object locker = new object();

        public abstract bool TemplateMethod(string value);
        public async Task<bool> Write(string value)
        {
            queue.Enqueue(value);

            if (queue.Count <= 1)
                return true;

            lock (locker)
            {
                Task task = Task.Run(() => Flush());
                Task.WaitAll(new Task[] {task});
            }
            return true;
        }

        async Task Flush()
        {
            string content;
            int counter = 0;

            while (queue.TryDequeue(out content) && counter <=1)
            {
                TemplateMethod(content);
                counter++;
            }
        }
    }
}
