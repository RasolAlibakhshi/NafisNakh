using Application.Contracts.Hall;
using Application.Contracts.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Interwoven
{
    public interface IInterwovenManagementApplicaion
    {
        IEnumerable<InterwovenManagementViewModel> GetAll();
        IEnumerable<InterwovenViewModel> GetAll_Interwoven();
        InterwovenViewModel GetById(int ID);
        InterwovenViewModel Create(InterwovenViewModel model);
        InterwovenViewModel Update(InterwovenViewModel model);
        InterwovenViewModel Remove(InterwovenViewModel model);
        InterwovenViewModel Delete(InterwovenViewModel model);
        InterwovenViewModel Restore(InterwovenViewModel model);
    }
}
