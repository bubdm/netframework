using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    public class MyCalc : IDisposable
    {
        public List<int> Items = new List<int>();

        public void Add(int item)
        {
            Items.Add(item);
        }
        public void Remove(int index)
        {
            Items.RemoveAt(index);
        }
        public int Count { get => Items.Count; }
        public void Dispose()
        {
            //clean class
        }
    }
}
