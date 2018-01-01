﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class LanguageFamily : InterfaceTalent
    {
        private Charakter charakter;
        private String Name;
        private List<LanguageTalent> langageTalentlist;
        private List<FontTalent> fontTalentList;

        public LanguageFamily()
        {
            Name = "newName";
            langageTalentlist = new List<LanguageTalent>(0);
            fontTalentList = new List<FontTalent>(0);
        }

        public void setName(String name)
        {
            Name = name;
        }
        public String getName()
        {
            return this.Name;
        }

        public void add(LanguageTalent languageTalent, FontTalent fontTalent)
        {
            langageTalentlist.Add(languageTalent);
            fontTalentList.Add(fontTalent);
        }
        public LanguageTalent getlanguageTalent(int number)
        {
            return langageTalentlist[number];
        }
        public FontTalent getFontTalent(int number)
        {
            return fontTalentList[number];
        }
        public int count()
        {
            return langageTalentlist.Count;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void setCharacter(Charakter charakter)
        {
            this.charakter = charakter;
        }

        public void setTaw(string taw)
        {
            throw new NotImplementedException();
        }

        public int getProbeCount()
        {
            throw new NotImplementedException();
        }

        public string getBe()
        {
            throw new NotImplementedException();
        }

        public string getTaW()
        {
            throw new NotImplementedException();
        }

        public string getProbeStringOne()
        {
            throw new NotImplementedException();
        }

        public string getProbeStringTwo()
        {
            throw new NotImplementedException();
        }

        public string getDeviateString()
        {
            throw new NotImplementedException();
        }

        public string getTAWBonus()
        {
            throw new NotImplementedException();
        }
    }
}