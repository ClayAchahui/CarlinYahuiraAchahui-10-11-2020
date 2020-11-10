using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using ToDoList.Dependencies;
using ToDoList.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SqlLiteClient))]
namespace ToDoList.iOS
{
	public class SqlLiteClient:IDataBase
	{
		public SQLiteConnection GetConnection()
		{
			var bbddfile = "Todo.db";
			var routeDocs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var librarypath = Path.Combine(routeDocs, "..", "Library", "Databases");
            if (!Directory.Exists(librarypath))
            {
                Directory.CreateDirectory(librarypath);
            }
            var path = Path.Combine(librarypath, bbddfile);
            SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(path);
            return connection;
		}
	}
}