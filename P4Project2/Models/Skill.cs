using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public Skill SkillID_RequiredToPick { get; set; }
        public AscendancyClass AscendancyClass_Required { get; set; }
        public PrimaryClass PrimaryClass_Required { get; set; }

        public Skill()
        {

        }
    }
}
