using Application.Contracts.Interwoven;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    
    public class SelectInterwovenModel : PageModel
    {
        private IInterwovenManagementApplicaion Intervowen;

        public SelectInterwovenModel(IInterwovenManagementApplicaion intervowen)
        {
            Intervowen = intervowen;
        }

        public List<InterwovenViewModel> interwovenModels;
        public void OnGet(int id)
        {
            interwovenModels = Intervowen.GetAll_Interwoven().Where(x => x.MachineId == id).ToList();
        }
    }
}
