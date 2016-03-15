using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapDotNet
{
public    class HeapNode
    {
        public int Data { get; set; }

        public HeapNode(int data)
        {
            this.Data = data;
        }
    }
}
