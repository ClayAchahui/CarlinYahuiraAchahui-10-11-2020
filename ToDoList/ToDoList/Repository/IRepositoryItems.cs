using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Models;

namespace ToDoList.Repository
{
	public interface IRepositoryItems
	{
		List<TodoItem> GetTasks();
		void InsertTask( string description, bool isCompleted);
		void UpdateTask(int id);
		TodoItem SearchTask(int id);
		void DeleteTask(int id);
		void CreateBBDD();

	}
}
