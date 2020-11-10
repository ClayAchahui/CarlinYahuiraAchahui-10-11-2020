using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Dependencies
{
	public interface IDataBase
	{
		SQLite.SQLiteConnection GetConnection();
	}
}
