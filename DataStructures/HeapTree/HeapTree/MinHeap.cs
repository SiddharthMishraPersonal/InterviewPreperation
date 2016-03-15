using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapTree
{
    /// <summary>
    /// The min heap.
    /// </summary>
    public class MinHeap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinHeap"/> class.
        /// </summary>
        public MinHeap()
        {

        }

        /// <summary>
        /// Gets or sets the root node.
        /// </summary>
        public HeapNode RootNode { get; set; }

        /// <summary>
        /// Gets or sets the last node.
        /// </summary>
        public HeapNode LastNode { get; set; }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void Insert(HeapNode rootNode, int data)
        {
            var newNode = new HeapNode(data);

            if (this.RootNode == null)
            {
                this.RootNode = newNode;
                this.LastNode = this.RootNode;
            }
            else
            {
                if (this.LastNode.LeftNode == null)
                {
                    this.LastNode.LeftNode = newNode;
                    return;
                }

                if (this.LastNode.RightNode == null)
                {
                    this.LastNode.RightNode = newNode;
                    return;
                }

                this.Insert();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        public void Delete()
        {

        }

        /// <summary>
        /// Rearranges heap nodes after delete operation.
        /// </summary>
        public void Heapify()
        {

        }
    }
}
