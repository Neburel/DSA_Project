using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class ControllTalent
    {
        private Dictionary<Type, List<InterfaceTalent>> TalentDictonary = new Dictionary<Type, List<InterfaceTalent>>();
        String currentdirectoryPath = Directory.GetCurrentDirectory();

        public ControllTalent(Charakter charakter, String ResourcePath)
        {
            loadTalents(ResourcePath);
            checkforDoppelTalents();
        }
        private void checkforDoppelTalents()
        {
            List<InterfaceTalent> talentlist    = new List<InterfaceTalent>(0);

            foreach (List<InterfaceTalent> list in TalentDictonary.Values)
            {
                talentlist.AddRange(list);
            }
            for(int i=0; i<talentlist.Count; i++)
            {
                InterfaceTalent checkTalent = talentlist[i];
                for(int j = i+1; j<talentlist.Count; j++)
                {
                    InterfaceTalent currentTalent = talentlist[j];
                    if(String.Compare(checkTalent.getComplexName(), currentTalent.getComplexName()) == 0)
                    {
                        throw new Exception("Doppeltes Talent Entdeckt: " + checkTalent + " mit dem Coomplexen Namen:" + checkTalent.getComplexName() + " mit dem Typ:" + checkTalent.GetType() + " und " + currentTalent + " mit dem Complexen Namen:" + currentTalent.getComplexName() + " " + currentTalent.GetType());
                    }
                }
            }
        }
        private void loadTalents(String ResourcePath)
        {
            loadGeneralTalents(ResourcePath);
            loadFightingTalent(ResourcePath);
            loadLanguageTalent(ResourcePath);
            loadGiftTalent(ResourcePath);
        }
        private void loadGeneralTalents(String ResourcePath)
        {
            Interface_LoadXMLTalentFile loader = new LoadXMLTalentFile();
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
            Interface_LoadXMLTalentFile loader = new LoadXMLTalentFile();
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
        private void loadLanguageTalent(String ResourcePath)
        {
            Interface_LoadXMLTalentFile loader = new LoadXMLTalentFile();
            String TalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.LanguageTalentFileSystemLocation);
            List<String> dirs = new List<String>(Directory.EnumerateDirectories(TalentFileSystemLocation));

            for (int i = 0; i < dirs.Count; i++)
            {
                String folder = dirs[i].Substring(dirs[i].LastIndexOf('\\') + 1);
                String deepFolder = Path.Combine(TalentFileSystemLocation, dirs[i]);
                String[] files = Directory.GetFiles(deepFolder);

                if (0 == String.Compare(folder, ManagmentSaveStrings.Language))
                {
                    loadTalent<LanguageTalent>(loader, files);
                }
                else
                if (0 == String.Compare(folder, ManagmentSaveStrings.font))
                {
                    loadTalent<FontTalent>(loader, files);
                }
            }
        }
        private void loadGiftTalent(String ResourcePath)
        {
            Interface_LoadXMLTalentFile loader = new LoadXMLTalentFile();
            String TalentFileSystemLocation = Path.Combine(ResourcePath, ManagmentSaveStrings.GiftTalentFileSystemLocation);
            String[] files = Directory.GetFiles(TalentFileSystemLocation);

            loadTalent<GiftTalent>(loader, files);
        }
        public void loadTalent<T>(Interface_LoadXMLTalentFile loader, String[] files) where T: InterfaceTalent
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
        public List<InterfaceTalent> getTalentList<T>() where T: InterfaceTalent
        {
            List<InterfaceTalent> list = null;
            TalentDictonary.TryGetValue(typeof(T), out list);
            return list;
        }
        public InterfaceTalent getTalent(String name)
        {
            foreach (KeyValuePair<Type, List<InterfaceTalent>> pair in TalentDictonary)
            {
                List<InterfaceTalent> list = pair.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    InterfaceTalent talent = list[i];
                    if (String.Compare(talent.getComplexName(), name) == 0)
                    {
                        return talent;
                    }
                }
            }
            return null;
        }
    }
}
