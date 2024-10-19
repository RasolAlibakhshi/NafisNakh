using Application.Contracts.Hall;
using Application.Contracts.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages
{
    public class MachineManegmentModel : PageModel
    {
        private IHallApplication Hall;
        private IMachineApplication Machine;

        public MachineManegmentModel(IHallApplication hall, IMachineApplication machine)
        {
            Hall = hall;
            Machine= machine;
           
        }

        
        public IEnumerable<HallViewModel> Hall_Data;
        public IEnumerable<HallAndMachineViewmodel> MyList;
        public string Name { get; set; }
        public int ID { get; set; }
        public void OnGet()
        {
            Hall_Data = Hall.GetAll();
            MyList = Machine.HallAndMachine_Collection();
        }

        public IActionResult OnPost(MachineViewModel model)
        {
            if (ModelState.IsValid)
            {
                Machine.Create(new MachineViewModel(model.Name, model.ID));
            }
            return RedirectToPage("MachineManegment");
        }

        public IActionResult OnGetDelete(int id)
        {
            if (ModelState.IsValid)
            {
                Machine.Delete(Machine.GetById(id));
            }
            
            
            return RedirectToPage("MachineManegment");

        }


        public IActionResult OnGetRemove(int id)
        {
            if (ModelState.IsValid)
            {
                Machine.Remove(Machine.GetById(id));
            }
            return RedirectToPage("MachineManegment");
        }


        public IActionResult OnGetRestore(int id)
        {
            if (ModelState.IsValid)
            {
                Machine.Restore(Machine.GetById(id));
            }
            return RedirectToPage("MachineManegment");
        }
    }
}
