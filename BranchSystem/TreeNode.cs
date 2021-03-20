using System;
using System.Collections.Generic;
using System.Text;

namespace BranchSystem
{
    public class GateNode: ITreeNode
    {
        public ITreeNode Left { get; set; }
        public ITreeNode Right { get; set; }
        public GateDirection OpenDirection { get; set; }
        
        public void RunBall()
        {
            if (OpenDirection == GateDirection.Left)
            {
                OpenDirection = GateDirection.Right;
                Left!.RunBall();
            }
            else
            {
                OpenDirection = GateDirection.Left;
                Right!.RunBall();
            }
        }
    }
    public class ContainerNode:ITreeNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool BallReceived { get; set; }

        public void RunBall()
        {
            BallReceived = true;
        }
    }
}
