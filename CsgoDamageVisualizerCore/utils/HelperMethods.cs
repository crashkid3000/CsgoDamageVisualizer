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
            /// <summary>
            /// The CsgoDamageVisualizerCore project (...\CsgoDamageVisualizerCore)
            /// </summary>
            CORE,
            /// <summary>
            /// The CsgoDamageVisualizerDesktop project (...\CSgtoDamageVisualizer)
            /// </summary>
            DESKTOP,
            /// <summary>
            /// The CsgoDamageVisualizerWeb project (...\CsgoDamageVisualizerWeb)
            /// </summary>
            ASPX,
            /// <summary>
            /// The CsgoDamageVisualizerTests project (...\CsgoDamageVisualizerTests)
            /// </summary>
            TEST,
            /// <summary>
            /// The base project CsgoDamageVisualizer, containing all the other projects
            /// </summary>
            SUPER    
        }

        private static Dictionary<Project, string> projectDirBaseNames = new Dictionary<Project, string>()
        {
            [Project.CORE] = "CsgoDamageVisualizerCore",
            [Project.DESKTOP] = "CSgtoDamageVisualizer",
            [Project.ASPX] = "CsgoDamageVisualizerWeb",
            [Project.TEST] = "CsgoDamageVisualizerTests",
            [Project.SUPER] = "n/A"
        };
        
        /// <summary>
        /// Gets the base dir on the local file system of the given project
        /// </summary>
        /// <param name="project">The project to choose from</param>
        /// <param name="sourceFilePath">DO NOT SET THIS VALUE</param>
        /// <returns></returns>
        /// <exception cref="Exception">If this value failed to be set automatically</exception>
        /// <exception cref="ArgumentException">IF the project dir could not be found</exception>
        public Uri GetProjectBaseDir(Project project, [CallerFilePath] string sourceFilePath = "a#b")
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

            if (Project.SUPER == project)
            {
                return new Uri(dirInfo?.FullName ?? throw new ArgumentException("Could not find base dir: Calling file is not inside any project."));
            }
            else
            {
                return new Uri(new Uri(dirInfo?.FullName ?? throw new ArgumentException("Could not find base dir: Calling file is not inside any project.")), projectDirBaseNames[project]);
            }

        }


    }

    
}
