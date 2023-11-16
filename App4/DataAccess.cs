using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{

	class DataAccess
    {
        public List<string> projectList { get; set; }
        public DataAccess() {
			projectList = new List<string>();
			generateProjects(20);
        }

        private void generateProjects(int numberOfProjects) {
			string newProject;

			for (int i = 0; i < numberOfProjects; i++)
			{
				newProject = "Project Number " + i.ToString();
				projectList.Add(newProject);
			}
		}

    }
}
