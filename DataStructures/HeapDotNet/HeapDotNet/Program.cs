﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var minHeap = new MinHeap(7);
            minHeap.Insert(7);
            minHeap.Insert(2);
            minHeap.Insert(4);
            minHeap.Insert(3);
            minHeap.Insert(6);
            minHeap.Insert(1);
            minHeap.Insert(5);

            Console.WriteLine("In-order display");
            minHeap.InorderDisplay(0);

            Console.WriteLine("Pre-order display");
            minHeap.PreorderDisplay(0);

            minHeap.Delete();
            Console.WriteLine("Pre-order display");
            minHeap.PreorderDisplay(0);

            Console.ReadKey();
        }
    }
}