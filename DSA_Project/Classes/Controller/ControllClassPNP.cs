using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DSA_Project
{
    public class ControllClassPNP : ControllClass
    {
        public ControllClassPNP(DSA form) : base(form) { }

        protected override string getRootPath()
        {
            return ManagmentSaveStrings.PNP;
        }
        //#########################################################################################################################################################
        //Einrichtung der Attribute
        protected override void setUPAttribute()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                form.setBOXVisible((DSA_ATTRIBUTE)i, true);                
            }
            
            form.setBOXVisible(DSA_ATTRIBUTE.SO, false);
        }
        protected override void setUPBasicValues()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_BASICVALUES)).Length; i++)
            {
                form.setLBLVisible((DSA_BASICVALUES)i, true);
            }
            form.setLBLVisible(DSA_BASICVALUES.GOTTHEIT, true, "Glaube:");
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE1, true, "Modifikatoren:");
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE2, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE3, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE4, true, "Techstufe:");
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE5, true, "Fraktion:");
            form.setBOXVisible(DSA_BASICVALUES.FREEVALUE6, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE6, false);
            form.setBOXVisible(DSA_BASICVALUES.FREEVALUE7, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE7, false);
        }
        protected override void setUPMoney()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_MONEY)).Length; i++)
            {
                form.setLBLVisible((DSA_MONEY)i, false);
                form.setBOXVisible((DSA_MONEY)i, false);
            }
            form.setBOXVisible(DSA_MONEY.BANK, true);
            form.setLBLVisible(DSA_MONEY.BANK, true, "Codes");
        }
        //#########################################################################################################################################################
    }
}
