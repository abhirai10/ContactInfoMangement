using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactInfoManagement.Models;
using ContactInfoManagement.DataAccessLayer;

namespace ContactInfoManagement.BusinessLayer
{
    public class ContactBusinessLayer : IContactBusinessLayer
    {
        private IContactDataAccessLayer _objContactDal;

        public ContactBusinessLayer(IContactDataAccessLayer objContactDal)
        {
            _objContactDal = objContactDal;
        }

        public IList<ContactViewModel> GetAllContactsBLL()
        {
            return _objContactDal.GetAllContactsDAL();
        }


        public ContactViewModel GetContactByIdBLL(int id)
        {
            return _objContactDal.GetContactByIdDAL(id);
        }


        public void AddNewContactBLL(ContactViewModel contact)
        {
            _objContactDal.AddNewContactDAL(contact);
        }


        public bool UpdateContactBLL(ContactViewModel contact)
        {
            return _objContactDal.UpdateContactDAL(contact);
        }


        public void DeleteContactBLL(int id)
        {
            _objContactDal.DeleteContactDAL(id);
        }
    }
}