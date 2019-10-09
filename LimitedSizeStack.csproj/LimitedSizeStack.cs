using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        private readonly int Limit;
        private readonly LinkedList<T> LinkedStack = new LinkedList<T>();

        public LimitedSizeStack(int limit)
        {
            this.Limit = limit;
        }

        public void Push(T item)
        {
            LinkedStack.AddLast(item);
            if (LinkedStack.Count > Limit)
            {
                LinkedStack.RemoveFirst();
            }
        }

        public T Pop()
        {
            var value = LinkedStack.Last.Value;
            LinkedStack.RemoveLast();
            return value;
        }

        public int Count
        {
            get
            {
                return LinkedStack.Count;
            }
        }
    }
}
