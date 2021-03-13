using System;
using System.Collections.Generic;
using System.Text;

namespace BranchSystem
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public GateDirection OpenDirection { get; set; }
        public bool IsLeaf { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool BallReceived { get; set; }
        
    }
}
