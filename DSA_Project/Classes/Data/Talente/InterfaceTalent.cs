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
        void setTaw(int taw);
        void setTaw(String taw);
        String getName();
        String getAbleitenString();
        String getProbeStringTwo();
        int getProbeCount();
        String getProbeStringOne();
        String getBe();
        int getTaW();
    }
}
