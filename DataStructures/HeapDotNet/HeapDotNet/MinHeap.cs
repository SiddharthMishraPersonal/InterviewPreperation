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
        int maxSize = 0;

        public MinHeap(int maxSize)
        {
            this.maxSize = maxSize;
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


        public void Delete()
        {
            if (currentSize == 0)
            {
                Console.WriteLine("Heap is empty.");
                return;
            }
            var lastIndex = currentSize - 1;
            heapNodeArray[0] = heapNodeArray[lastIndex];
            this.heapNodeArray[lastIndex] = null;
            currentSize--;

            // heapify the whole heap to arrange it
            this.Heapify(0);
        }

        /// <summary>
        /// Rearranges the Heap.
        /// </summary>
        /// <param name="index"></param>
        private void Heapify(int index)
        {
            if (index < 0 || index >= maxSize || heapNodeArray[index] == null)
            {
                return;
            }

            var currentNode = heapNodeArray[index];
            var leftChildIndex = this.GetLeftChildIndex(index);

            if (leftChildIndex > this.currentSize || this.heapNodeArray[leftChildIndex] == null)
            {
                return;
            }

            if (currentNode.Data > heapNodeArray[leftChildIndex].Data)
            {
                this.Swap(index, leftChildIndex);
                this.Heapify(leftChildIndex);
            }

            currentNode = heapNodeArray[index];
            var rightChildIndex = this.GetRightChildIndex(index);
            if (rightChildIndex > this.currentSize || this.heapNodeArray[rightChildIndex] == null)
            {
                return;
            }

            if (currentNode.Data > heapNodeArray[rightChildIndex].Data)
            {
                this.Swap(index, rightChildIndex);
                this.Heapify(rightChildIndex);
            }
        }


        /// <summary>
        /// Inorder display.
        /// </summary>
        public void InorderDisplay(int index)
        {
            //var count = heapNodeArray.Where(s => s != null).Count();
            //for (int i = 0; i < count; i++)
            //{

            //    Console.Write("{0}\t{1}", GetLeftChildIndex(i) >= count ? 0 : heapNodeArray[GetLeftChildIndex(i)].Data,
            //        GetRightChildIndex(i) >= count ? 0 :heapNodeArray[GetRightChildIndex(i)].Data);
            //}

            var leftChildIndex = this.GetLeftChildIndex(index);
            if (leftChildIndex < this.currentSize)
            {
                this.InorderDisplay(leftChildIndex);
            }

            Console.WriteLine(this.heapNodeArray[index].Data);

            var rightChildIndex = this.GetRightChildIndex(index);
            if (rightChildIndex < this.currentSize)
            {
                this.InorderDisplay(rightChildIndex);
            }
        }

        public void PreorderDisplay(int index)
        {
            if (index < 0 || index >= this.currentSize)
            {
                return;
            }

            Console.WriteLine(this.heapNodeArray[index].Data);

            var leftChildIndex = this.GetLeftChildIndex(index);
            if (leftChildIndex < this.currentSize)
            {
                this.PreorderDisplay(leftChildIndex);
            }

            var rightChildIndex = this.GetRightChildIndex(index);
            if (rightChildIndex < this.currentSize)
            {
                this.PreorderDisplay(rightChildIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = this.heapNodeArray[index1];
            this.heapNodeArray[index1] = this.heapNodeArray[index2];
            this.heapNodeArray[index2] = temp;
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
