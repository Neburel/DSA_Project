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
        String motherMark = "";

        public LanguageAbstractTalent(String name, List<DSA_ATTRIBUTE> probe, List<String>complex) : base(name, probe, convertComplexListtoString(complex), null, null){}
        static private String convertComplexListtoString(List<String> complex)
        {
            String ret = "";
            for(int i=0; i<complex.Count; i++)
            {
                int x = 0;

                if (Int32.TryParse(complex[i], out x))
                {
                    if (i == 0)
                    {
                        ret = ret + complex[i].ToString();
                    }
                    else
                    {
                        if (i == 1)
                        {
                            ret = ret + "(" + complex[i].ToString();
                        }
                        else
                        {
                            ret = ret + "," + complex[i].ToString();
                        }
                        if (i == (complex.Count - 1))
                        {
                            ret = ret + ")";
                        }
                    }
                }
            }
            return ret;
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
        public void setPOS(int pos)
        {
            this.pos = pos;
        }
        public String getMotherMark()
        {
            return motherMark;
        }
        public int getPOS()
        {
            return pos;
        }
        
    }
}
