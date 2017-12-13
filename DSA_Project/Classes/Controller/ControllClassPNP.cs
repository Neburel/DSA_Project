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
           
        }
        //#########################################################################################################################################################
    }
}
