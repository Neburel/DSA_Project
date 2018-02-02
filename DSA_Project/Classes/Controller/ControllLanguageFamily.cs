using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class ControllLanguageFamily
    {
        Charakter charakter;
        String LanguageTalentFileSystemLocation;
        List<LanguageFamily> list;

        public ControllLanguageFamily(Charakter charakter, String ResourcePath)
        {
            this.charakter                      = charakter;
            LoadFile_LanguageFamily loader      = new LoadFile_LanguageFamily();
            list                                = new List<LanguageFamily>(0);

            LanguageTalentFileSystemLocation    = Path.Combine(ResourcePath, ManagmentSaveStrings.LanguageTalentFileSystemLocation);
            LanguageTalentFileSystemLocation    = Path.Combine(LanguageTalentFileSystemLocation, "LanguageFamily");

            String[] files = Directory.GetFiles(LanguageTalentFileSystemLocation);
            
            for(int i=0; i<files.Length; i++)
            {
                LanguageFamily family = loader.loadFile(files[i], charakter);
                if(family!=null) list.Add(family);
            }
        }
        public List<LanguageFamily> getFamilyList()
        {
            return list;
        }
    }
}
