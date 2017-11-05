using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, GÖTTERGESCHENKE, RASSE, KULTUR, PROFESSION, MODIFIKATOREN }
    enum DSA_Attribute { MUT, KLUGHEIT, INTUITION, CHARISMA, FINGERFERTIGKEIT, GEWANDHEIT, KONSTITUTION, KÖRPERKRAFT, SOZAILSTATUS }
    enum DSA_ADVANCEDVALUES { ATTACKE_BASIS, PARADE_BASIS, FERNKAMPF_BASIS, INITATIVE_BASIS, BEHERSCHUNGSWERT, ARTEFAKTKONTROLLE, WUNDSCHWELLE, ENTRÜCKUNG, GESCHWINDIGKEIT }
    enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    class Charakter
    {
        //BasicValues
        String Name = "";
        String Alter = "";
        String Geschlecht = "";
        String Größe = "";
        String Gewicht = "";
        String Augenfarbe = "";
        String Hautfarbe = "";
        String Haarfarbe = "";
        String Familienstand = "";
        String Anrede = "";
        String Gottheit = "";
        String Rasse = "";
        String Kultur = "";
        String Profession = "";
        List<String> Modifikatoren = new List<string>();
        List<String> Göttergeschenke = new List<string>();
        //BasicValues Ende

        //Attribute;
        int Mut = 0;
        int Klugheit = 0;
        int Intuition = 0;
        int Charisma = 0;
        int Fingerfertigkeit = 0;
        int Gewandheit = 0;
        int Konstitution = 0;
        int Körperkraft = 0;
        int Sozailstatus = 0;
        //Attribute Ende;

        //Attribute Modifikatioren
        int Mut_mod = 1;
        int Klugheit_mod = 1;
        int Intuition_mod = 1;
        int Charisma_mod = 1;
        int Fingerfertigkeit_mod = 1;
        int Gewandheit_mod = 1;
        int Konstitution_mod = 1;
        int Körperkraft_mod = 1;
        int Sozailstatus_mod = 1;
        //Attribute Modifikatoren Ende

        //Basic Values
        int Beherschungswert = 0;
        int Entrückung = 0;
        int Geschwindigkeit = 0;
        
        public void setBasicValues(DSA_BASICVALUES value, String stringValue)
        {  
            switch (value)
            {
                case DSA_BASICVALUES.NAME: Name = stringValue; break;
                case DSA_BASICVALUES.ALTER: Alter = stringValue; break;
                case DSA_BASICVALUES.GESCHLECHT: Geschlecht = stringValue; break;
                case DSA_BASICVALUES.GRÖSE: Größe = stringValue; break;
                case DSA_BASICVALUES.GEWICHT: Gewicht = stringValue; break;
                case DSA_BASICVALUES.AUGENFARBE: Augenfarbe = stringValue; break;
                case DSA_BASICVALUES.HAARFARBE: Haarfarbe = stringValue; break;
                case DSA_BASICVALUES.HAUTFARBE: Hautfarbe = stringValue; break;
                case DSA_BASICVALUES.FAMILIENSTAND: Familienstand = stringValue; break;
                case DSA_BASICVALUES.ANREDE: Anrede = stringValue; break;
                case DSA_BASICVALUES.GOTTHEIT: Gottheit = stringValue; break;
                case DSA_BASICVALUES.RASSE: Rasse = stringValue; break;
                case DSA_BASICVALUES.KULTUR: Kultur = stringValue; break;
                case DSA_BASICVALUES.PROFESSION: Profession = stringValue; break;
                case DSA_BASICVALUES.MODIFIKATOREN:   if (stringValue == "") break; Modifikatoren.Add(stringValue); break;
                case DSA_BASICVALUES.GÖTTERGESCHENKE: if (stringValue == "") break; Göttergeschenke.Add(stringValue); break;
            }
        }
        public String[] getBasicValues(DSA_BASICVALUES value)
        {
            String[] ret;
            int i;

            switch (value)
            {
                case DSA_BASICVALUES.NAME:              return new[] { Name }; 
                case DSA_BASICVALUES.ALTER:             return new[] { Alter }; 
                case DSA_BASICVALUES.GESCHLECHT:        return new[] { Geschlecht }; 
                case DSA_BASICVALUES.GRÖSE:             return new[] { Größe }; 
                case DSA_BASICVALUES.GEWICHT:           return new[] { Gewicht };
                case DSA_BASICVALUES.AUGENFARBE:        return new[] { Augenfarbe };
                case DSA_BASICVALUES.HAARFARBE:         return new[] { Haarfarbe };
                case DSA_BASICVALUES.HAUTFARBE:         return new[] { Hautfarbe };
                case DSA_BASICVALUES.FAMILIENSTAND:     return new[] { Familienstand };
                case DSA_BASICVALUES.ANREDE:            return new[] { Anrede };
                case DSA_BASICVALUES.GOTTHEIT:          return new[] { Gottheit };
                case DSA_BASICVALUES.RASSE:             return new[] { Rasse };
                case DSA_BASICVALUES.KULTUR:            return new[] { Kultur };
                case DSA_BASICVALUES.PROFESSION:        return new[] { Profession };
                case DSA_BASICVALUES.MODIFIKATOREN:
                    ret    = new String[Modifikatoren.Count];                    
                    i      = 0;
                    foreach (String Stringvalue in Modifikatoren)
                    {
                        ret[i] = Stringvalue;
                        Console.WriteLine(ret[i]);

                        i++;
                    }
                    return ret;
                case DSA_BASICVALUES.GÖTTERGESCHENKE:
                    ret = new String[Göttergeschenke.Count];
                    i = 0;
                    foreach (String Stringvalue in Göttergeschenke)
                    {
                        ret[i] = Stringvalue;
                        i++;
                    }
                    return ret;
            }
            return new[] { "" };
        }
        public void setAttribute(DSA_Attribute attribute, int wert)
        {
            switch (attribute)
            {
                case DSA_Attribute.MUT:                 Mut                 = wert; break;
                case DSA_Attribute.KLUGHEIT:            Klugheit            = wert; break;
                case DSA_Attribute.INTUITION:           Intuition           = wert; break;
                case DSA_Attribute.CHARISMA:            Charisma            = wert; break;
                case DSA_Attribute.FINGERFERTIGKEIT:    Fingerfertigkeit    = wert; break;
                case DSA_Attribute.GEWANDHEIT:          Gewandheit          = wert; break;
                case DSA_Attribute.KONSTITUTION:        Konstitution        = wert; break;
                case DSA_Attribute.KÖRPERKRAFT:         Körperkraft         = wert; break;
                case DSA_Attribute.SOZAILSTATUS:        Sozailstatus        = wert; break;
            }
        }
        public int getAttribute(DSA_Attribute attribute)
        {
            switch (attribute)
            {
                case DSA_Attribute.MUT:                 return Mut; 
                case DSA_Attribute.KLUGHEIT:            return Klugheit;
                case DSA_Attribute.INTUITION:           return Intuition; 
                case DSA_Attribute.CHARISMA:            return Charisma; 
                case DSA_Attribute.FINGERFERTIGKEIT:    return Fingerfertigkeit; 
                case DSA_Attribute.GEWANDHEIT:          return Gewandheit; 
                case DSA_Attribute.KONSTITUTION:        return Konstitution; 
                case DSA_Attribute.KÖRPERKRAFT:         return Körperkraft; 
                case DSA_Attribute.SOZAILSTATUS:        return Sozailstatus;
            }
            return 0;
        }
        public int getAttribute_Mod(DSA_Attribute attribute)
        {
            switch (attribute)
            {
                case DSA_Attribute.MUT:                 return Mut_mod;
                case DSA_Attribute.KLUGHEIT:            return Klugheit_mod;
                case DSA_Attribute.INTUITION:           return Intuition_mod;
                case DSA_Attribute.CHARISMA:            return Charisma_mod;
                case DSA_Attribute.FINGERFERTIGKEIT:    return Fingerfertigkeit_mod;
                case DSA_Attribute.GEWANDHEIT:          return Gewandheit_mod;
                case DSA_Attribute.KONSTITUTION:        return Konstitution_mod;
                case DSA_Attribute.KÖRPERKRAFT:         return Körperkraft_mod;
                case DSA_Attribute.SOZAILSTATUS:        return Sozailstatus_mod;
            }
            return 0;
        }
        public int getAttribute_Max(DSA_Attribute attribute)
        {
            switch (attribute)
            {
                case DSA_Attribute.MUT:                 return Mut * Mut_mod;
                case DSA_Attribute.KLUGHEIT:            return Klugheit * Klugheit_mod;
                case DSA_Attribute.INTUITION:           return Intuition * Intuition_mod;
                case DSA_Attribute.CHARISMA:            return Charisma * Charisma_mod;
                case DSA_Attribute.FINGERFERTIGKEIT:    return Fingerfertigkeit * Fingerfertigkeit_mod;
                case DSA_Attribute.GEWANDHEIT:          return Gewandheit * Gewandheit_mod;
                case DSA_Attribute.KONSTITUTION:        return Konstitution * Konstitution_mod;
                case DSA_Attribute.KÖRPERKRAFT:         return Körperkraft * Körperkraft_mod;
                case DSA_Attribute.SOZAILSTATUS:        return Sozailstatus * Sozailstatus_mod;
            }
            return 0;
        }
        public int getAttributeGesamt_AKT()
        {
            return Mut + Klugheit + Intuition + Charisma + Fingerfertigkeit + Gewandheit + Konstitution + Körperkraft + Sozailstatus;
        }
        public int getAttributeGesamt_MAX()
        {
            return Mut * Mut_mod + Klugheit * Klugheit_mod + Intuition * Intuition_mod + Charisma * Charisma_mod + Fingerfertigkeit * Fingerfertigkeit_mod
                                    + Gewandheit * Gewandheit_mod + Konstitution * Konstitution_mod + Körperkraft * Körperkraft_mod + Sozailstatus * Sozailstatus_mod;
        }
        public int getBasicValue_AKT(DSA_ADVANCEDVALUES value)
        {
            switch (value)
            {
                case DSA_ADVANCEDVALUES.ATTACKE_BASIS:
                    Double attacBasis = Convert.ToDouble(getAttribute_Max(DSA_Attribute.MUT) + getAttribute_Max(DSA_Attribute.GEWANDHEIT) + getAttribute_Max(DSA_Attribute.KÖRPERKRAFT)) / 5;
                    return (int)Math.Ceiling(attacBasis);
                case DSA_ADVANCEDVALUES.PARADE_BASIS:
                    Double paradeBasis = Convert.ToDouble(getAttribute_Max(DSA_Attribute.INTUITION) + getAttribute_Max(DSA_Attribute.GEWANDHEIT) + getAttribute_Max(DSA_Attribute.KÖRPERKRAFT)) / 5;
                    return (int)Math.Ceiling(paradeBasis);
                case DSA_ADVANCEDVALUES.FERNKAMPF_BASIS:
                    Double fernkampfBasis = Convert.ToDouble(getAttribute_Max(DSA_Attribute.INTUITION) + getAttribute_Max(DSA_Attribute.FINGERFERTIGKEIT) + getAttribute_Max(DSA_Attribute.KÖRPERKRAFT)) / 5;
                    return (int)Math.Ceiling(fernkampfBasis);
                case DSA_ADVANCEDVALUES.INITATIVE_BASIS:
                    Double initativeBasis = Convert.ToDouble(getAttribute_Max(DSA_Attribute.MUT) + getAttribute_Max(DSA_Attribute.MUT) + getAttribute_Max(DSA_Attribute.INTUITION) + getAttribute_Max(DSA_Attribute.GEWANDHEIT)) / 5;
                    return (int)Math.Ceiling(initativeBasis);
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:
                    return (Beherschungswert);
                case DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE:
                    Double artefaktkontrolle = Convert.ToDouble(getAttribute_Max(DSA_Attribute.INTUITION));
                    return (int)Math.Ceiling(artefaktkontrolle);
                case DSA_ADVANCEDVALUES.WUNDSCHWELLE:
                    Double wundschwelle = Convert.ToDouble(getAttribute_Max(DSA_Attribute.KONSTITUTION)) / 2;
                    return (int)Math.Ceiling(wundschwelle);
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:
                    return (Entrückung);
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:
                    return (Geschwindigkeit);
            }
            return 0;
        }
        public int getEnergie_VORERGEBNIS(DSA_ENERGIEN energie)
        {
            switch (energie)
            {
                case (DSA_ENERGIEN.LEBENSENERGIE):
                    Double lebensenergie = Convert.ToDouble(getAttribute_Max(DSA_Attribute.KONSTITUTION) + getAttribute_Max(DSA_Attribute.KONSTITUTION) + getAttribute_Max(DSA_Attribute.KÖRPERKRAFT)) / 2;
                    return (int)Math.Ceiling(lebensenergie);
                case (DSA_ENERGIEN.AUSDAUER):
                    Double ausdauer = Convert.ToDouble(getAttribute_Max(DSA_Attribute.MUT) + getAttribute_Max(DSA_Attribute.GEWANDHEIT) + getAttribute_Max(DSA_Attribute.KONSTITUTION)) / 2;
                    return (int)Math.Ceiling(ausdauer);
                case (DSA_ENERGIEN.ASTRALENERGIE):
                    Double astralenergie = Convert.ToDouble(getAttribute_Max(DSA_Attribute.MUT) + getAttribute_Max(DSA_Attribute.INTUITION) + getAttribute_Max(DSA_Attribute.CHARISMA)) / 2;
                    return (int)Math.Ceiling(astralenergie);
                case (DSA_ENERGIEN.KARMAENERGIE):
                    return 0;
                case (DSA_ENERGIEN.MAGIERESISTENZ):
                    Double magieresistenz = Convert.ToDouble(getAttribute_Max(DSA_Attribute.MUT) + getAttribute_Max(DSA_Attribute.KLUGHEIT) + getAttribute_Max(DSA_Attribute.KONSTITUTION)) / 5;
                    return (int)Math.Ceiling(magieresistenz);
            }
            return 0;
        }        



        int HP { get; set; }

    }
}
