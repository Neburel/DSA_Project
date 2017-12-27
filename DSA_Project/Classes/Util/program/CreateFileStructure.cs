using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    static class CreateFileStructure
    {
        public static void createFileStructure(String Game)
        {
            String CurrentDirectory = Directory.GetCurrentDirectory();
            String CurrentDirectoryRessources = Path.Combine(CurrentDirectory, ManagmentSaveStrings.Recources);
            String CurrendDirectoryRessourcesGame = Path.Combine(CurrentDirectoryRessources, Game);

            String SaveDirectory    = Path.Combine(CurrendDirectoryRessourcesGame, ManagmentSaveStrings.SaveLocation);
            String Talents          = Path.Combine(CurrendDirectoryRessourcesGame, ManagmentSaveStrings.TalentLocation);
            String GiftTalents      = Path.Combine(CurrendDirectoryRessourcesGame, ManagmentSaveStrings.GiftTalentFileSystemLocation);
            createIfNotExist(SaveDirectory);
        }

        private static void createIfNotExist(String directory)
        {
            if (Directory.Exists(directory)) { Console.WriteLine("Needs not to be Created"); return; }
            Console.WriteLine("Needs to be Created");
            Directory.CreateDirectory(directory);
        }
    }
}
