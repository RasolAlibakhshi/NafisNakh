using Application.Contracts.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.OptionPackaging
{
    public interface IOptionPackagingApplication
    {
        IEnumerable<OptionPackagingViewModel> GetAll();
       

        OptionPackagingViewModel GetById(int ID);
        OptionPackagingViewModel Create(OptionPackagingViewModel model);
        OptionPackagingViewModel Update(OptionPackagingViewModel model);
        OptionPackagingViewModel Remove(OptionPackagingViewModel model);
        OptionPackagingViewModel Delete(OptionPackagingViewModel model);
        OptionPackagingViewModel Restore(OptionPackagingViewModel model);
    }
}
