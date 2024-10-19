using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Machine
{
    public class HallAndMachineViewmodel 
    {
        public int HallID { get; set; }
        public string HallName { get; set; }
        public int MachineID { get; set; }

        public string MachineName { get; set; }

        public bool IsRemoveMachine { get; set; }
        public bool IsRemoveHall { get; set; }
    }
}
