﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class TalentKnwoldage : TalentGeneral
    {
        public TalentKnwoldage(String name, List<DSA_ATTRIBUTE> probe, String be, List<TalentDeviate>diverates, List<TalentRequirement>requirements) : base(name, probe, be, diverates, requirements)
        {
        }
    }
}
