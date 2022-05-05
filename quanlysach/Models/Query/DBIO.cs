using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using quanlysach.Models.DB;
using PagedList;

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

        public IEnumerable<Book> getListBook( int page,int pageSize,string searchString,string searchAuthor,int searchCate)
        {
            IQueryable<Book> model = db.Books;

            if (searchCate==0)
            {

                if (string.IsNullOrEmpty(searchString))
                {
                    if (!string.IsNullOrEmpty(searchAuthor))
                    {
                        model = model.Where(x => x.nameauthor.Contains(searchAuthor));


                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(searchAuthor))
                        model = model.Where(x => x.name.Contains(searchString));
                    else
                    {
                        model = model.Where(x => x.name.Contains(searchString) && x.nameauthor.Contains(searchAuthor));

                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(searchString))
                {
                    if (!string.IsNullOrEmpty(searchAuthor))
                    {
                        model = model.Where(x => x.nameauthor.Contains(searchAuthor) && x.idctg == searchCate);


                    }
                    else
                    {
                        model = model.Where(x =>  x.idctg == searchCate);

                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(searchAuthor))
                        model = model.Where(x => x.name.Contains(searchString) && x.idctg == searchCate);
                    else
                    {
                        model = model.Where(x => x.name.Contains(searchString) && x.nameauthor.Contains(searchAuthor) && x.idctg == searchCate);

                    }
                }






            }



            return model.OrderByDescending(c=>c.idbook).ToPagedList(page,pageSize);
        }

        public IEnumerable<Book> getListBookHome(int page,int pageSize,string searchString)
        {
            IQueryable<Book> model = db.Books;
            if (!string.IsNullOrEmpty(searchString))
            {
                model=model.Where(x => x.name.Contains(searchString));
            }

            return model.OrderByDescending(c=>c.idbook).ToPagedList(page, pageSize);
    }
   

        public void AddBook(string name, string nameauthor,int idctg,float price,string linkimg)
        {
            string sql = $"insert into Book(name,nameauthor,idctg,price,linkimg) values(N'{name}',N'{nameauthor}',{idctg},{price},N'{linkimg}')";
            db.Database.ExecuteSqlCommand(sql);
        }
        public void EditBook(int id,string name, string nameauthor, int idctg, float price,string linkimg)
        {
            string sql = $" update book set name=N'{name}', nameauthor=N'{nameauthor}',idctg={idctg},price={price}, linkimg='{linkimg}' where idbook= {id}";
            db.Database.ExecuteSqlCommand(sql);
        }

        public List<Category>  GetAllCategory()
        {
            return db.Categories.ToList();
        }

     

        public void Save()
        {
            db.SaveChanges();

        }



    }
}