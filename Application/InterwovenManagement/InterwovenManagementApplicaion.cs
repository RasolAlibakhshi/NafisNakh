using Application.Contracts.Interwoven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.DTO;
using System.Reflection.PortableExecutable;

namespace Application.InterwovenManagement
{
    public class InterwovenManagementApplicaion: IInterwovenManagementApplicaion
    {
        private IRepository<Domain.Hall> Halls;
        private IRepository<Domain.Machine> Machines;
        private IRepository<Domain.label> Labels;

        public InterwovenManagementApplicaion(IRepository<Domain.Hall> halls, IRepository<Domain.Machine> machines, IRepository<label> labels)
        {
            Halls = halls;
            Machines = machines;
            Labels = labels;
        }

        public InterwovenViewModel Create(InterwovenViewModel model)
        {
            label data = new label();
            data.MachineID = model.MachineId;
            data.Interwoven=model.Interwoven;
            data.Den=model.Den;
            data.ColorCode=model.ColorCode;
            data.Description=model.Description;
            data.Filament=model.Filament;
            data.Emptyfield1=model.Emptyfield1;
            data.Emptyfield2=model.Emptyfield2;
            data.Emptyfield3=model.Emptyfield3;
            data.Emptyfield4=model.Emptyfield4;
            data.MachineID = model.MachineId;
            data.Ply=model.Ply;
            data.Mingle=model.Mingle;
            data.Warp_Direction=model.Warp_Direction;
            data.Yarn_Type=model.Yarn_Type;
            data.TypeOfPackaging=model.TypeOfPackaging;
            data.Type_Label=model.TypeLabel;
            

            Labels.Create(data);
            Labels.SaveChanges();

            return model;
        }

        public InterwovenViewModel Delete(InterwovenViewModel model)
        {

            Labels.Delete(Labels.GetBy(x => x.ID == model.ID));
            Labels.SaveChanges();

            return model;
        }

        public IEnumerable<InterwovenManagementViewModel> GetAll()
        {
            var Halls = this.Halls.GetAll().ToList();
            var Machines = this.Machines.GetAll().ToList();
            var Labels = this.Labels.GetAll().ToList();


            var Hall_Join_Machine = Machines.Join(Halls, machine => machine.HallID, hall => hall.ID,
                    (machine, hall) => new { machine, hall })
                .Select(x => new
                {
                    HallID = x.hall.ID,
                    HallName = x.hall.Name,
                    HallVisible = x.hall.IsDeleted,
                    MachineID = x.machine.ID,
                    MachineName = x.machine.Name,
                    MachineVisible = x.machine.IsDeleted,
                    MachineKey = x.machine.HallID
                }).ToList();



            var Machine_Join_Labels = Hall_Join_Machine.GroupJoin(Labels,
                    hall_join_machine => hall_join_machine.MachineID,
                    label => label.MachineID,
                    (hall_join_machine, labels) => new { hall_join_machine, labels = labels.DefaultIfEmpty() }) // DefaultIfEmpty برای Left Join
                .SelectMany(x => x.labels.Select(label => new InterwovenManagementViewModel
                {
                    HallID = x.hall_join_machine.HallID,
                    HallName = x.hall_join_machine.HallName,
                    HallVisible = x.hall_join_machine.HallVisible,

                    MachineID = x.hall_join_machine.MachineID,
                    MachineName = x.hall_join_machine.MachineName,
                    MachineVisible = x.hall_join_machine.MachineVisible,
                    MachineKey = x.hall_join_machine.MachineKey,

                   
                    InterwovenID = label?.ID ?? 0,
                    InterwovenName = label?.Interwoven ?? string.Empty,
                    InterwovenVisible = label?.IsDeleted ?? false,
                    Interwovenkey = label?.MachineID ?? 0
                })).ToList();




            return Machine_Join_Labels;
        
       

        }

        public IEnumerable<InterwovenViewModel> GetAll_Interwoven()
        {
            return Labels.GetAll().Select(data => new InterwovenViewModel(
                data.ID, data.MachineID, data.Interwoven, data.Type_Label.ToString(), data.Filament, data.Den,
                data.Ply, data.ColorCode, data.Mingle, data.Warp_Direction, data.Yarn_Type, data.Emptyfield1,
                data.Emptyfield2, data.Emptyfield3, data.Emptyfield4, data.TypeOfPackaging, data.Description
            ));
        }

        public InterwovenViewModel GetById(int ID)
        {
            label data = Labels.GetBy(x => x.ID == ID);
            return new InterwovenViewModel(data.ID,data.MachineID, data.Interwoven, data.Type_Label.ToString(), data.Filament, data.Den,
                data.Ply, data.ColorCode, data.Mingle, data.Warp_Direction, data.Yarn_Type, data.Emptyfield1,
                data.Emptyfield2, data.Emptyfield3, data.Emptyfield4, data.TypeOfPackaging, data.Description);
        }

        public InterwovenViewModel Remove(InterwovenViewModel model)
        {
            var data=Labels.GetBy(x => x.ID == model.ID);
            data.IsDeleted = true;
            Labels.SaveChanges();
            return model;
        }

        public InterwovenViewModel Restore(InterwovenViewModel model)
        {
            var data=Labels.GetBy(x => x.ID == model.ID);
            data.IsDeleted = false;
            Labels.SaveChanges();
            return model;
        }

        public InterwovenViewModel Update(InterwovenViewModel model)
        {
            var data = Labels.GetBy(x => x.ID == model.ID);
            data.Interwoven=model.Interwoven;
            data.Den=model.Den;
            data.Ply=model.Ply;
            data.ColorCode=model.ColorCode;
            data.Mingle=model.Mingle;
            data.Warp_Direction=model.Warp_Direction;
            data.Filament=model.Filament;
            data.Description=model.Description;
            data.TypeOfPackaging=model.TypeOfPackaging;
            data.Emptyfield1=model.Emptyfield1;
            data.Emptyfield2=model.Emptyfield2;
            data.Emptyfield3=model.Emptyfield3;
            data.Emptyfield4=model.Emptyfield4;
            data.Yarn_Type=model.Yarn_Type;
            data.Type_Label = model.TypeLabel;
            Labels.SaveChanges();

            return model;
        }
    }
}
