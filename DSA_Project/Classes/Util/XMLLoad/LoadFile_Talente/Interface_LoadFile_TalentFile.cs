using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public interface Interface_LoadFile_TalentFile
    {
        T loadFile<T>(String fileName) where T : InterfaceTalent;
    }
}
