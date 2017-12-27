using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public enum DSA_GENERALTALENTS { PHYSICAL, SOCIAL, NATURE, KNOWLDAGE, CRAFTING }
    public enum DSA_FIGHTINGTALENTS { WEAPONLESS, CLOSE, RANGE }


    
    class ControllTalent
    {
        Dictionary<Type, List<InterfaceTalent>> TalentDictonary = new Dictionary<Type, List<InterfaceTalent>>();
       
        String currentdirectoryPath = Directory.GetCurrentDirectory();

        public ControllTalent(Charakter charakter, String ResourcePath)
        {
            List<ICollection<Enum>> listofallTalents = new List<ICollection<Enum>>();

            String GeneralTalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.GeneralTalentFilesSystemLocation);
            String FightingTalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.FightTalentFilesSystemLocation);
            String LanguageTalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.LanguageTalentFileSystemLocation);
            String GiftTalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.GiftTalentFileSystemLocation);


            Dictionary<DSA_GENERALTALENTS, List<InterfaceTalent>> GeneralTalentFiles = loadGeneralTalents(GeneralTalentFileSystemLocation, (DSA_GENERALTALENTS)0);
            Dictionary<DSA_FIGHTINGTALENTS, List<InterfaceTalent>> FightingTalentFiles = loadGeneralTalents(FightingTalentFileSystemLocation, (DSA_FIGHTINGTALENTS)0);

            List<LanguageFamily> LanguageFamiles = loadLanguageFamily(LanguageTalentFileSystemLocation);
            
            for (int i = 0; i < GeneralTalentFiles.Count; i++)
            {
                List<InterfaceTalent> talentList = GeneralTalentFiles[(DSA_GENERALTALENTS)i];
                for (int j = 0; j < talentList.Count; j++)
                {
                    charakter.addTalent((DSA_GENERALTALENTS)i, talentList[j]);
                }
            }
            for (int i = 0; i < FightingTalentFiles.Count; i++)
            {
                List<InterfaceTalent> talentList = FightingTalentFiles[(DSA_FIGHTINGTALENTS)i];
                for (int j = 0; j < talentList.Count; j++)
                {
                    charakter.addTalent((DSA_FIGHTINGTALENTS)i, talentList[j]);
                }
            }
            for (int i = 0; i < LanguageFamiles.Count; i++)
            {
                charakter.addTalent(LanguageFamiles[i]);
            }

            GiftTalent x = new GiftTalent("tmp", null);
            TalentGeneral t = new TalentGeneral("tmp", null, null, null, null);
            InterfaceTalent y = (InterfaceTalent)x;
            this.getTalent(y);
            this.getTalent(t);

            loadTalents(ResourcePath);

            return;
        }
        private void loadTalents(String ResourcePath)
        {
            loadGeneralTalents(ResourcePath);
            loadFightingTalent(ResourcePath);
        }
        private void loadGeneralTalents(String ResourcePath)
        {
            LoadXMLTalentFile_ loader = new LoadXMLTalentFile_();
            String GeneralTalentFileSystemLocation  = Path.Combine(ResourcePath, ManagmentSaveStrings.GeneralTalentFilesSystemLocation);
            List<String> dirs                       = new List<String>(Directory.EnumerateDirectories(GeneralTalentFileSystemLocation));

            for (int i = 0; i < dirs.Count; i++)
            {
                String folder       = dirs[i].Substring(dirs[i].LastIndexOf('\\') + 1);
                String deepFolder   = Path.Combine(GeneralTalentFileSystemLocation, dirs[i]);
                String[] files      = Directory.GetFiles(deepFolder);
                
                if (0 == String.Compare(folder, ManagmentSaveStrings.TalentSocial))
                {
                    loadTalent<TalentSocial>(loader, files);  
                } else
                if(0 == String.Compare(folder, ManagmentSaveStrings.TalentCrafting))
                {
                    loadTalent<TalentCrafting>(loader, files);
                } else 
                if(0 == String.Compare(folder, ManagmentSaveStrings.TalentKnowldage))
                {
                    loadTalent<TalentKnwoldage>(loader, files);
                } else
                if (0 == String.Compare(folder, ManagmentSaveStrings.TalentNature))
                {
                    loadTalent<TalentNature>(loader, files);
                } else 
                if (0 == String.Compare(folder, ManagmentSaveStrings.TalentPhysical))
                {
                    loadTalent<TalentPhysical>(loader, files);
                }
            }
        }
        private void loadFightingTalent(String ResourcePath)
        {
            LoadXMLTalentFile_ loader = new LoadXMLTalentFile_();
            String TalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.FightTalentFilesSystemLocation);
            List<String> dirs = new List<String>(Directory.EnumerateDirectories(TalentFileSystemLocation));

            for (int i = 0; i < dirs.Count; i++)
            {
                String folder = dirs[i].Substring(dirs[i].LastIndexOf('\\') + 1);
                String deepFolder = Path.Combine(TalentFileSystemLocation, dirs[i]);
                String[] files = Directory.GetFiles(deepFolder);

                if (0 == String.Compare(folder, ManagmentSaveStrings.TalentRange))
                {
                    loadTalent<TalentRange>(loader, files);
                }
                else
                if (0 == String.Compare(folder, ManagmentSaveStrings.TalentWeaponless))
                {
                    loadTalent<TalentWeaponless>(loader, files);
                }
                else
                if (0 == String.Compare(folder, ManagmentSaveStrings.TalentClose))
                {
                    loadTalent<TalentClose>(loader, files);
                }
            }
        }
        public void loadTalent<T>(LoadXMLTalentFile_ loader, String[] files) where T: InterfaceTalent
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();
            Type type = typeof(T);
            for (int j = 0; j < files.Count(); j++)
            {
                T talent = loader.loadFile<T>(files[j]);
                list.Add(talent);
            }
            TalentDictonary.Add(type, list);
        }



        private Dictionary<Tenum, List<InterfaceTalent>> loadGeneralTalents<Tenum>(String FileSystemLocation, Tenum xenum) where Tenum : struct, IComparable, IFormattable, IConvertible
        {
            Dictionary<Tenum, List<InterfaceTalent>> Talents = new Dictionary<Tenum, List<InterfaceTalent>>();
            List<String> dirs = new List<String>(Directory.EnumerateDirectories(FileSystemLocation));

            String[] names = Enum.GetNames(typeof(Tenum));


            for (int i = 0; i < dirs.Count; i++)
            {
                String folder = dirs[i].Substring(dirs[i].LastIndexOf('\\') + 1);

                for (int j = 0; j < names.Length; j++)
                {
                    if (0 == String.Compare(names[j], folder.ToUpper()))
                    {
                        List<InterfaceTalent> talentFiles = new List<InterfaceTalent>();
                        String deepFolder = Path.Combine(FileSystemLocation, dirs[i]);
                        String[] files = Directory.GetFiles(deepFolder);

                        foreach (String file in files)
                        {
                            LoadXMLTalentFile loadXMLTalentFile = new LoadXMLTalentFile();
                            talentFiles.Add(loadXMLTalentFile.loadFile(file));
                        }
                        Tenum myEnum = (Tenum)(object)j;
                        Talents.Add(myEnum, talentFiles);
                    }
                }
            }
            return Talents;
        }
        private List<LanguageFamily> loadLanguageFamily(String FileSystemLocation)
        {
            List<LanguageFamily> llist = new List<LanguageFamily>();
            String[] files = Directory.GetFiles(FileSystemLocation);
            LoadXMLLanguage loadXMLTalentFile = new LoadXMLLanguage();

            foreach (String file in files)
            {
                llist.Add(loadXMLTalentFile.loadFile(file));
            }
            return llist;
        }
        private List<InterfaceTalent> loadGiftTalent(String FileSystemLocation)
        {
            List<InterfaceTalent> llist = new List<InterfaceTalent>();
            String[] files = Directory.GetFiles(FileSystemLocation);
            LoadXMLGiftTalentFile LoadXMLGiftTalentFile = new LoadXMLGiftTalentFile();

            foreach (String file in files)
            {
                llist.Add(LoadXMLGiftTalentFile.loadFile(file));
            }
            return llist;
        }

        public void getTalent<X>(X type) where X: InterfaceTalent
        {
            List<InterfaceTalent> y;
            //test.TryGetValue(type.GetType(), out y);
            
        }
    }
    

}
