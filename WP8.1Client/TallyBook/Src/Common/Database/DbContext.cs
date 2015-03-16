﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Common.Model;
using SQLite;
namespace App1
{
    public class DbContext:Singleton<DbContext>
    {
        public const string DBNAME = "db.sdf"; 
        public DbContext()
        {
            Conn = new SQLiteAsyncConnection(DBNAME);
            Seed();
        }

        public SQLiteAsyncConnection Conn;

        private void Seed()
        {
            //var existed = await Conn.QueryAsync<commonQueryModel>("SELECT Name FROM sqlite_master WHERE type='table' AND name='RecorderItem';");
            //if (existed.Count>0)
            //{
            //    return;
            //}
           // Conn.DropTableAsync<RecorderItem>().Wait();
            Conn.CreateTablesAsync<Recorder,RecorderItem>().Wait();
            
        }
        public void CreateConnection()
        {
            Conn = new SQLiteAsyncConnection(DBNAME);
            //Seed();
        }

    }
    public class commonQueryModel
    {
        public string Name { get; set; }
    }
}
