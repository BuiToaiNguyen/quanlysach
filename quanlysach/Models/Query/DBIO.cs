using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlysach.Models.DB;


namespace quanlysach.Models.Query
{
    public class DBIO
    {
        private MyDB db = new MyDB();

        public void AddObj<T>(T obj)
        {
            db.Set(obj.GetType()).Add(obj);
        }
        public void DeleteObj<T>(T obj)
        {
            db.Set(obj.GetType()).Remove(obj);
        }
        public User getUserById(int id)
        {
            return db.Users.Where(c => c.id == id).FirstOrDefault();
        }
        public Book getBookById(int id)
        {
            return db.Books.Where(c => c.idbook == id).FirstOrDefault();
        }




        public User getUser(string name)
        {
            return db.Users.Where(c => c.name == name).FirstOrDefault();
        }

        public List<Book> getListBook()
        {
            return db.Books.ToList();
        }
        public List<Category> getListCategory()
        {
            return db.Categories.ToList();
        }

        public void AddBook(string name, string nameauthor,int idctg,float price)
        {
            string sql = $"insert into Book(name,nameauthor,idctg,price) values('{name}','{nameauthor}',{idctg},{price})";
            db.Database.ExecuteSqlCommand(sql);
        }


        public void Save()
        {
            db.SaveChanges();

        }



    }
}