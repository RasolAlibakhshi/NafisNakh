using Application.Contracts.Hall;
using Application.Contracts.Interwoven;
using Application.Contracts.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages
{
    public class InterwovenManagementModel : PageModel
    {
        private IInterwovenManagementApplicaion interwovens;
        private IHallApplication hall;
        private IMachineApplication machine;

        public InterwovenManagementModel(IInterwovenManagementApplicaion erwovenManagementmodel, IHallApplication hall, IMachineApplication machine)
        {
            
            this.hall = hall;
            this.machine = machine;
            this.interwovens= erwovenManagementmodel;


        }

        public List<HallViewModel> HallModels;
        public List<InterwovenManagementViewModel> InterwovenModels;
        public List<MachineViewModel> MachineModels;
        public void OnGet()
        {
            MachineModels=machine.GetAll().ToList();
            HallModels =hall.GetAll().ToList();
            InterwovenModels = interwovens.GetAll().ToList();
        }

        public IActionResult OnGetRemove(int id)
        {

            var Interwoven = interwovens.Remove(interwovens.GetById(id));
            return RedirectToPage("InterwovenManagement");
        }
        public IActionResult OnGetRestore(int id)
        {

            var Interwoven = interwovens.Restore(interwovens.GetById(id));
            return RedirectToPage("InterwovenManagement");
        }

        public IActionResult OnGetDelete(int id)
        {
            var Interwoven = interwovens.Delete(interwovens.GetById(id));
            return RedirectToPage("InterwovenManagement");
        }
    }
}
