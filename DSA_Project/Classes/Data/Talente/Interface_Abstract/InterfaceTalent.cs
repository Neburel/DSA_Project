using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public interface InterfaceTalent
    {
        void setCharacter(Charakter charakter);
        void setTaw(String taw);
        int getProbeCount();
        String getName();
        String getComplexName();                //Einmaliger Name!
        String getBe();
        String getTaW();
        String getTAWBonus();
        String getProbeStringOne();
        String getProbeStringTwo();
        String getDeviateString();
    }
}
