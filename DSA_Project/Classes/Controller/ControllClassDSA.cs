using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DSA_Project
{
    public class ControllClassDSA : ControllClass
    {
        public ControllClassDSA(DSA form) : base(form) { }

        protected override string getRootPath()
        {
            return ManagmentSaveStrings.DSA;
        }
        //#########################################################################################################################################################
        //SetUPs
        protected override void setUPBasicValues()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_BASICVALUES)).Length; i++)
            {
                form.setLBLVisible((DSA_BASICVALUES)i, true);
                form.setBOXVisible((DSA_BASICVALUES)i, true);
            }
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE1, true, "Modifikatoren:");
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE2, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE3, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE4, true, "Göttergeschenke:");
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE5, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE6, false);
            form.setLBLVisible(DSA_BASICVALUES.FREEVALUE7, false);
        }
        protected override void setUPAttribute()
        {
            for(int i=0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                form.setBOXVisible((DSA_ATTRIBUTE)i, true);
            }
        }
        protected override void setUPMoney()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_MONEY)).Length; i++)
            {
                form.setBOXVisible((DSA_MONEY)i, true);
            }
            form.setLBLVisible(DSA_MONEY.D, true, "Geld");
            form.setLBLVisible(DSA_MONEY.BANK, true, "Bank");

            for (int i = 0; i < Enum.GetNames(typeof(DSA_MONEY)).Length; i++)
            {
                form.setBOXVisible((DSA_MONEY)i, true);
            }
        }
        //#########################################################################################################################################################
    }
}
