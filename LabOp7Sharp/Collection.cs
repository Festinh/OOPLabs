using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace LabOp7Sharp
{
    class Collection
    {
        Node head;
        Node tail;


        public Collection(float data)
        {
            Push(data);
        }


        public Collection(float[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Push(data[i]);
            }
        }


        public void Push(float data)
        {
            Node temp = new Node(data);
            Node temp1 = null;
            if (tail == null)
            {
                tail = temp;
            }
            else
            {
                temp1 = head;
            }
            head = temp;
            head.Previous = temp1;
        }


        public float CalcSum()
        {
            Node current = head;
            float sum = 0;
            int counter = 0;
            while (current != null)
            {

                sum += current.Data;
                current = current.Previous;
                counter++;
            }
            return sum/counter;
        }


        public int CalcNumberOfNumbers(float sum)
        {
            Node current = head;
            int counter = 0;
            while (current != null)
            {
                if (current.Data > sum)
                {
                    counter++;
                }
                current = current.Previous;
            }
            return counter;
        }


        public bool Pop(float data)
        {
            bool breaker = false;
            while (true)
            {
                Node current = head;
                Node temp = null;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        break;
                    }
                    temp = current;
                    current = current.Previous;
                }
 
                if (current != null)
                {
                    if (current == head)
                    {
                        head = head.Previous;
                    }
                    else if (current.Previous == null)
                    {
                        temp.Previous = null;
                    }
                    else
                    {
                        temp.Previous = current.Previous;
                    }
                    breaker = true;
                }
                else return breaker;
            }
        }


        public void ExcludeNegativeNumbers()
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data < 0) Pop(current.Data);
                current = current.Previous;
            }
        }
    }
}
