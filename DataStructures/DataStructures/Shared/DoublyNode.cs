using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
  class DoublyNode
  {
    #region Private Member Variables

    private int _nodeValue;
    private DoublyNode _nextNode = null;
    private DoublyNode _prevNode = null;

    #endregion

    #region Public Properties

    public int NodeValue
    {
      get { return _nodeValue; }
      set { _nodeValue = value; }
    }

    public DoublyNode PrevNode
    {
      get { return _prevNode; }
      set { _prevNode = value; }
    }

    public DoublyNode NextNode
    {
      get { return _nextNode; }
      set { _nextNode = value; }
    }

    #endregion

    #region Constructors

    public DoublyNode(int nodeValue)
    {
      this.NodeValue = nodeValue;
    }

    public DoublyNode(int nodeValue, DoublyNode nextNode, DoublyNode prevNode)
    {
      this.NodeValue = nodeValue;
      this.NextNode = nextNode;
      this.PrevNode = prevNode;
    }

    #endregion

    #region Public Methods

    public void Display()
    {
      var prevNode = this.PrevNode == null ? "(NULL)" : this.PrevNode.NodeValue.ToString();
      var nextNode = this.NextNode == null ? "(NULL)" : this.NextNode.NodeValue.ToString();
      var display = string.Format("{0}<--{1}-->{2}", prevNode, this.NodeValue, nextNode);
      Console.WriteLine(display);
    }


    #endregion

    #region Private Methods

    #endregion
  }
}
