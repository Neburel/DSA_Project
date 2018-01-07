using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public abstract class LanguageAbstractTalent : notFighting
    {
        int pos = 0;
        String FamilyName = "";
        String motherMark = "";

        public LanguageAbstractTalent(String FamilyName, String name, List<DSA_ATTRIBUTE> probe, int complex) : base(name, probe, complex.ToString(), null, null)
        {
            this.FamilyName = FamilyName;
        }
        public LanguageAbstractTalent(String FamilyName, String name, List<DSA_ATTRIBUTE> probe, int complex1, int complex2) : base(name, probe, complex1.ToString() + "(" + complex2.ToString() + ")", null, null)
        {
            this.FamilyName = FamilyName;
        }

        public String getFamilyName()
        {
            return FamilyName;
        }
       
        public void setMotherMark(String name)
        {
            if(String.Compare(name, "") == 0)
            {
                motherMark = "";
            } else
            {
                motherMark = "X";
            }
        }
        public String getMotherMark()
        {
            return motherMark;
        }

        public void setPOS(int pos)
        {
            this.pos = pos;
        }
        public int getPOS()
        {
            return pos;
        }

        public override string getComplexName()
        {
            return this.FamilyName + "_" + this.getName() + pos;
        }
    }
}
