using System;
using System.Collections.Generic;
using System.Text;

namespace LabOp7Sharp
{
    class Node
    {   
        public float Data { get; set; }
        public Node Previous { get; set; }
        public Node(float data)
        {
            Data = data;
        }
    }
}
