using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Services;
using SQLite;
using ToDoList.Dependencies;
using ToDoList.Models;
using Xamarin.Forms;
namespace ToDoList.Repository
{
	public class RepositoryItems:IRepositoryItems
	{
		private readonly SQLiteConnection _cn;

		public RepositoryItems()
		{
			this._cn = Xamarin.Forms.DependencyService.Get<IDataBase>().GetConnection();
		}
		public void CreateBBDD()
		{
			this._cn.DropTable<TodoItem>();

			this._cn.CreateTable<TodoItem>();

		}

		public List<TodoItem> GetTasks()
		{
			var query = from data in _cn.Table<TodoItem>()
				select data;

			return query.ToList();
		}
		public void InsertTask(string description, bool isCompleted)
		{
			var item = new TodoItem
			{
				Description = description,
				IsCompleted = isCompleted
			};
			this._cn.Insert(item);
		}
		public void UpdateTask(int id)
		{
			TodoItem item = this.SearchTask(id);
			item.	Id = id;
			item.IsCompleted = true;
			item.ImageComplete = "complete";
			this._cn.Update(item);
		}

		public TodoItem SearchTask(int id)
		{
			var query = from data in _cn.Table<TodoItem>()
				where data.Id == id
				select data;
			return query.FirstOrDefault();
		}

		public void DeleteTask(int id)
		{
			TodoItem item = this.SearchTask(id);
			this._cn.Delete<TodoItem>(id);
		}

	}
}
