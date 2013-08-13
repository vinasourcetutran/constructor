using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RLM.Construction.ServiceHelpers;
using RLM.Construction.WebApplication.CommonLib;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;

namespace RLM.Construction.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void UnitTreeTest()
        {
            try
            {
                RLM.Construction.Entities.Unit from = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(2);
                RLM.Construction.Entities.Unit to = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(6);

                UnitTree tree = new UnitTree(from, 0, null);
                AlphaBetaTree<Unit> node = tree.Translate(to);
                testContextInstance.WriteLine("Name:{0},weight:{1},nodeId:{2}", node.Node.Name, node.Weight, node.Node.UnitId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            //
            // TODO: Add test logic	here
            //
        }
    }
}
