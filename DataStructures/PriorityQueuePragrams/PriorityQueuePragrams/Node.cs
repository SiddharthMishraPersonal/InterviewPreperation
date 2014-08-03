using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueuePragrams
{
  public class Node
  {
    private int _value;
    private Node _nextNode;


    public int Value
    {
      get { return _value; }
      set { this._value = value; }
    }

    public Node NextNode
    {
      get { return _nextNode; }
      set { _nextNode = value; }
    }

    public Node(int value)
    {
      Value = value;
      NextNode = null;
    }
  }


}
