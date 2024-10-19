using Application.Contracts.Machine;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages
{
    public class EditeMachineManegmentModel : PageModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        private IMachineApplication Machine;

        public EditeMachineManegmentModel(IMachineApplication machine)
        {
            
            Machine = machine;
        }
        public void OnGet(int id)
        {
            Name=Machine.GetById(id).Name;
            ID=Machine.GetById(id).ID;
        }

        public IActionResult OnPost(MachineViewModel model)
        {
            if (ModelState.IsValid)
            {
                Machine.Update(model);
            }
            
            return RedirectToPage("MachineManegment");
        }
    }
}
