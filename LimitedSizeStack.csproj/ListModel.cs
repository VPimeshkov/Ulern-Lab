using System;
using System.Collections.Generic;

namespace TodoApplication
{
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        public int Limit;
        public LimitedSizeStack<Tuple<TItem, int, bool>> Events;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Events = new LimitedSizeStack<Tuple<TItem, int, bool>>(limit);
            Limit = limit;
        }

        public void AddItem(TItem item)
        {
            Items.Add(item);
            Events.Push(new Tuple<TItem, int, bool>(item, Items.Count - 1, true));
        }

        public void RemoveItem(int index)
        {
            Events.Push(new Tuple<TItem, int, bool>(Items[index], index, false));
            Items.RemoveAt(index);
        }

        public bool CanUndo()
        {
            return Events.Count == 0 ? false : true;
        }

        public void Undo()
        {
            var value = Events.Pop();
            if (value.Item3)
                Items.RemoveAt(value.Item2);
            else
                Items.Insert(value.Item2, value.Item1);
        }
    }
}
