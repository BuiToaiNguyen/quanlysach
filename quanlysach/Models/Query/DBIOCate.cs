using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlysach.Models.DB;
using PagedList;
namespace quanlysach.Models.Query
{
    public class DBIOCate


    {

        private MyDB db = new MyDB();
        public void AddCate(string nameCate, string description )
        {
            string sql = $"insert into Category (nametype ,decription) values(N'{nameCate}',N'{description}')";
            db.Database.ExecuteSqlCommand(sql);
        }
        public void EditCate(int idcate,string nameCate, string description)
        {
            string sql = $"update category set nametype=N'{nameCate}', decription=N'{description}' where idcate={idcate}";
            db.Database.ExecuteSqlCommand(sql);
        }

        public void DeleteCateandBook(int idcate)
        {
            string sql = $"delete from Book where idctg = {idcate}";
            db.Database.ExecuteSqlCommand(sql);
            string sql2 = $"delete from category where idcate = {idcate}";
            db.Database.ExecuteSqlCommand(sql2);

        }
        public IEnumerable<Category> getListCategory(int page = 1, int pageSize=2,string searchString="")
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.nametype.Contains(searchString));
            }
            return model.OrderByDescending(c => c.idcate).ToPagedList(page, pageSize);
        }


        public void Save()
        {
            db.SaveChanges();

        }

    }
}