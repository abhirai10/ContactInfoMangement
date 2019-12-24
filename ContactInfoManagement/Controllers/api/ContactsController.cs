using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactInfoManagement.Models;
using System.Data;
using System.Data.Entity;
using ContactInfoManagement.BusinessLayer;

namespace ContactInfoManagement.Controllers
{
    public class ContactsController : ApiController
    {
        private IContactBusinessLayer _objContactBal;

        public ContactsController(IContactBusinessLayer objContactBal)
        {
            _objContactBal = objContactBal;
        }

        [HttpGet]
        public IHttpActionResult GetAllContacts()
        {
                IList<ContactViewModel> contacts = _objContactBal.GetAllContactsBLL();

                if (contacts.Count == 0)
                {
                    return NotFound();
                }

                return Ok(contacts);
         
        }
        
        [HttpGet]
        public IHttpActionResult GetContactById(int id)
        {
            ContactViewModel contact = _objContactBal.GetContactByIdBLL(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public IHttpActionResult AddNewContact(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _objContactBal.AddNewContactBLL(contact);
            
            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        [HttpPut]
        public IHttpActionResult UpdateContact(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool updated = _objContactBal.UpdateContactBLL(contact);

            if (!updated)
                return Content(HttpStatusCode.NotFound, contact);
            
            return Content(HttpStatusCode.Accepted, contact); 

                
        }

        [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Contact");

            _objContactBal.DeleteContactBLL(id);
            return Ok();
        }


    }
}
