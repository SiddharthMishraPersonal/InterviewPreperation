using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapTree
{
    /// <summary>
    /// The heap node.
    /// </summary>
    public class HeapNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeapNode"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public HeapNode(int data)
        {
            this.Data = data;
            this.ParentNode = null;
            this.LeftNode = null;
            this.RightNode = null;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public int Data { get; set; }

        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        public HeapNode LeftNode { get; set; }

        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        public HeapNode RightNode { get; set; }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        public HeapNode ParentNode { get; set; }
    }
}
