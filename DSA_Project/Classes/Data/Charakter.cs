using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
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

        //Basic Values
        int Beherschungswert = 0;
        int Entrückung = 0;
        int Geschwindigkeit = 0;

        //Basic Value Modifikation
        int AttackeBasisMOD         = 1;
        int ParadeBasisMOD          = 1;
        int FernkampfBasisMOD       = 1;
        int InitativeBasisMOD       = 1;
        int BeherschungswertMOD     = 1;
        int ArtefaktkontrolleMOD    = 1;
        int WundschwelleMOD         = 1;
        int EntrückungMOD           = 1;
        int GeschwindigkeitMOD      = 1;

        //EnergieMOD
        int LebensEnergieMOD        = 1;
        int AusdauerEnergieMOD      = 1;
        int AstralEnergieMOD        = 1;
        int KarmaenergieMOD         = 1;
        int MagieresistenzMOD       = 1;

        //Geld
        int Bank                    = 0;
        int Dukaten                 = 0;
        int Silber                  = 0;
        int Heller                  = 0;
        int Kupfer                  = 0;

        //Features
        Feature[] Vorteile          = new Feature[0];
        Feature[] Nachteile         = new Feature[0];

        public void setMoney(DSA_MONEY type, int value)
        {
            switch (type)
            {
                case DSA_MONEY.D: Dukaten = value; break;
                case DSA_MONEY.S: Silber = value; break;
                case DSA_MONEY.H: Heller = value; break;
                case DSA_MONEY.K: Kupfer = value; break;
                case DSA_MONEY.BANK: Bank = value; break; 
            }
        }
        public int getMoney(DSA_MONEY type )
        {
            int ret = 0;
            switch (type)
            {
                case DSA_MONEY.D: ret = Dukaten; break;
                case DSA_MONEY.S: ret = Silber; break;
                case DSA_MONEY.H: ret = Heller; break;
                case DSA_MONEY.K: ret = Kupfer; break;
                case DSA_MONEY.BANK: ret = Bank; break;
            }
            return ret;
        }


        private int getFeaturePoints(DSA_FEATURES ftype, DSA_FEATUREBONUS btype)
        {
            Feature[] farray = null;
            int points = 0;             

            switch (ftype)
            {
                case DSA_FEATURES.VORTEIL: farray = Vorteile; break;
                case DSA_FEATURES.NACHTEIL: farray = Nachteile; break;
            }
            
            for (int i=1; i<farray.Length; i++)
            {
                if(farray[i].getType() == btype)
                {
                    points = points + farray[i].getBonus();
                }
            }
            Console.WriteLine("FeaturePoints:" + points);
            return points;
        }


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
        public String[] getBasicValue(DSA_BASICVALUES value)
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
        public void setAttribute(DSA_ATTRIBUTE attribute, int wert)
        {
            switch (attribute)
            {
                case DSA_ATTRIBUTE.MUT:                 Mut                 = wert; break;
                case DSA_ATTRIBUTE.KLUGHEIT:            Klugheit            = wert; break;
                case DSA_ATTRIBUTE.INTUITION:           Intuition           = wert; break;
                case DSA_ATTRIBUTE.CHARISMA:            Charisma            = wert; break;
                case DSA_ATTRIBUTE.FINGERFERTIGKEIT:    Fingerfertigkeit    = wert; break;
                case DSA_ATTRIBUTE.GEWANDHEIT:          Gewandheit          = wert; break;
                case DSA_ATTRIBUTE.KONSTITUTION:        Konstitution        = wert; break;
                case DSA_ATTRIBUTE.KÖRPERKRAFT:         Körperkraft         = wert; break;
                case DSA_ATTRIBUTE.SOZAILSTATUS:        Sozailstatus        = wert; break;
            }
        }
        public int getAttributeAKT(DSA_ATTRIBUTE attribute)
        {
            switch (attribute)
            {
                case DSA_ATTRIBUTE.MUT:                 return Mut; 
                case DSA_ATTRIBUTE.KLUGHEIT:            return Klugheit;
                case DSA_ATTRIBUTE.INTUITION:           return Intuition; 
                case DSA_ATTRIBUTE.CHARISMA:            return Charisma; 
                case DSA_ATTRIBUTE.FINGERFERTIGKEIT:    return Fingerfertigkeit; 
                case DSA_ATTRIBUTE.GEWANDHEIT:          return Gewandheit; 
                case DSA_ATTRIBUTE.KONSTITUTION:        return Konstitution; 
                case DSA_ATTRIBUTE.KÖRPERKRAFT:         return Körperkraft; 
                case DSA_ATTRIBUTE.SOZAILSTATUS:        return Sozailstatus;
                case DSA_ATTRIBUTE.SUMME:               return Mut + Klugheit + Intuition + Charisma + Fingerfertigkeit + Gewandheit + Konstitution + Körperkraft + Sozailstatus;
            }
            return 0;
        }
        public int getAttribute_Mod(DSA_ATTRIBUTE attribute)
        {
            switch (attribute)
            {
                case DSA_ATTRIBUTE.MUT:                 return Mut_mod;
                case DSA_ATTRIBUTE.KLUGHEIT:            return Klugheit_mod;
                case DSA_ATTRIBUTE.INTUITION:           return Intuition_mod;
                case DSA_ATTRIBUTE.CHARISMA:            return Charisma_mod;
                case DSA_ATTRIBUTE.FINGERFERTIGKEIT:    return Fingerfertigkeit_mod;
                case DSA_ATTRIBUTE.GEWANDHEIT:          return Gewandheit_mod;
                case DSA_ATTRIBUTE.KONSTITUTION:        return Konstitution_mod;
                case DSA_ATTRIBUTE.KÖRPERKRAFT:         return Körperkraft_mod;
                case DSA_ATTRIBUTE.SOZAILSTATUS:        return Sozailstatus_mod;
            }
            return 0;
        }
        public int getAttribute_Max(DSA_ATTRIBUTE attribute)
        {
            switch (attribute)
            {
                case DSA_ATTRIBUTE.MUT:                 return (Mut+getFeaturePoints(DSA_FEATURES.VORTEIL, DSA_FEATUREBONUS.MUT)) * Mut_mod;
                case DSA_ATTRIBUTE.KLUGHEIT:            return Klugheit * Klugheit_mod;
                case DSA_ATTRIBUTE.INTUITION:           return Intuition * Intuition_mod;
                case DSA_ATTRIBUTE.CHARISMA:            return Charisma * Charisma_mod;
                case DSA_ATTRIBUTE.FINGERFERTIGKEIT:    return Fingerfertigkeit * Fingerfertigkeit_mod;
                case DSA_ATTRIBUTE.GEWANDHEIT:          return Gewandheit * Gewandheit_mod;
                case DSA_ATTRIBUTE.KONSTITUTION:        return Konstitution * Konstitution_mod;
                case DSA_ATTRIBUTE.KÖRPERKRAFT:         return Körperkraft * Körperkraft_mod;
                case DSA_ATTRIBUTE.SOZAILSTATUS:        return Sozailstatus * Sozailstatus_mod;
                case DSA_ATTRIBUTE.SUMME:               return Mut * Mut_mod + Klugheit * Klugheit_mod + Intuition * Intuition_mod + Charisma * Charisma_mod + Fingerfertigkeit * Fingerfertigkeit_mod
                                                                    + Gewandheit * Gewandheit_mod + Konstitution * Konstitution_mod + Körperkraft * Körperkraft_mod + Sozailstatus * Sozailstatus_mod;
            }
            return 0;
        }
        

        public int getAdvancedValueAKT(DSA_ADVANCEDVALUES value)
        {
            switch (value)
            {
                case DSA_ADVANCEDVALUES.ATTACKE_BASIS:
                    Double attacBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MUT) + getAttribute_Max(DSA_ATTRIBUTE.GEWANDHEIT) + getAttribute_Max(DSA_ATTRIBUTE.KÖRPERKRAFT)) / 5;
                    return (int)Math.Ceiling(attacBasis);
                case DSA_ADVANCEDVALUES.PARADE_BASIS:
                    Double paradeBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.INTUITION) + getAttribute_Max(DSA_ATTRIBUTE.GEWANDHEIT) + getAttribute_Max(DSA_ATTRIBUTE.KÖRPERKRAFT)) / 5;
                    return (int)Math.Ceiling(paradeBasis);
                case DSA_ADVANCEDVALUES.FERNKAMPF_BASIS:
                    Double fernkampfBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.INTUITION) + getAttribute_Max(DSA_ATTRIBUTE.FINGERFERTIGKEIT) + getAttribute_Max(DSA_ATTRIBUTE.KÖRPERKRAFT)) / 5;
                    return (int)Math.Ceiling(fernkampfBasis);
                case DSA_ADVANCEDVALUES.INITATIVE_BASIS:
                    Double initativeBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MUT) + getAttribute_Max(DSA_ATTRIBUTE.MUT) + getAttribute_Max(DSA_ATTRIBUTE.INTUITION) + getAttribute_Max(DSA_ATTRIBUTE.GEWANDHEIT)) / 5;
                    return (int)Math.Ceiling(initativeBasis);
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:
                    return (Beherschungswert);
                case DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE:
                    Double artefaktkontrolle = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.INTUITION)+getEnergieVOR(DSA_ENERGIEN.MAGIERESISTENZ));
                    return (int)Math.Ceiling(artefaktkontrolle);
                case DSA_ADVANCEDVALUES.WUNDSCHWELLE:
                    Double wundschwelle = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.KONSTITUTION)) / 2;
                    return (int)Math.Ceiling(wundschwelle);
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:
                    return (Entrückung);
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:
                    return (Geschwindigkeit);
            }
            return 0;
        }
        public int getAdvancedValueMOD(DSA_ADVANCEDVALUES value)
        {
            Double ret = 0;
            switch (value)
            {
                case DSA_ADVANCEDVALUES.ATTACKE_BASIS:      ret = AttackeBasisMOD;      break;
                case DSA_ADVANCEDVALUES.PARADE_BASIS:       ret = ParadeBasisMOD;       break;
                case DSA_ADVANCEDVALUES.FERNKAMPF_BASIS:    ret = FernkampfBasisMOD;    break;
                case DSA_ADVANCEDVALUES.INITATIVE_BASIS:    ret = InitativeBasisMOD;    break;
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:   ret = BeherschungswertMOD;  break;
                case DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE:  ret = ArtefaktkontrolleMOD; break;
                case DSA_ADVANCEDVALUES.WUNDSCHWELLE:       ret = WundschwelleMOD;      break;
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:         ret = EntrückungMOD;        break;
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:    ret = GeschwindigkeitMOD;   break;
                default: throw new Exception();
            }
            return (int)ret;
        }
        public int getAdvancedValueMAX(DSA_ADVANCEDVALUES value)
        {
            Double ret = 0;
            switch (value)
            {
                case DSA_ADVANCEDVALUES.ATTACKE_BASIS: ret      = getAdvancedValueAKT(value) * AttackeBasisMOD;        break;
                case DSA_ADVANCEDVALUES.PARADE_BASIS: ret       = getAdvancedValueAKT(value) * ParadeBasisMOD;         break;
                case DSA_ADVANCEDVALUES.FERNKAMPF_BASIS: ret    = getAdvancedValueAKT(value) * FernkampfBasisMOD;      break;
                case DSA_ADVANCEDVALUES.INITATIVE_BASIS: ret    = getAdvancedValueAKT(value) * InitativeBasisMOD;      break;
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT: ret   = getAdvancedValueAKT(value) * BeherschungswertMOD;    break;
                case DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE: ret  = getAdvancedValueAKT(value) * ArtefaktkontrolleMOD;   break;
                case DSA_ADVANCEDVALUES.WUNDSCHWELLE: ret       = getAdvancedValueAKT(value) * WundschwelleMOD;        break;
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG: ret         = getAdvancedValueAKT(value) * EntrückungMOD;          break;
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT: ret    = getAdvancedValueAKT(value) * GeschwindigkeitMOD;     break;
                default: throw new Exception();
            }
            return (int)ret;

        }


        public int getEnergieVOR(DSA_ENERGIEN energie)
        {
            switch (energie)
            {
                case (DSA_ENERGIEN.LEBENSENERGIE):
                    Double lebensenergie = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.KONSTITUTION) + getAttribute_Max(DSA_ATTRIBUTE.KONSTITUTION) + getAttribute_Max(DSA_ATTRIBUTE.KÖRPERKRAFT)) / 2;
                    return (int)Math.Ceiling(lebensenergie);
                case (DSA_ENERGIEN.AUSDAUER):
                    Double ausdauer = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MUT) + getAttribute_Max(DSA_ATTRIBUTE.GEWANDHEIT) + getAttribute_Max(DSA_ATTRIBUTE.KONSTITUTION)) / 2;
                    return (int)Math.Ceiling(ausdauer);
                case (DSA_ENERGIEN.ASTRALENERGIE):
                    Double astralenergie = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MUT) + getAttribute_Max(DSA_ATTRIBUTE.INTUITION) + getAttribute_Max(DSA_ATTRIBUTE.CHARISMA)) / 2;
                    return (int)Math.Ceiling(astralenergie);
                case (DSA_ENERGIEN.KARMAENERGIE):
                    return 0;
                case (DSA_ENERGIEN.MAGIERESISTENZ):
                    Double magieresistenz = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MUT) + getAttribute_Max(DSA_ATTRIBUTE.KLUGHEIT) + getAttribute_Max(DSA_ATTRIBUTE.KONSTITUTION)) / 5;
                    return (int)Math.Ceiling(magieresistenz);
            }
            return 0;
        }
        public int getEnergiePERM(DSA_ENERGIEN energie)
        {
            return 0;
        }
        public int getEnergieMOD(DSA_ENERGIEN energie)
        {
            int ret = 0;
            switch (energie)
            {
                case (DSA_ENERGIEN.LEBENSENERGIE):  ret = LebensEnergieMOD; break;
                case (DSA_ENERGIEN.AUSDAUER):       ret = AusdauerEnergieMOD; break;
                case (DSA_ENERGIEN.ASTRALENERGIE):  ret = AstralEnergieMOD; break;
                case (DSA_ENERGIEN.KARMAENERGIE):   ret = KarmaenergieMOD; break;
                case (DSA_ENERGIEN.MAGIERESISTENZ): ret = MagieresistenzMOD; break;
            }
            return ret;
        }
        public int getEnergieMALI(DSA_ENERGIEN energe)
        {
            return 0;
        }
        public int getEnergieMAX(DSA_ENERGIEN energie)
        {
            int ret = 0;
            switch (energie)
            {
                case (DSA_ENERGIEN.LEBENSENERGIE):  ret = getEnergieVOR(DSA_ENERGIEN.LEBENSENERGIE) * LebensEnergieMOD; break;
                case (DSA_ENERGIEN.AUSDAUER):       ret = getEnergieVOR(DSA_ENERGIEN.AUSDAUER) * AusdauerEnergieMOD; break;
                case (DSA_ENERGIEN.ASTRALENERGIE):  ret = getEnergieVOR(DSA_ENERGIEN.ASTRALENERGIE) * AstralEnergieMOD; break;
                case (DSA_ENERGIEN.KARMAENERGIE):   ret = getEnergieVOR(DSA_ENERGIEN.KARMAENERGIE) * KarmaenergieMOD; break;
                case (DSA_ENERGIEN.MAGIERESISTENZ): ret = getEnergieVOR(DSA_ENERGIEN.MAGIERESISTENZ) * MagieresistenzMOD; break;
            }
            return ret;
        }


        public void addFeature(DSA_FEATURES type, int number, Feature feature)
        {
            switch (type)
            {
                case DSA_FEATURES.VORTEIL:  setVorteil(number, feature); break;
                case DSA_FEATURES.NACHTEIL: setNachteil(number, feature); break;
            }
        }
        private void setVorteil(int number, Feature feature)
        {
            if(Vorteile.Length-1 < number)
            {   
                Console.WriteLine("Vorteile + 1");
                Array.Resize(ref Vorteile, Vorteile.Length +1);
                setVorteil(number, feature);
                return;
            }
            Vorteile[number] = feature;
        }
        private void setNachteil(int number, Feature feature)
        {
            if (Nachteile.Length-1 < number)
            {
                Array.Resize(ref Vorteile, Nachteile.Length + 1);
                setNachteil(number, feature);
            }
            Nachteile[number] = feature;
        }
        public Feature getVorteil(int number)
        {
            Feature ret = null;
            if (number < Vorteile.Length) ret = Vorteile[number];
            return ret;
        }
        public Feature getNachteil(int number)
        {
            Feature ret = null;
            if (Nachteile.Length < number) ret = Nachteile[number];
            return ret;
        }



    }
}
