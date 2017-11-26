using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public enum DSA_GENERALTALENTS { PHYSICAL, SOCIAL, NATURE, KNOWLDAGE, CRAFTING }
    public enum DSA_FIGHTINGTALENTS { WEAPONLESS, CLOSE }
    
    class ControllTalent
    {
        String[] NamesGeneralTalents = Enum.GetNames(typeof(DSA_GENERALTALENTS));
        String[] NamesFightingTalents = Enum.GetNames(typeof(DSA_FIGHTINGTALENTS));

        String currentdirectoryPath = Directory.GetCurrentDirectory();
        
        public ControllTalent(Charakter charakter)
        {
            List<ICollection<Enum>> listofallTalents = new List<ICollection<Enum>>();

            Dictionary<DSA_GENERALTALENTS, List<InterfaceTalent>> GeneralTalentFiles    = loadGeneralTalents(ManagmentLoadXML.GeneralTalentFileSystemLocation, (DSA_GENERALTALENTS)0);
            Dictionary<DSA_FIGHTINGTALENTS, List<InterfaceTalent>> FightingTalentFiles  = loadGeneralTalents(ManagmentLoadXML.FightingTalentsFileSystemLocation, (DSA_FIGHTINGTALENTS)0);
            
            for(int i=0; i<GeneralTalentFiles.Count; i++)
            {
                List<InterfaceTalent> talentList = GeneralTalentFiles[(DSA_GENERALTALENTS)i];
                for(int j=0; j< talentList.Count; j++)
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
            return;
        }
        private Dictionary<Tenum, List<InterfaceTalent>> loadGeneralTalents<Tenum>(String FileSystemLocation, Tenum xenum) where Tenum: struct, IComparable, IFormattable, IConvertible
        {   
            Dictionary<Tenum, List<InterfaceTalent>> Talents = new Dictionary<Tenum, List<InterfaceTalent>>();
            String completePath = Path.Combine(currentdirectoryPath, FileSystemLocation);
            List<String> dirs = new List<String>(Directory.EnumerateDirectories(completePath));

            String[] names = Enum.GetNames(typeof(Tenum));


            for (int i = 0; i < dirs.Count; i++)
            {
                String folder = dirs[i].Substring(dirs[i].LastIndexOf('\\') + 1);

                for (int j = 0; j < names.Length; j++)
                {
                    if (0 == String.Compare(names[j], folder.ToUpper()))
                    {
                        List<InterfaceTalent> talentFiles = new List<InterfaceTalent>();
                        String deepFolder = Path.Combine(completePath, dirs[i]);
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
       
    }
}
