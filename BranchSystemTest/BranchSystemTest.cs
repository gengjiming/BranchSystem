using BranchSystem;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace BranchSystemTest
{
    public class BranchSystemTest
    {
        private readonly ITestOutputHelper output;
        public BranchSystemTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestBranchSystemDepth(int depth)
        {
            var branchSystem = new BranchSystem.BranchSystem(depth);
            var expectEmptyContainerName= ForcePathForDepth(depth, branchSystem.Tree);            
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            branchSystem.RunBalls();
            var emptyContainerName = branchSystem.GetEmptyContainer();
            output.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);
            output.WriteLine("Empty Container Name: " + emptyContainerName);
            Assert.NotEmpty(predictEmptyContainerName);
            Assert.NotEmpty(emptyContainerName);
            Assert.Equal(predictEmptyContainerName, emptyContainerName);
            Assert.Equal(expectEmptyContainerName, emptyContainerName);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestPredictEmptyContainer(int depth)
        {
            var branchSystem = new BranchSystem.BranchSystem(depth);
            var expectEmptyContainerName = ForcePathForDepth(depth, branchSystem.Tree);
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
           
            output.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);            
            Assert.NotEmpty(predictEmptyContainerName);            
            Assert.Equal(expectEmptyContainerName, predictEmptyContainerName);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestRunBalls(int depth)
        {
            var branchSystem = new BranchSystem.BranchSystem(depth);
            var expectEmptyContainerName = ForcePathForDepth(depth, branchSystem.Tree);          
            branchSystem.RunBalls();
            var emptyContainerCount = branchSystem.LeafNodes.Count(d=> !d.BallReceived);
            output.WriteLine("Empty container count: " + emptyContainerCount);
            Assert.Equal(1, emptyContainerCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestGetEmptyContainerName(int depth)
        {
            var branchSystem = new BranchSystem.BranchSystem(depth);
            var expectEmptyContainerName = ForcePathForDepth(depth, branchSystem.Tree);
            branchSystem.RunBalls();
            var emptyContainerName = branchSystem.GetEmptyContainer();
            output.WriteLine("Empty Container Name: " + emptyContainerName);
            Assert.NotEmpty(emptyContainerName);
            Assert.Equal(expectEmptyContainerName, emptyContainerName);
        }
        private string ForcePathForDepth(int depth, ITreeNode node)
        {
            var gd = node as GateNode;
            if (depth == 1)
            {
                gd.OpenDirection = GateDirection.Left;
                return "B";
            }
            else if(depth==2)
            {
                gd.OpenDirection = GateDirection.Left;
                (gd.Right as GateNode).OpenDirection = GateDirection.Right;
                return "C";
            }
            else if (depth == 3)
            {
                gd.OpenDirection = GateDirection.Left;
                var right1 = gd.Right as GateNode;
                right1.OpenDirection = GateDirection.Right;
                (right1.Left as GateNode).OpenDirection = GateDirection.Left;
                return "F";
            }
            else if(depth==4)
            {  
                gd.OpenDirection = GateDirection.Left;
                var right1 = gd.Right as GateNode;
                right1.OpenDirection = GateDirection.Right;
                var left2 = right1.Left as GateNode;
                left2.OpenDirection = GateDirection.Left;
                (left2.Right as GateNode).OpenDirection = GateDirection.Right;
                return "K";
            }
            return "";
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 4)]
        [InlineData(3, 8)]
        [InlineData(4, 16)]
        public void TestBuildBranchSystem(int depth,int containerCount)
        {
            var branchSystem = new BranchSystem.BranchSystem(depth);
            Assert.Equal(containerCount, branchSystem.LeafNodeCount);
        }

        [Fact]
        public void TestGetNameFromNumber()
        {
            Assert.Equal("A", Util.GetName(0));
            Assert.Equal("Z", Util.GetName(25));
            Assert.Equal("AA", Util.GetName(26));
            Assert.Equal("AZ", Util.GetName(51));
            Assert.Equal("AAA", Util.GetName(52));
            Assert.Equal("AAZ", Util.GetName(77));
            Assert.Equal("AAAA", Util.GetName(78));
        }
    }
}
