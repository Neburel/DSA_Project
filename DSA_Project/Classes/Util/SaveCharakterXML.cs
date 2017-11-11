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

            //Andere.....
            XmlElement ModifikatorenElement             = characterFile.CreateElement("Modifikatoren");
            XmlElement GöttergeschenkeElement           = characterFile.CreateElement("Göttergeschenke");

            BasisDatenElement.AppendChild(ModifikatorenElement);
            BasisDatenElement.AppendChild(GöttergeschenkeElement);       
        }
    }
}
