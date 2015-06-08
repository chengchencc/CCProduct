using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EDMWebsite.Models.DbModels;
using EDMWebsite.Models;

namespace EDMWebsite.Controllers
{
    public class InitialDataController : Controller
    {
        // GET: InitialData
        public async Task<ActionResult> Comdict()
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                db.Database.Log = s =>
                {
                    Debug.Write(s);
                    //var sql = string.Format("insert into efdblog (createTime,context,content) values('{0}','{1}','{2}')", DateTime.Now, "WriteableDbContext", s);
                    //db.Database.ExecuteSqlCommand(sql);
                };

                db.Comdicts.Add(new Comdict("建筑", "0", "行政办公建筑"));
                db.Comdicts.Add(new Comdict("建筑", "1", "教学楼"));
                db.Comdicts.Add(new Comdict("建筑", "2", "场馆类"));
                db.Comdicts.Add(new Comdict("建筑", "3", "食堂"));
                db.Comdicts.Add(new Comdict("建筑", "4", "学生宿舍"));
                db.Comdicts.Add(new Comdict("建筑", "5", "大型或特殊实验室"));
                db.Comdicts.Add(new Comdict("建筑", "6", "医院"));
                db.Comdicts.Add(new Comdict("建筑", "7", "其他"));

                db.Comdicts.Add(new Comdict("行政办公建筑", "0", "办公室"));
                db.Comdicts.Add(new Comdict("行政办公建筑", "1", "后勤楼"));
                db.Comdicts.Add(new Comdict("行政办公建筑", "2", "物管楼"));

                await db.SaveChangesAsync();
            }

            return Content("Success");
        }

        public ActionResult MysqlTest()
        {
            using (DeviceDbContext db = new DeviceDbContext())
            {
                var tb_data  = db.tb_data.ToList();
            }

            return Content("success");
        }

    }
}