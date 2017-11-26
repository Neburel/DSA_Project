using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSA_Project
{
    /*
     * Klasse wird über Namen des Talents erstellt
     * Das talent Selbst wird später Nachgeladen
     * 
     * */
    public class TalentDiverate

    {
        private InterfaceTalent Talent;
        private String Talentname;
        private int RequirementTaW;
      

        public TalentDiverate(String TalentName, int requirementTaW)
        {
            this.Talentname         = TalentName;
            this.RequirementTaW     = requirementTaW;
        }

        public String getName()
        {
            return Talentname;
        }
        public int getRequiredTaW()
        {
            return RequirementTaW;
        }
    }
}