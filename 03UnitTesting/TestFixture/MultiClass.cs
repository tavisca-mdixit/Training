using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAttribute;

namespace TestCLass
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Ignore]
        public void Method1()
        {
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void Method2()
        {
        }
    }

    [TestClass]
    public class Class2
    {
        [TestMethod]
        [TestCategory("SmokeTest")]
        public void Method3()
        {
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Ignore]
        public void Method4()
        {
        }
    }

    [TestClass]
    public class Class3
    {
        [TestMethod]
        [TestCategory("LoadTest")]
        public void Method5()
        {
        }


        [TestMethod]
        [TestCategory("RegressionTest")]
        public void Method6()
        {
        }
    }

    [TestClass]
    public class Class4
    {

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void Method7()
        {
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void Method8()
        {
        }
    }


}
