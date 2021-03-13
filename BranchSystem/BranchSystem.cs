using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BranchSystem
{
    public class BranchSystem
    {
        readonly int Depth;
        public readonly TreeNode Tree;
        readonly Random Rand = new Random();
        readonly List<TreeNode> LeafNodes;
        public int LeafNodeCount { get; private set; }
        
        public BranchSystem(int depth)
        {
            Depth = depth;
            LeafNodes = new List<TreeNode>();
            LeafNodeCount = 0;
            Tree = BuildTree();
        }
        TreeNode BuildTree()
        {           
            return BuildBranchNode(1);
        }
        TreeNode BuildBranchNode(int currentDepth)
        {
            var isChildLeaf = false;
            if (currentDepth == Depth)
            {
                isChildLeaf = true;
            }
            var direction = Rand.NextDouble() < 0.5 ? GateDirection.Left : GateDirection.Right;
            var node = new TreeNode() { OpenDirection =direction };            
            if (isChildLeaf)
            {                
                node.Left = new TreeNode() { Id = LeafNodeCount, IsLeaf = true, Name =Util.GetName(LeafNodeCount) };
                LeafNodes.Add(node.Left);
                LeafNodeCount++;
                node.Right = new TreeNode() { Id = LeafNodeCount, IsLeaf = true, Name =Util.GetName(LeafNodeCount) };
                LeafNodes.Add(node.Right);
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
        string PredictEmptyContainerByNode(TreeNode node)
        {
            if (!node.IsLeaf)
            {
                //empty container at opposite of the node's initial direction
                if (node.OpenDirection == GateDirection.Left)
                {
                    return PredictEmptyContainerByNode(node.Right);
                }
                else
                {
                    return PredictEmptyContainerByNode(node.Left);
                }
            }
            else
            {
                return node.Name;
            }
        }
        public string RunBalls()
        {
            var containerCount = Math.Pow(2, Depth);
            var ballCount = containerCount - 1;
            for(var i= 0; i < ballCount; i++)
            {
                RunBallsOnNode(Tree);
            }
            var emptynode= LeafNodes.FirstOrDefault(n => !n.BallReceived);
            if (emptynode == null)
            {
                Console.WriteLine("something wrong");
                return "";
            }
            return emptynode.Name;
        }
        void RunBallsOnNode(TreeNode node)
        {
            if (!node.IsLeaf)
            {
                if (node.OpenDirection == GateDirection.Left)
                {
                    node.OpenDirection = GateDirection.Right;
                    RunBallsOnNode(node.Left);
                }
                else
                {
                    node.OpenDirection = GateDirection.Left;
                    RunBallsOnNode(node.Right);
                }                
            }
            else
            {
                node.BallReceived = true;
            }
        }
    }
}
