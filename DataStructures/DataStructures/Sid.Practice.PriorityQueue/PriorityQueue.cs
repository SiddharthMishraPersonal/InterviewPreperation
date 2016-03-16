using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.PriorityQueue
{
    public class PriorityQueue
    {
        #region Private Memeber Variables

        private int maxSize = -1;
        private int currentSize = 0;
        private HeapNode[] heapNodeArray;

        #endregion

        #region Constructors

        public PriorityQueue(int maxSize)
        {
            this.MaxSize = maxSize;
            this.heapNodeArray = new HeapNode[maxSize];
        }

        #endregion

        #region Properties

        public int MaxSize
        {
            get
            {
                return maxSize;
            }

            set
            {
                maxSize = value;
            }
        }

        #endregion

        #region Public Methods

        public void Insert(int data)
        {
            if (currentSize == maxSize)
            {
                Console.WriteLine("Heap is full");
                return;
            }

            var newNode = new HeapNode(data);

            if (this.currentSize == 0)
            {
                this.heapNodeArray[this.currentSize++] = newNode;
            }
            else
            {
                var index = currentSize++;
                var parentIndex = this.GetParentIndex(index);

                if (index > 0 && this.heapNodeArray[parentIndex].Data > newNode.Data)
                {
                    this.heapNodeArray[index] = this.heapNodeArray[parentIndex];
                    index = parentIndex;
                    parentIndex = this.GetParentIndex(parentIndex);
                }

                this.heapNodeArray[index] = newNode;
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

        public void PostorderDisplay(int index)
        {
            if (index < 0 || index >= this.currentSize)
            {
                return;
            }

            var leftChildIndex = this.GetLeftChildIndex(index);
            this.PostorderDisplay(leftChildIndex);

            var rightChildIndex = this.GetRightChildIndex(index);
            this.PostorderDisplay(rightChildIndex);

            Console.WriteLine(this.heapNodeArray[index].Data);
        }


        #endregion

        #region Private Methods

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

        private void Swap(int index1, int index2)
        {
            var temp = this.heapNodeArray[index1];
            this.heapNodeArray[index1] = this.heapNodeArray[index2];
            this.heapNodeArray[index2] = temp;
        }

        private int GetLeftChildIndex(int index)
        {
            return (2 * index + 1);
        }

        private int GetRightChildIndex(int index)
        {
            return (2 * index + 2);
        }

        private int GetParentIndex(int index)
        {
            return ((index - 1) / 2);
        }

        #endregion

    }
}
