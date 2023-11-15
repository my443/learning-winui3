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

			Project newProject = new Project();
			newProject.Name = "Project 1";
			newProject.Activities.Add(new Activity()
			{ Name = "Activity 1", Complete = true, DueDate = startDate.AddDays(4) });
			newProject.Activities.Add(new Activity()
			{ Name = "Activity 2", Complete = true, DueDate = startDate.AddDays(5) });
			Projects.Add(newProject);

			newProject = new Project();
			newProject.Name = "Project 2";
			newProject.Activities.Add(new Activity()
			{ Name = "Activity A", Complete = true, DueDate = startDate.AddDays(2) });
			newProject.Activities.Add(new Activity()
			{ Name = "Activity B", Complete = false, DueDate = startDate.AddDays(3) });
			Projects.Add(newProject);

			newProject = new Project();
			newProject.Name = "Project 3";
			Projects.Add(newProject);

			cvsProjects.Source = Projects;
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

