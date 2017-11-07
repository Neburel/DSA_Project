using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class Feature
    {
        private DSA_FEATUREBONUS type   = DSA_FEATUREBONUS.NONE;
        private String Name             = "";
        private String Description      = "";
        private String Value            = "";
        private String GP               = "";
        private int Bonus               = 0;

        public Feature(DSA_FEATUREBONUS type, String Name, String Description, String Value, String GP, int Bonus)
        {
            this.type = type;
            this.Name = Name;
            this.Description = Description;
            setBonus(Bonus);
            setValue(Value);
            setGP(GP);

        }
        public String getName()
        {
            return Name;
        }
        public String getDescription()
        {
            return Description;
        }
        public String getValue()
        {
            return this.Value;
        }
        public String getGP()
        {
            return GP;
        }
        public int getBonus()
        {
            return this.Bonus;
        }

        public void setName(String name)
        {
            this.Name = name;
        }
        public void setDescription(String description)
        {
            this.Description = description;
        }

        public void setGP(String GP)
        {
            var isNumeric = int.TryParse(Value, out var GP_int);
            if (isNumeric != true)
            {
               this.GP = "";
            }
            else
            {
                this.GP = GP_int.ToString();
            }
        }
        
        public void setValue(String Value)
        {
            if (!Value.Equals("X"))
            {
                var isNumeric = int.TryParse(Value, out var Wert_int);
                if (isNumeric != true)
                {
                    this.Value = "";
                }
                else
                {
                    this.Value = Wert_int.ToString();
                }
            } else
            {
                this.Value = Value;
            }
        }
        public void setBonus(int Bonus)
        {
            this.Bonus = Bonus;
        }

        public DSA_FEATUREBONUS getType()
        {
            Console.WriteLine("Type: " + type);
            return type;
        }
        public void setBonusType(DSA_FEATUREBONUS BType)
        {
            this.type = BType;
        }
    }
}
