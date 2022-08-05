using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.utils
{
    public class HelperMethods
    {

        public enum Project
        {
            CORE,
            DESKTOP,
            ASPX,
            TEST
        }

        private static Dictionary<Project, string> projectDirBaseNames = new Dictionary<Project, string>()
        {
            [Project.CORE] = "CsgoDamageVisualizerCore",
            [Project.DESKTOP] = "CSgtoDamageVisualizer",
            [Project.ASPX] = "CsgoDamageVisualizerWeb",
            [Project.TEST] = "CsgoDamageVisualizerTests"
        };

        public Uri GetProjectBaseDirt(Project project, [CallerFilePath] string sourceFilePath = "a#b")
        {

            if (sourceFilePath.Equals("a#b"))
            {
                throw new Exception("Could not get CallerFilePath");
            }
            DirectoryInfo dirInfo = new DirectoryInfo(sourceFilePath);
            while (dirInfo != null && !dirInfo.Name.Equals("CsgoDamageVisualizer"))
            {
                dirInfo = dirInfo.Parent;
            }
            return new Uri(new Uri(dirInfo.FullName), projectDirBaseNames[project]);

        }


    }

    
}
