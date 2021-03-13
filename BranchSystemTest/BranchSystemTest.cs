using BranchSystem;
using System;
using System.Diagnostics;
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
        [Fact]
        public void TestBranchSystemDepth1()
        {
            var branchSystem = new BranchSystem.BranchSystem(1);
            Assert.Equal(2, branchSystem.LeafNodeCount);
            //set initial direction to left
            branchSystem.Tree.OpenDirection=GateDirection.Left;
            var expectEmptyContainerName = "B";
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            var emptyContainerName = branchSystem.RunBalls();
            output.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);
            output.WriteLine("Empty Container Name: " + emptyContainerName);
            Assert.NotEmpty(predictEmptyContainerName);
            Assert.NotEmpty(emptyContainerName);
            Assert.Equal(predictEmptyContainerName, emptyContainerName);
            Assert.Equal(expectEmptyContainerName, emptyContainerName);
        }
        [Fact]
        public void TestBranchSystemDepth2()
        {
            var branchSystem = new BranchSystem.BranchSystem(2);
            Assert.Equal(4, branchSystem.LeafNodeCount);
            //set initial direction to left
            branchSystem.Tree.OpenDirection = GateDirection.Left;
            branchSystem.Tree.Right.OpenDirection = GateDirection.Right;
            var expectEmptyContainerName = "C";
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            var emptyContainerName = branchSystem.RunBalls();
            output.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);
            output.WriteLine("Empty Container Name: " + emptyContainerName);
            Assert.NotEmpty(predictEmptyContainerName);
            Assert.NotEmpty(emptyContainerName);
            Assert.Equal(predictEmptyContainerName, emptyContainerName);
            Assert.Equal(expectEmptyContainerName, emptyContainerName);
        }
        [Fact]
        public void TestBranchSystemDepth3()
        {
            var branchSystem = new BranchSystem.BranchSystem(3);
            Assert.Equal(8, branchSystem.LeafNodeCount);
            //set initial direction to left
            branchSystem.Tree.OpenDirection = GateDirection.Left;
            branchSystem.Tree.Right.OpenDirection = GateDirection.Right;
            branchSystem.Tree.Right.Left.OpenDirection = GateDirection.Left;
            var expectEmptyContainerName = "F";
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            var emptyContainerName = branchSystem.RunBalls();
            output.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);
            output.WriteLine("Empty Container Name: " + emptyContainerName);
            Assert.NotEmpty(predictEmptyContainerName);
            Assert.NotEmpty(emptyContainerName);
            Assert.Equal(predictEmptyContainerName, emptyContainerName);
            Assert.Equal(expectEmptyContainerName, emptyContainerName);
        }
        [Fact]
        public void TestBranchSystemDepth4()
        {
            var branchSystem = new BranchSystem.BranchSystem(4);
            Assert.Equal(16, branchSystem.LeafNodeCount);
            //set initial direction to left
            branchSystem.Tree.OpenDirection = GateDirection.Left;
            branchSystem.Tree.Right.OpenDirection = GateDirection.Right;
            branchSystem.Tree.Right.Left.OpenDirection = GateDirection.Left;
            branchSystem.Tree.Right.Left.Right.OpenDirection = GateDirection.Right;
            var expectEmptyContainerName = "K";
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            var emptyContainerName = branchSystem.RunBalls();
            output.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);
            output.WriteLine("Empty Container Name: " + emptyContainerName);
            Assert.NotEmpty(predictEmptyContainerName);
            Assert.NotEmpty(emptyContainerName);
            Assert.Equal(predictEmptyContainerName, emptyContainerName);
            Assert.Equal(expectEmptyContainerName, emptyContainerName);
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
