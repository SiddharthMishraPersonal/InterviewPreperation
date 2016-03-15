using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapDotNet
{
    public class MinHeap
    {
        HeapNode[] heapNodeArray;
        int currentSize = 0;

        public MinHeap(int maxSize)
        {
            heapNodeArray = new HeapNode[maxSize];
        }

        /// <summary>
        /// Insertes node in heap.
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            var newNode = new HeapNode(data);
            if (currentSize == 0)
            {
                heapNodeArray[currentSize++] = newNode;
            }
            else
            {
                var index = currentSize++;
                var parentIndex = this.GetParentIndex(index);
                while (index > 0 && heapNodeArray[parentIndex].Data > newNode.Data)
                {
                    heapNodeArray[index] = heapNodeArray[parentIndex];
                    index = parentIndex;
                    parentIndex = this.GetParentIndex(index);
                }

                heapNodeArray[index] = newNode;
            }

        }

        public void InorderDisplay()
        {
            var level = 0;
            for (int i = 0; i < heapNodeArray.Count(); i++)
            {
                if (i <= 2 * level-1)
                {
                    Console.WriteLine(heapNodeArray[i].Data + "\t");
                    level++;
                }
                else
                {
                    Console.Write(heapNodeArray[i].Data + "\t");
                }
               // Console.Write("{0}\t{1}", heapNodeArray[GetLeftChildIndex(i)].Data, heapNodeArray[GetRightChildIndex(i)].Data);
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return (2 * index + 1);
        }

        private int GetRightChildIndex(int index)
        {
            return (2 * index + 2);
        }
    }
}
