using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Application.Contracts.Hall
{
    public interface  IHallApplication
    {
        IEnumerable<HallViewModel> GetAll();
        HallViewModel GetById(int ID);
        HallViewModel Create(HallViewModel model);
        HallViewModel Update(HallViewModel model);
        HallViewModel Remove(HallViewModel model);
        HallViewModel Delete(HallViewModel model);
        HallViewModel Restore(HallViewModel model);

    }
}
