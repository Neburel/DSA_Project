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
        String getBe();
        String getTaW();
        String getProbeStringOne();
        String getProbeStringTwo();
        String getDeviateString();
    }
}
