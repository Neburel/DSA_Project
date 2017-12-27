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
    public class TalentDeviate
    {
        private InterfaceTalent Talent;
        private String Talentname;
        private int RequirementTaW;
      

        public TalentDeviate(String TalentName, int requirementTaW)
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