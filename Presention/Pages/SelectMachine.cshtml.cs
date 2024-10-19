using Application.Contracts.Hall;
using Application.Contracts.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class SelectMachineModel : PageModel
    {
        private IMachineApplication Machine;
        private IHallApplication hall;

        public SelectMachineModel(IMachineApplication machine, IHallApplication hall)
        {
            Machine = machine;
            this.hall= hall;
       
        }
        public IEnumerable<HallViewModel> Halls;
        public IEnumerable<MachineViewModel> Machines;
        public int ID;
     
        public void OnGet(int id)
        {
            Machines = Machine.GetAll().Where(x => x.IsRemove == false).Where(x => x.HallID == id);
            Halls = hall.GetAll().Where(x => x.IsRemove == false);
            ID = id;
        }
    }
}
