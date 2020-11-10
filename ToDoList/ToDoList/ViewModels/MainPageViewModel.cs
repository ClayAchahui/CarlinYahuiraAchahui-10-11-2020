using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private ObservableCollection<TodoItem> _tasks;
		private DelegateCommand _addCommand;
		private DelegateCommand<TodoItem> _completeCommand;
		private DelegateCommand<TodoItem> _deleteCommand;
		private readonly IRepositoryItems _repositoryItems;
		private string _description;
		public MainPageViewModel(INavigationService navigationService,IRepositoryItems repositoryItems)
			: base(navigationService)
		{
			Title = "Tasks app";
			_repositoryItems = repositoryItems;
			_repositoryItems.CreateBBDD();
		}

		public string Description
		{
			get => _description;
			set => SetProperty(ref _description, value);
		}
		public ObservableCollection<TodoItem> Tasks
		{
			get => _tasks;
			set => SetProperty(ref _tasks, value);
		}

		public DelegateCommand AddCommand => 
			_addCommand ?? (_addCommand = new DelegateCommand(AddNewTask));
		public DelegateCommand<TodoItem> CompleteCommand => 
			_completeCommand ?? (_completeCommand = new DelegateCommand<TodoItem>(UpdateTaskToCompleted));
		public DelegateCommand<TodoItem> DeleteCommand => 
			_deleteCommand ?? (_deleteCommand= new DelegateCommand<TodoItem>(DeleteTask));

		public void DeleteTask(TodoItem item)
		{
			if (item == null)
				return;
			_repositoryItems.DeleteTask(item.Id);
			GetListItems();
		}

		public void UpdateTaskToCompleted(TodoItem item)
		{
			if (item == null)
				return;
			if (item.IsCompleted)
				return;
			_repositoryItems.UpdateTask(item.Id);
			GetListItems();
		}

		public void AddNewTask()
		{
			if (Description == string.Empty)
				return;
			_repositoryItems.InsertTask(Description,false);
			GetListItems();
			Description = string.Empty;
		}

		public void GetListItems()
		{
			var listItems = _repositoryItems.GetTasks();
			Tasks=new ObservableCollection<TodoItem>(listItems);
		}

		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			GetListItems();
		}
	}
}
