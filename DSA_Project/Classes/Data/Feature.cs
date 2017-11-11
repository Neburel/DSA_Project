using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class Feature
    {
        String Name;
        String Description;
        String Value;
        String GP;
        
        Dictionary<DSA_ATTRIBUTE, int> attributeBonus;
        Dictionary<DSA_ENERGIEN, int> energieBonus;

        public Feature(String Name, String Description, String Value, String GP)
        {
            attributeBonus = new Dictionary<DSA_ATTRIBUTE, int>();
            energieBonus = new Dictionary<DSA_ENERGIEN, int>();

            setName(Name);
            setDescription(Description);
            setValue(Value);
            setGP(GP);
        }

        public void setName(String Name)
        {
            this.Name = Name;
        }
        public void setDescription(String Description)
        {
            this.Description = Description;
        }
        public void setValue(String Value)
        {
            int x = 0;
            if (Value.ToUpper().CompareTo("X") == 0)
            {
                this.Value = "X"; 
            } else  
            {
                if(Int32.TryParse(Value, out x))
                {
                    this.Value = x.ToString();
                } else
                {
                    this.Value = "";
                }
            }
        }
        public void setGP(String GP)
        {
            var isNumeric = int.TryParse(GP, out var wert_int);
            if (isNumeric == true)
            {
                this.GP = wert_int.ToString();
            } else
            {
                this.GP = "";
            }
        }
        public void setAttributeBonus(DSA_ATTRIBUTE attribute, int value)
        {
            attributeBonus.Remove(attribute);
            attributeBonus.Add(attribute, value);
        }
        public void setEnergieBonus(DSA_ENERGIEN energie, int value)
        {
            energieBonus.Remove(energie);
            energieBonus.Add(energie, value);
        }

        public String getName(){
            return Name;
        }
        public String getDescription()
        {
            String totalDescription = String.Copy(this.Description);
            totalDescription = totalDescription + getAttributeString() + getEnergieString();
            
            return totalDescription;
        }
        public String getSimpleDescription()
        {
            return this.Description;
        }
        public String getValue()
        {
            return Value;
        }
        public String getGP()
        {
            return GP;
        }
        public int getAttributeBonus(DSA_ATTRIBUTE attribute)
        {
            int x;
            attributeBonus.TryGetValue(attribute, out x);
            return x;
        }
        public int getEnergieBonus(DSA_ENERGIEN energie)
        {
            int x;
            energieBonus.TryGetValue(energie, out x);
            return x;
        }

        private String getAttributeString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out x);
                if (x != 0)
                {
                    ret = ret + " " + x + ControllAttribute.getAcronym((DSA_ATTRIBUTE)i);
                }
            }
            return ret;
        }
        private String getEnergieString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                energieBonus.TryGetValue((DSA_ENERGIEN)i, out x);
                if (x != 0)
                {
                    ret = ret + " " + x + ControllEnergien.getAcronym((DSA_ENERGIEN)i);
                }
            }
            return ret;
        }
    }
}
