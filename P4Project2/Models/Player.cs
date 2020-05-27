using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public static class Player
    {
        public static int ID { get; set; }
        [ForeignKey("GladatorID_FK")]
        public static Gladiator GladiatorID { get; set; }
        public static int GladatorID_FK { get; set; }
    }
}
