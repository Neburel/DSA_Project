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
        //Einrichtung der Attribute
        protected override void setUPAttribute()
        {
           
        }
        //#########################################################################################################################################################
    }
}
