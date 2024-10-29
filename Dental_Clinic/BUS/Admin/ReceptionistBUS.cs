using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Admin
{
    internal class ReceptionistBUS
    {
        private ReceptionistDAO receptionistDAO;

        public ReceptionistBUS()
        {
            receptionistDAO = new ReceptionistDAO();
        }

        public List<ReceptionistDTO> GetReceptionistList()
        {
            return receptionistDAO.GetReceptionistList();
        }

        public ReceptionistDTO GetReceptionistInfo(int id)
        {
            return receptionistDAO.GetReceptionistInfo(id);
        }
        public void UpdateStatus(int userID)
        {
            receptionistDAO.UpdateStatus(userID);
        }
        public void UpdateReceptionist(ReceptionistDTO receptionistDTO)
        {
            receptionistDAO.UpdateReceptionist(receptionistDTO);
        }
        public void AddReceptionist(ReceptionistDTO receptionistDTO)
        {
            receptionistDAO.AddReceptionist(receptionistDTO);
        }
    }
}
