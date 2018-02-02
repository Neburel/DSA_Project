using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA_ProjectTests1._01_TestUtil;
using System.IO;

namespace DSA_Project.Tests
{
    [TestClass()]
    public abstract class Abstract_SaveCharakterXMLTests : Abstract_LoadCharakterXMLTests
    {
        [TestInitialize]
        private void setUP_SaveCharakterXMLTests01()
        {
            Console.WriteLine("Aufrufer: Abstract_SaveCharakterXMLTests");
        }

        public override string getResourceName()
        {
            return "TestResources_LoadCharakter01_Standart";
        }
        public override string getLoadFileName()
        {
            return "newKazarik.xml";
        }
        internal override bool getSaveFirst()
        {
            return true;
        }

    }
}