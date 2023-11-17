// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static System.Net.Mime.MediaTypeNames;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App4
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		DateTime startDate = DateTime.Now;
		public MainWindow()
		{
			this.InitializeComponent();
			PopulateProjects();
		}

		private void PopulateProjects()
		{
			List<Project> Projects = new List<Project>();

			for (int i = 0; i < 10; i++) { 
				Project newProject = new Project();
				newProject.Name = "Project " + i.ToString();
				newProject.Activities.Add(new Activity()
				{ Name = "Activity 1 for Project "+i.ToString(), Complete = true, DueDate = startDate.AddDays(4) });
				newProject.Activities.Add(new Activity()
				{ Name = "Activity 2 for Project "+i.ToString(), Complete = true, DueDate = startDate.AddDays(5) });
				Projects.Add(newProject);
			}

			//newProject = new Project();
			//newProject.Name = "Project 2";
			//newProject.Activities.Add(new Activity()
			//{ Name = "Activity A", Complete = true, DueDate = startDate.AddDays(2) });
			//newProject.Activities.Add(new Activity()
			//{ Name = "Activity B", Complete = false, DueDate = startDate.AddDays(3) });
			//Projects.Add(newProject);

			//newProject = new Project();
			//newProject.Name = "Project 3";
			//Projects.Add(newProject);

			cvsProjects.Source = Projects;
		}

		public async void ContentGridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			ContentDialog dialog = new ContentDialog();

			// XamlRoot must be set in the case of a ContentDialog running in a Desktop app
			dialog.XamlRoot = this.Content.XamlRoot;
			//dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
			dialog.Title = "Save your work?";
			dialog.PrimaryButtonText = "Save";
			dialog.SecondaryButtonText = "Don't Save";
			dialog.CloseButtonText = "Cancel";
			dialog.DefaultButton = ContentDialogButton.Primary;
			//dialog.Content = new ContentDialogContent();

			var result = await dialog.ShowAsync();


		}

	}

	public class Project
	{
		public Project()
		{
			Activities = new ObservableCollection<Activity>();
		}

		public string Name { get; set; }
		public ObservableCollection<Activity> Activities { get; private set; }
	}

	public class Activity
	{
		public string Name { get; set; }
		public DateTime DueDate { get; set; }
		public bool Complete { get; set; }
		public string Project { get; set; }
	}
}

