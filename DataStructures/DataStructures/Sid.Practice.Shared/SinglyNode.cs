using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.Shared
{
  public class SinglyNode : IDisposable
  {
    #region Private Member Variables

    private int _nodeValue;
    private SinglyNode _nextNode = null;
    private Guid _nodeId = Guid.Empty;

    #endregion

    #region Public Properties

    public Guid NodeId
    {
      get { return _nodeId; }
      set { _nodeId = value; }
    }

    public int NodeValue
    {
      get { return _nodeValue; }
      set { _nodeValue = value; }
    }

    public SinglyNode NextNode
    {
      get { return _nextNode; }
      set { _nextNode = value; }
    }

    #endregion

    #region Constructors

    public SinglyNode(int nodeValue)
    {
      this.NodeId = Guid.NewGuid();
      this.NodeValue = nodeValue;
    }

    public SinglyNode(int nodeValue, SinglyNode nextNode, SinglyNode prevNode)
    {
      this.NodeValue = nodeValue;
      this.NextNode = nextNode;
    }

    #endregion

    #region Public Methods

    public void Display()
    {
      var display = string.Empty;
      var nextNode = this.NextNode == null ? "(NULL)" : this.NextNode.NodeValue.ToString();
      if (this.NextNode == null)
        display = string.Format("{0}-->{1}", this.NodeValue, nextNode);
      else
        display = string.Format("{0}-->", this.NodeValue);
      Console.Write(display);
    }


    #endregion

    #region Private Methods

    #endregion

    public void Dispose()
    {
      _nextNode = null;
      _nodeValue = 0;

    }
  }
}
