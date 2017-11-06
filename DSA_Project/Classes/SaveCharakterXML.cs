using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSA_Project
{
    static class SaveCharakterXML
    {
        public static void saveCharakter(Charakter charakter, string fileName)
        {
            Console.WriteLine("FileName:" + fileName);

            XmlDocument characterFile = new XmlDocument();
            XmlElement CharakterBogenElement = (XmlElement)characterFile.AppendChild(characterFile.CreateElement("CharakterBogen"));
            XmlElement HeldenBriefElement = characterFile.CreateElement("HeldenBrief");
            XmlElement BasisDatenElement = characterFile.CreateElement("BasisDaten");

            saveBasisDaten(charakter, characterFile, BasisDatenElement);

            CharakterBogenElement.AppendChild(HeldenBriefElement);
            HeldenBriefElement.AppendChild(BasisDatenElement);

            /*Dateiendung XML?*/
            string fileEndung = fileName.Substring(fileName.Length - 4);
            if(fileEndung != ".xml")
            {
                fileName = fileName + ".xml";
            }
            characterFile.Save(fileName);
        }
        public static void saveBasisDaten(Charakter charakter, XmlDocument characterFile, XmlElement BasisDatenElement)
        {
            BasisDatenElement.AppendChild(characterFile.CreateElement("Name")).InnerText                = charakter.getBasicValue(DSA_BASICVALUES.NAME)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("AlterGeburstag")).InnerText      = charakter.getBasicValue(DSA_BASICVALUES.ALTER)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Geschlecht")).InnerText          = charakter.getBasicValue(DSA_BASICVALUES.GESCHLECHT)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Größe")).InnerText               = charakter.getBasicValue(DSA_BASICVALUES.GRÖSE)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Gewicht")).InnerText             = charakter.getBasicValue(DSA_BASICVALUES.GEWICHT)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Augenfarbe")).InnerText          = charakter.getBasicValue(DSA_BASICVALUES.AUGENFARBE)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("HaarFellFarbe")).InnerText       = charakter.getBasicValue(DSA_BASICVALUES.HAARFARBE)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Hautfarbe")).InnerText           = charakter.getBasicValue(DSA_BASICVALUES.HAUTFARBE)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Familienstand")).InnerText       = charakter.getBasicValue(DSA_BASICVALUES.FAMILIENSTAND)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Anrede")).InnerText              = charakter.getBasicValue(DSA_BASICVALUES.ANREDE)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Gottheit-en")).InnerText         = charakter.getBasicValue(DSA_BASICVALUES.GOTTHEIT)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Resse-en")).InnerText            = charakter.getBasicValue(DSA_BASICVALUES.RASSE)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Kultur-en")).InnerText           = charakter.getBasicValue(DSA_BASICVALUES.KULTUR)[0];
            BasisDatenElement.AppendChild(characterFile.CreateElement("Profession")).InnerText          = charakter.getBasicValue(DSA_BASICVALUES.PROFESSION)[0];

            //Andere.....
            XmlElement ModifikatorenElement             = characterFile.CreateElement("Modifikatoren");
            XmlElement GöttergeschenkeElement           = characterFile.CreateElement("Göttergeschenke");

            BasisDatenElement.AppendChild(ModifikatorenElement);
            BasisDatenElement.AppendChild(GöttergeschenkeElement);

            String[] Modifikatoren = charakter.getBasicValue(DSA_BASICVALUES.MODIFIKATOREN);
            String[] Göttergeschenke = charakter.getBasicValue(DSA_BASICVALUES.GÖTTERGESCHENKE);
            
            for (int i=0; i < Modifikatoren.Length; i++)
            {
                ModifikatorenElement.AppendChild(characterFile.CreateElement("Modifikatoren" + (i + 1).ToString())).InnerText = Göttergeschenke[i];
            }
            for (int i = 0; i < Göttergeschenke.Length; i++)
            {
                GöttergeschenkeElement.AppendChild(characterFile.CreateElement("Modifikatoren" + (i + 1).ToString())).InnerText = Göttergeschenke[i];
            }            
        }
    }
}
