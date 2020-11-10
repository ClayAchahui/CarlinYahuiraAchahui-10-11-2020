using System;
using System.Collections.Generic;
using Moq;
using Prism.Commands;
using Prism.Navigation;
using ToDoList.Models;
using ToDoList.Repository;
using ToDoList.ViewModels;
using Xunit;

namespace ToDoList.UnitTest
{
	public class MainPageViewModel_Tests
	{
		[Fact]
		public void MainPageViewModel_CtorTests()
		{
			var mockNavigationService=new Mock<INavigationService>();
			var mockRepositoryTask=new Mock<IRepositoryItems>();

			var main=new MainPageViewModel(mockNavigationService.Object,mockRepositoryTask.Object);
			Assert.NotNull(main.Title);
			Assert.Equal(main.Title,"Tasks app");
			Assert.NotNull(main.AddCommand);
			Assert.NotNull(main.DeleteCommand);
			Assert.NotNull(main.CompleteCommand);
			Assert.IsType<DelegateCommand<TodoItem>>(main.DeleteCommand);
			Assert.IsType<DelegateCommand<TodoItem>>(main.CompleteCommand);
			Assert.IsType<DelegateCommand>(main.AddCommand);
			Assert.IsType<string>(main.Description);
		}

		[Fact]
		public void DeleteTask_ShoulWorks()
		{
			var list=new List<TodoItem>
			{
				new TodoItem{Description = "Do homework"},
				new TodoItem{Description = "Go to market"},
			};
			var mockNavigationService=new Mock<INavigationService>();
			var mockRepositoryTask=new Mock<IRepositoryItems>();
			mockRepositoryTask
				.Setup(m => m.DeleteTask(It.IsAny<int>()));
			mockRepositoryTask
				.Setup(m => m.GetTasks()).Returns(list);
			var main=new MainPageViewModel(mockNavigationService.Object,mockRepositoryTask.Object);
			main.DeleteTask(new TodoItem());
			Assert.NotNull(main.Tasks);
			mockRepositoryTask
				.Verify(m => m.DeleteTask(It.IsAny<int>()));
			mockRepositoryTask
				.Verify(m => m.GetTasks());
		}
		[Fact]
		public void UpdateTaskToCompleted_ShoulWorks()
		{
			var list=new List<TodoItem>
			{
				new TodoItem{Description = "Do homework"},
				new TodoItem{Description = "Go to market"},
			};
			var mockNavigationService=new Mock<INavigationService>();
			var mockRepositoryTask=new Mock<IRepositoryItems>();
			mockRepositoryTask
				.Setup(m => m.UpdateTask(It.IsAny<int>()));
			mockRepositoryTask
				.Setup(m => m.GetTasks()).Returns(list);
			var main=new MainPageViewModel(mockNavigationService.Object,mockRepositoryTask.Object);
			main.UpdateTaskToCompleted(new TodoItem());
			Assert.NotNull(main.Tasks);
			mockRepositoryTask
				.Verify(m => m.UpdateTask(It.IsAny<int>()));
			mockRepositoryTask
				.Verify(m => m.GetTasks());
		}
		[Fact]
		public void AddNewTask_ShoulWorks()
		{
			var list=new List<TodoItem>
			{
				new TodoItem{Description = "Do homework"},
				new TodoItem{Description = "Go to market"},
			};
			var description = "to buy a pencil";
			var isCompleted = false;
			var mockNavigationService=new Mock<INavigationService>();
			var mockRepositoryTask=new Mock<IRepositoryItems>();
			mockRepositoryTask
				.Setup(m => m.InsertTask(It.IsAny<string>(),It.IsAny<bool>()));
			mockRepositoryTask
				.Setup(m => m.GetTasks()).Returns(list);
			var main=new MainPageViewModel(mockNavigationService.Object,mockRepositoryTask.Object);
			main.AddNewTask();
			Assert.NotNull(main.Tasks);
			Assert.Equal(main.Description,string.Empty);
			Assert.True(main.Tasks.Count>0);
			mockRepositoryTask
				.Verify(m => m.InsertTask(It.IsAny<string>(),It.IsAny<bool>()));
			mockRepositoryTask
				.Verify(m => m.GetTasks());
		}
		[Fact]
		public void GetListItems_ShoulWorks()
		{
			var list=new List<TodoItem>
			{
				new TodoItem{Description = "Do homework"},
				new TodoItem{Description = "Go to market"},
			};
			var description = "to buy a pencil";
			var isCompleted = false;
			var mockNavigationService=new Mock<INavigationService>();
			var mockRepositoryTask=new Mock<IRepositoryItems>();
			mockRepositoryTask
				.Setup(m => m.GetTasks()).Returns(list);
			var main=new MainPageViewModel(mockNavigationService.Object,mockRepositoryTask.Object);
			main.AddNewTask();
			Assert.NotNull(main.Tasks);
			mockRepositoryTask
				.Verify(m => m.GetTasks());
		}
	}
}
