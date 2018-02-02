using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project.Tests
{
    [TestClass()]
    public class LanguageFamilyTests
    {
        [TestMethod]
        public void LanguageFamily_create()
        {
            LanguageFamily languageFamily = new LanguageFamily("Name");
            Assert.AreEqual("Name", languageFamily.getName());
        }
        [TestMethod]
        public void LanguageFamily_addRow()
        {
            LanguageFamily languageFamily = new LanguageFamily("Family");
            Assert.AreEqual("Family", languageFamily.getName());

            LanguageTalent lt = new LanguageTalent("lt", new List<string>());
            FontTalent ft = new FontTalent("ft", new List<string>());

            languageFamily.addLanguageRow(lt,ft);

            Assert.AreEqual(lt, languageFamily.getLanguageTalent(0));
            Assert.AreEqual(ft, languageFamily.GetFontTalent(0));

            Assert.AreEqual(1, languageFamily.Count());
        }        
    }
}