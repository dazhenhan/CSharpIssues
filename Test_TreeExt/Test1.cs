using Masuit.Tools.Models;

namespace Test_TreeExt
{
    /// <summary>
    /// 树形节点
    /// </summary>
    internal class MyNode
    {
        public long Id { get; set; }

        public long ParentId { get; set; }
    }

    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_TreeExt()
        {
            // 0-1-3
            //    -4-5
            //  -2
            var tree0 = new MyNode
            {
                Id = 0,
                ParentId = -1,
            };
            var tree1 = new MyNode
            {
                Id = 1,
                ParentId = 0,
            };
            var tree2 = new MyNode
            {
                Id = 2,
                ParentId = 0,
            };
            var tree3 = new MyNode
            {
                Id = 3,
                ParentId = 1,
            };
            var tree4 = new MyNode
            {
                Id = 4,
                ParentId = 1,
            };
            var tree5 = new MyNode
            {
                Id = 5,
                ParentId = 4,
            };

            // 转换
            var list = new List<MyNode> { tree0, tree1, tree2, tree3, tree4, tree5 };

            // 转换
            var nodes = list.ToTreeGeneral(c => c.Id, c => c.ParentId);
            Assert.IsNotNull(nodes);
            Assert.AreEqual(5, nodes.Flatten().Count());    //  <============================FAILED
        }
    }
}
