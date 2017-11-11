using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace DSA_Project
{
    //*toDO: try Am obersten Punkt, bei Misserfolg alles als Korrupt erklären (Simple Lösung)
    static class LoadCharakterXML
    {
        private static String Heldenbrief   = "/CharakterBogen/HeldenBrief";
        public static Charakter loadCharakter(String fileName)
        {
            Charakter charakter = new Charakter();

            XmlDocument characterFile = new XmlDocument();
            characterFile.Load(fileName);

            loadHeldenbrief(characterFile.SelectSingleNode(Heldenbrief), charakter);
            
            
            return charakter;
        }
        private static void loadHeldenbrief(XmlNode HeldenbriefNode, Charakter charakter)
        {
            foreach(XmlNode node in HeldenbriefNode)
            {
                switch (node.Name)
                {
                    case "BasisDaten": loadBasicData(node, charakter); break;
                    case "Attribute": loadAttribute(node, charakter); break;
                }
            }            
        }
        private static void loadBasicData(XmlNode BasicDataNode, Charakter charakter)
        {
            if(BasicDataNode == null)
            {
                Console.WriteLine("BasisDaten is null");
                return;
            }
            
            foreach (XmlNode node in BasicDataNode)
            {
                switch (node.Name)
                {
                    case "Name":                charakter.setBasicValues(DSA_BASICVALUES.NAME, node.InnerText);             break;
                    case "AlterGeburstag":      charakter.setBasicValues(DSA_BASICVALUES.ALTER, node.InnerText);            break;
                    case "Geschlecht":          charakter.setBasicValues(DSA_BASICVALUES.GESCHLECHT, node.InnerText);       break;
                    case "Größe":               charakter.setBasicValues(DSA_BASICVALUES.GRÖSE, node.InnerText);            break;
                    case "Gewicht":             charakter.setBasicValues(DSA_BASICVALUES.GEWICHT, node.InnerText);          break;
                    case "Augenfarbe":          charakter.setBasicValues(DSA_BASICVALUES.AUGENFARBE, node.InnerText);       break;
                    case "HaarFellFarbe":       charakter.setBasicValues(DSA_BASICVALUES.HAARFARBE, node.InnerText);        break;
                    case "Hautfarbe":           charakter.setBasicValues(DSA_BASICVALUES.HAUTFARBE, node.InnerText);        break;
                    case "Familienstand":       charakter.setBasicValues(DSA_BASICVALUES.FAMILIENSTAND, node.InnerText);    break;
                    case "Anrede":              charakter.setBasicValues(DSA_BASICVALUES.ANREDE, node.InnerText);           break;
                    case "Gottheit-en":         charakter.setBasicValues(DSA_BASICVALUES.GOTTHEIT, node.InnerXml);          break;
                    case "Resse-en":            charakter.setBasicValues(DSA_BASICVALUES.RASSE, node.InnerText);            break;
                    case "Kultur-en":           charakter.setBasicValues(DSA_BASICVALUES.KULTUR, node.InnerText);           break;
                    case "Profession-en":       charakter.setBasicValues(DSA_BASICVALUES.PROFESSION, node.InnerText);       break;
                }
            }

        }
        private static void loadAttribute(XmlNode AttributeNode, Charakter charakter)
        {
            if (AttributeNode == null)
            {
                Console.WriteLine("Attribute is null");
                return;
            }

            foreach (XmlNode node in AttributeNode)
            {
                switch (node.Name)
                {
                    case "AKT":
                        foreach (XmlNode AKTAttributeNode in node)
                        {
                            int.TryParse(AKTAttributeNode.InnerText, out var newValue);
                            switch (AKTAttributeNode.Name)
                            {
                                case "Mut": charakter.setAttribute(DSA_ATTRIBUTE.MUT, newValue); break;
                                case "Klugheit": charakter.setAttribute(DSA_ATTRIBUTE.KLUGHEIT, newValue); break;
                                case "Intuition": charakter.setAttribute(DSA_ATTRIBUTE.INTUITION, newValue); break;
                                case "Charisma": charakter.setAttribute(DSA_ATTRIBUTE.CHARISMA, newValue); break;
                                case "Fingerfertigkeit": charakter.setAttribute(DSA_ATTRIBUTE.FINGERFERTIGKEIT, newValue); break;
                                case "Gewandheit": charakter.setAttribute(DSA_ATTRIBUTE.GEWANDHEIT, newValue); break;
                                case "Konstitution": charakter.setAttribute(DSA_ATTRIBUTE.KONSTITUTION, newValue); break;
                                case "Körperkraft": charakter.setAttribute(DSA_ATTRIBUTE.KÖRPERKRAFT, newValue); break;
                                case "Sozialstatus": charakter.setAttribute(DSA_ATTRIBUTE.SOZAILSTATUS, newValue); break;
                            }

                

                        }
                        break;

                }
            }
        }
    }
}
