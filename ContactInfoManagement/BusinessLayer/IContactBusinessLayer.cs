using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactInfoManagement.Models;

namespace ContactInfoManagement.BusinessLayer
{
    public interface IContactBusinessLayer
    {
        IList<ContactViewModel> GetAllContactsBLL();
        ContactViewModel GetContactByIdBLL(int id);
        void AddNewContactBLL(ContactViewModel contact);
        bool UpdateContactBLL(ContactViewModel contact);
        void DeleteContactBLL(int id);

    }
}
