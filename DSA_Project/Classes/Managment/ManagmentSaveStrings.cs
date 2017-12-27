using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    static public class ManagmentSaveStrings
    {
        public static String DSA = "DSA";
        public static String PNP = "PNP";

        public static String currentDirectory                   = Directory.GetCurrentDirectory();
        public static String Recources                          = "Resources";
        public static String SaveLocation                       = "SaveGame";
        public static String TalentLocation                     = "Talents";
        public static String GeneralTalentFilesSystemLocation   = "Talents/GeneralTalents";
        public static String FightTalentFilesSystemLocation     = "Talents/FightingTalents";
        public static String LanguageTalentFileSystemLocation   = "Talents/Language";
        public static String GiftTalentFileSystemLocation       = "Talents/Gifts";
        public static String PictureFileSystemLocation          = "PicturesDiv";

        //###############################################################################################
        //Mögliche Talente General
        public static String TalentCrafting     = "crafting";
        public static String TalentKnowldage    = "knowldage";
        public static String TalentNature       = "nature";
        public static String TalentPhysical     = "physical";
        public static String TalentSocial       = "social";
        //Mögliche Talente Fighting
        public static String TalentClose        = "close";
        public static String TalentWeaponless   = "weaponless";
        public static String TalentRange        = "range";
    }
}
