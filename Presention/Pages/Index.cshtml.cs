using Application.Contracts.Hall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class IndexModel : PageModel
    {
        
        private IHallApplication hall;

        public IndexModel( IHallApplication hall)
        {
          
            this.hall = hall;
        }

        public IEnumerable<HallViewModel> Halls;

        

        public void OnGet()
        {
            Halls = hall.GetAll().Where(x => x.IsRemove == false);
        }

        public void OnPost()
        {
            
        }
    }
}
