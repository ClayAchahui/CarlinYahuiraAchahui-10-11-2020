using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using ToDoList.Dependencies;
using ToDoList.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlLiteClient))]
namespace ToDoList.Droid
{
	public class SqlLiteClient : IDataBase
	{
		public SQLiteConnection GetConnection()
		{
			var bbddfile = "Todo.db3";
			var routeDocs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(routeDocs, bbddfile);
            SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(path);
            return cn;	
		}
	}
}