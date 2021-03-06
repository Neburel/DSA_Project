﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DSA_ProjectTests1._01_TestUtil;

namespace DSA_Project.Tests
{
    [TestClass()]
    public abstract class Abstract_LoadCharakterXMLTests : CharakterTestsAbstract
    {
        private ControllTalent controllTalent;

        abstract public List<String> getGiftTalents();
        abstract public String getResourceName();
        abstract public String getLoadFileName();
        internal virtual String getSaveFileName()
        {
            return getLoadFileName();
        }

        internal virtual bool getSaveFirst()
        {
            return false;
        }

        [TestInitialize]
        public void setUP_Abstract_LoadCharakterXMLTest()
        {
            Console.WriteLine("setUP_Abstract_LoadCharakterXMLTest");

            setUP_Controller();

            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, getResourceName());
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);
            path = Path.Combine(path, getLoadFileName());

            if (getSaveFirst() == true)
            {
                String file = ResourceAcess.getSaveFile(getResourceName(), getSaveFileName());
                SaveCharakterXML.saveCharakter(charakter, file);
            }

            charakter = LoadCharakterXML.loadCharakter(path, charakter, this.controllTalent);
        }

        private void setUP_Controller()
        {
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, getResourceName());
            
            if (controllTalent == null)
            {
                controllTalent = new ControllTalent(path);
            }
        }
        public override List<InterfaceTalent> getTalentList()
        {
            setUP_Controller();

            List<InterfaceTalent> list = new List<InterfaceTalent>();
            List<String> gifts = getGiftTalents();

            list.AddRange(controllTalent.getTalentList<TalentClose>());
            list.AddRange(controllTalent.getTalentList<TalentRange>());
            list.AddRange(controllTalent.getTalentList<TalentWeaponless>());

            list.AddRange(controllTalent.getTalentList<TalentCrafting>());
            list.AddRange(controllTalent.getTalentList<TalentKnwoldage>());
            list.AddRange(controllTalent.getTalentList<TalentNature>());
            list.AddRange(controllTalent.getTalentList<TalentPhysical>());
            list.AddRange(controllTalent.getTalentList<TalentSocial>());

            list.AddRange(controllTalent.getTalentList<LanguageTalent>());
            list.AddRange(controllTalent.getTalentList<FontTalent>());

            for(int i=0; i<gifts.Count; i++)
            {
                InterfaceTalent talent = controllTalent.getTalent(gifts[i]);
                list.Add(talent);
            }


            return list;
        }
    }
}