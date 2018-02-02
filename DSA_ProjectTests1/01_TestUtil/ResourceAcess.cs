using DSA_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_ProjectTests1._01_TestUtil
{
    public class ResourceAcess
    {
        public static String getSaveFile(String ResourceDir, String FileName)
        {
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, ResourceDir);
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);
            path = Path.Combine(path, FileName);
            return path;
        }
        public static String getLanguageFamilyFile(String ResourceDir, String FileName)
        {
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, ResourceDir);
            path = Path.Combine(path, ManagmentSaveStrings.LanguageTalentFileSystemLocation);
            path = Path.Combine(path, "LanguageFamily");
            path = Path.Combine(path, FileName);
            return path;
        }
        public static String getResourceDir(String ResourceDir)
        {
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, ResourceDir);
            return path;
        }
    }
}
