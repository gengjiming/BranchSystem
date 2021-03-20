using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BranchSystem
{
    public class BranchSystem
    {
        readonly int Depth;
        public readonly ITreeNode Tree;
        readonly Random Rand = new Random();
        public readonly List<ContainerNode> LeafNodes;
        public int LeafNodeCount { get; private set; }
        
        public BranchSystem(int depth)
        {
            Depth = depth;
            LeafNodes = new List<ContainerNode>();
            LeafNodeCount = 0;
            Tree = BuildTree();
        }
        ITreeNode BuildTree()
        {           
            return BuildBranchNode(1);
        }
        ITreeNode BuildBranchNode(int currentDepth)
        {
            var isChildLeaf = false;
            if (currentDepth == Depth)
            {
                isChildLeaf = true;
            }
            var direction = Rand.NextDouble() < 0.5 ? GateDirection.Left : GateDirection.Right;
            var node = new GateNode() { OpenDirection =direction };            
            if (isChildLeaf)
            {                
                var left= new ContainerNode() { Id = LeafNodeCount, Name =Util.GetName(LeafNodeCount) };
                node.Left = left;
                LeafNodes.Add(left);
                LeafNodeCount++;
                var right= new ContainerNode() { Id = LeafNodeCount, Name =Util.GetName(LeafNodeCount) };
                node.Right = right;
                LeafNodes.Add(right);
                LeafNodeCount++;
            }
            else
            {
                node.Left=BuildBranchNode(currentDepth + 1);
                node.Right = BuildBranchNode(currentDepth + 1);
            }          
            return node;
        }
        public string PredictEmptyContainer()
        {
            return PredictEmptyContainerByNode(Tree);
        }
        string PredictEmptyContainerByNode(ITreeNode node)
        {
            if (node is GateNode gd)
            {
                //empty container at opposite of the node's initial direction
                if (gd.OpenDirection == GateDirection.Left)
                {
                    return PredictEmptyContainerByNode(gd.Right);
                }
                else
                {
                    return PredictEmptyContainerByNode(gd.Left);
                }
            }
            else
            {
                var cd = node as ContainerNode;
                return cd!.Name;
            }
        }
        public void RunBalls()
        {
            var containerCount = Math.Pow(2, Depth);
            var ballCount = containerCount - 1;
            for(var i= 0; i < ballCount; i++)
            {
                Tree.RunBall();
            }            
        }
        public string GetEmptyContainer()
        {
            var emptynode = LeafNodes.FirstOrDefault(n => !n.BallReceived);
            if (emptynode == null)
            {
                Console.WriteLine("something wrong");
                return "";
            }
            return emptynode.Name;
        }
    }
}
