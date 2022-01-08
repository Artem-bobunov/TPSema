Контрольная работа по МиСТ на тему: Турпутевки (TourPackage)

Данная работа выполена на тему туристических поездок. Проект представляет собой 
Веб-приложение где продавец тур. путевок имеет возможность просмотреть на сайте различный туристические поездки, после чего выбрать из имеющихся поездок и предложить туристам.


![image](https://user-images.githubusercontent.com/38436717/148641296-137822f5-52c4-41ae-81a0-dc7efe81c138.png)

1. Добавление Туристической поездки пользователем:
При появлении новой тур поездки пользователь(продавец) вносит в БД, новую услугу, для дальнейшей передачи информации туристам (покупателям):


![image](https://user-images.githubusercontent.com/38436717/148641533-6a914c6f-b92f-4ed5-84f9-a70518a12566.png)


1.1 Результат добавления новой туристической услуги:


![image](https://user-images.githubusercontent.com/38436717/148641614-45b219a3-f4c1-479a-8a5d-2af9d07bc147.png)


2. Пользоавтель может удалить из БД определенную услугу (если определенная поездка больше не проводится/обслуживается и т.д.), для этого ему необходимо нажать кнопку удалить напротив выбранной услуги. После наажатия на клавишу Удалить:


![image](https://user-images.githubusercontent.com/38436717/148641711-e4c9a5e0-3805-4430-bca4-46de964ef6b4.png)


2.1 Результат удаления туристической услуги:


![image](https://user-images.githubusercontent.com/38436717/148641729-05010714-9a20-4d1d-928e-51a94666ce9f.png)


3. Хранение информации в БД
3.1. Способ хранения информации о туристических поездках

Вся информациия хранится в базе данных SQL Server. Для создания БД используется sql server management studio:

![image](https://user-images.githubusercontent.com/38436717/148642112-897c8e7f-2fa7-46e1-9195-5156167a556a.png)


4. Средства для реализации приложения 
 Веб-приложение реализованно с использованием Entity Framework + ASP.NET на языке C# . Так же используется Bootstrap для верстки приложения
 
 
 ![image](https://user-images.githubusercontent.com/38436717/148642223-3b7d9635-15f1-4c84-bb7a-0d2826a35ad0.png)
 
 
 5. MVC в разарботанном приложении
 5.1  Модели
 
 
 ![image](https://user-images.githubusercontent.com/38436717/148642298-71a8bf8e-c149-4027-b6d1-f6e766991eb1.png)


5.2 Представление (Views)


![image](https://user-images.githubusercontent.com/38436717/148642316-a3f22e54-1bec-4a92-83ed-a8455f5594ff.png)

 
![image](https://user-images.githubusercontent.com/38436717/148642331-baed08a8-ad02-4ce6-97f9-0c6b9f043ea4.png)


![image](https://user-images.githubusercontent.com/38436717/148642350-ed5c9827-7917-4c90-aa89-52ec80039efa.png)

5.3 Контроллеры

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPSema.Models;

namespace TPSema.Controllers
{
    public class CustomersController : Controller
    {
        private TourDBEntities3 db = new TourDBEntities3();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nameTour,dateTour,daysTour,price,transport,residence,typeTour")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nameTour,dateTour,daysTour,price,transport,residence,typeTour")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}





