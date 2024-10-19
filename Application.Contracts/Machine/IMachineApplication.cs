using Application.Contracts.Hall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Machine
{
    public interface IMachineApplication
    {
        IEnumerable<MachineViewModel> GetAll();
        IEnumerable<HallAndMachineViewmodel> HallAndMachine_Collection();
        MachineViewModel GetById(int ID);
        MachineViewModel Create(MachineViewModel model);
        MachineViewModel Update(MachineViewModel model);
        MachineViewModel Remove(MachineViewModel model);
        MachineViewModel Delete(MachineViewModel model);
        MachineViewModel Restore(MachineViewModel model);

    }
}
