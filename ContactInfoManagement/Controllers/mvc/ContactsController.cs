using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactInfoManagement.Models;
using System.Net.Http;

namespace ContactInfoManagement.Controllers.mvc
{
    public class ContactsController : Controller
    {
        //
        // GET: /Contacts/
        public ActionResult Index()
        {
            IEnumerable<ContactViewModel> contacts = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51850/api/");
                //HTTP GET
                var responseTask = client.GetAsync("contacts");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ContactViewModel>>();
                    readTask.Wait();

                    contacts = readTask.Result;
                }
                else 
                {
                    contacts = Enumerable.Empty<ContactViewModel>();

                    ModelState.AddModelError(string.Empty, "No Records found. Please add a contact");
                }
            }
            return View(contacts);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(ContactViewModel contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51850/api/contacts");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ContactViewModel>("contacts", contact);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(contact);
        }

        public ActionResult Edit(int id)
        {
            ContactViewModel contact = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51850/api/");
                //HTTP GET
                var responseTask = client.GetAsync("contacts?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ContactViewModel>();
                    readTask.Wait();

                    contact = readTask.Result;
                }
            }

            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(ContactViewModel contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51850/api/contacts");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ContactViewModel>("contacts", contact);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51850/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("contacts/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

    }
}