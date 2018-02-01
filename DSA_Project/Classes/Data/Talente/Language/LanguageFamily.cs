using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class LanguageFamily
    {
        private String name;
        List<LanguageTalent> ltlist;
        List<FontTalent> ftlist;

        public LanguageFamily(String name)
        {
            this.name = name;
            ltlist = new List<LanguageTalent>(0);
            ftlist = new List<FontTalent>(0);
        }
        public void addLanguageRow(LanguageTalent lt, FontTalent ft)
        {
            ltlist.Add(lt);
            ftlist.Add(ft);
        }
        public LanguageTalent getLanguageTalent(int pos)
        {
            return ltlist[pos];
        }
        public FontTalent GetFontTalent(int pos)
        {
            return ftlist[pos];
        }
        public int Count()
        {
            return ftlist.Count;
        }
        public String getName()
        {
            return this.name;
        }
    }
}
