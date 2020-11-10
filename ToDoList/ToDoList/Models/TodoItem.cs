using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoList.Models
{
	[Table("Item")]
	public class TodoItem
	{
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }

		public string Description { get; set; }
		public bool IsCompleted { get; set; }

		public string ImageComplete { get; set; } = "incomplete";
	}
}
