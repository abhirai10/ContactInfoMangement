using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactInfoManagement.Models;

namespace ContactInfoManagement.DataAccessLayer
{
    public interface IContactDataAccessLayer
    {
        IList<ContactViewModel> GetAllContactsDAL();
        ContactViewModel GetContactByIdDAL(int id);
        void AddNewContactDAL(ContactViewModel contact);
        bool UpdateContactDAL(ContactViewModel contact);
        void DeleteContactDAL(int id);
    }
}
