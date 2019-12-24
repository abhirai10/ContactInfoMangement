using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactInfoManagement.Models;

namespace ContactInfoManagement.DataAccessLayer
{
    public class ContactDataAccessLayer : IContactDataAccessLayer
    {

        public IList<ContactViewModel> GetAllContactsDAL()
        {
            IList<ContactViewModel> contacts = null;

            using (var ctx = new ContactDbEntities())
            {
                contacts = ctx.Contacts
                            .Select(s => new ContactViewModel()
                            {
                                Id = s.Id,
                                FirstName = s.First_Name,
                                LastName = s.Last_Name,
                                Email = s.Email,
                                PhoneNumber = s.Phone_Number,
                                Status = s.Status
                            }).ToList<ContactViewModel>();
            }

            return contacts;
        }


        public ContactViewModel GetContactByIdDAL(int id)
        {
            ContactViewModel contact = null;

            using (var ctx = new ContactDbEntities())
            {
                contact = ctx.Contacts
                    .Where(s => s.Id == id)
                    .Select(s => new ContactViewModel()
                    {
                        Id = s.Id,
                        FirstName = s.First_Name,
                        LastName = s.Last_Name,
                        Email = s.Email,
                        PhoneNumber = s.Phone_Number,
                        Status = s.Status
                    }).FirstOrDefault<ContactViewModel>();
            }

            return contact;
        }


        public void AddNewContactDAL(ContactViewModel contact)
        {
                using (var ctx = new ContactDbEntities())
                {
                    ctx.Contacts.Add(new Contact()
                    {
                        Id = contact.Id,
                        First_Name = contact.FirstName,
                        Last_Name = contact.LastName,
                        Email = contact.Email,
                        Phone_Number = contact.PhoneNumber,
                        Status = contact.Status
                    });

                    ctx.SaveChanges();
                }

        }


        public bool UpdateContactDAL(ContactViewModel contact)
        {
            using (var ctx = new ContactDbEntities())
            {
                var existingContact = ctx.Contacts.Where(s => s.Id == contact.Id)
                                                        .FirstOrDefault<Contact>();

                if (existingContact != null)
                {
                    existingContact.First_Name = contact.FirstName;
                    existingContact.Last_Name = contact.LastName;
                    existingContact.Email = contact.Email;
                    existingContact.Phone_Number = contact.PhoneNumber;
                    existingContact.Status = contact.Status;

                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public void DeleteContactDAL(int id)
        {
            using (var ctx = new ContactDbEntities())
            {
                var contact = ctx.Contacts
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(contact).State = System.Data.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }
}