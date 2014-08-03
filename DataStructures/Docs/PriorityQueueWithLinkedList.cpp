// An example of simple priority queue using linked lists.
// Priority depends on identity number. Small identity number has greater priority.
// If identity numbers are equal. Then FIFO rules are used.
#include <iostream>
#include <cstring>
#include <iomanip>
using namespace std;
 
struct DAT
{
    int id;
    char fullname[50];
    double salary;
};
 
struct NODE
{
  DAT data;
  Node *N;
  Node *P;
  Node(const int i , const char *f, const double s )
    {
       data.id = i;
       strcpy(data.fullname,f);
       data.salary = s;
       N = NULL;
       P = NULL;
  }
 
};
 
class PQueueLinkedList
{
  private:
  NODE *front;
  NODE *back;
  public:
  PQueueLinkedList(){front = NULL;back = NULL;}
  ~PQueueLinkedList(){destroyList();}
  void enqueue(NODE *);
  NODE* dequeue();
  void destroyList();
};
 
void PQueueLinkedList::enqueue(NODE *n)
{
    if(front == NULL)//queue has one node.
    {
        front = n;
        back = n;
    }
    else//queue has more than one node.
    {
        NODE* temp = front;
        if( n->data.id > temp->data.id)//New node id's is greater than all others.
        {
            front->P = n;
            n->N = front;
            front = n;
        }
        else
        {
            //Search for the position for the new node.
            while( n->data.id < temp->data.id)
              {
                    if(temp->N == NULL)
                        break;
                    temp = temp->N;
              }
                    //New node id's smallest than all others
                  if(temp->N == NULL && n->data.id < temp->data.id)
                    {
                        back->N = n;
                        n->P = back;
                        back = n;
                    }
 
                  else//New node id's is in the medium range.
                  {
                      temp->P->N = n;
                      n->P = temp->P;
                      n->N = temp;
                      temp->P = n;
                  }
        }
 
    }
}
 
NODE* PQueueLinkedList::dequeue()
{
        NODE *temp;
    if( back == NULL )//no nodes
        return NULL;
    else if(back->P == NULL)//there is only one node
    {
        NODE * temp2 = back;
            temp = temp2;
            front = NULL;
            back = NULL;
            delete temp2;
            return temp;
    }
    else//there are more than one node
    {
       NODE * temp2 = back;
            temp = temp2;
            back = back->P;
            back->N = NULL;
            delete temp2;
            return temp;
    }
}
 
void PQueueLinkedList::destroyList()
{
   while(front != NULL)
   {
       NODE *temp = front;
       front = front->N;
       delete temp;
   }
}
 
void disp(NODE *m)
{
    if( m == NULL )
    {
        cout << "\nQueue is Empty!!!" << endl;
    }
    else
    {
        cout << "\nId No.     : " << m->data.id;
        cout << "\nFull Name  : " << m->data.fullname;
        cout << "\nSalary     : " << setprecision(15)  << m->data.salary << endl;
    }
}
 
int main()
{
    PQueueLinkedList *Queue = new PQueueLinkedList();
 
    NODE No1( 101, "Aaaaa Nnnnnnn Mmmmm", 123456.4758 );
    NODE No2( 102, "Bbbbb Ddddd Ssssss", 765432.9488 );
    NODE No3( 103, "wwww nnnnn www eeee", 366667.3456 );
    NODE No4( 104, "Bsrew hytre dfresw", 9876544.0432 );
 
    Queue->enqueue(&No4);
    Queue->enqueue(&No3);
    Queue->enqueue(&No1);
    Queue->enqueue(&No2);
 
    disp(Queue->dequeue());
 
    disp(Queue->dequeue());
 
    disp(Queue->dequeue());
 
    disp(Queue->dequeue());
 
    disp(Queue->dequeue());
 
    delete Queue;
    return 0;
}
 
/*
Program's output
**********************
Id No.     : 101
Full Name  : Aaaaa Nnnnnnn Mmmmm
Salary     : 123456.4758
 
Id No.     : 102
Full Name  : Bbbbb Ddddd Ssssss
Salary     : 765432.9488
 
Id No.     : 103
Full Name  : wwww nnnnn www eeee
Salary     : 366667.3456
 
Id No.     : 104
Full Name  : Bsrew hytre dfresw
Salary     : 9876544.0432
 
Queue is Empty!!!
 
Process returned 0 (0x0)   execution time : 0.015 s
Press any key to continue.
*/