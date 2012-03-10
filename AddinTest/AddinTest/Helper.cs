using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using EnvDTE;
using EnvDTE80;

namespace AddinTest
{
    /// <summary>
    /// Exposes general helper functions for entire application
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Gets the specified resource as a stream.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>Stream</returns>
        public static Stream GetResource(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string[] test = assembly.GetManifestResourceNames();

            return assembly.GetManifestResourceStream(assembly.GetName().Name + "." + resourceName);
        }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projects">The solution projects.</param>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>Project</returns>
        public static Project GetProject(Projects projects, string projectName)
        {
            foreach (Project item in projects)
            {
                if (item.Name.ToLower().Contains(projectName.ToLower()))
                {
                    return item;
                }
            }

            return null;
        }

        public static void CollapseSolution(DTE2 application)
        {

            // Get the the Solution Explorer tree 
            UIHierarchy solutionExplorer;
            solutionExplorer = (UIHierarchy)application.Windows.Item(Constants.vsext_wk_SProjectWindow).Object;

            // Check if there is any open solution 
            if ((solutionExplorer.UIHierarchyItems.Count == 0))
            {
                return;
            }

            // Get the top node (the name of the solution) 
            UIHierarchyItem rootNode = solutionExplorer.UIHierarchyItems.Item(1);
            rootNode.DTE.SuppressUI = true;

            // Collapse each project node 
            Collapse(rootNode, ref solutionExplorer);

            // Select the solution node, or else when you click 
            // on the solution window 
            // scrollbar, it will synchronize the open document 
            // with the tree and pop 
            // out the corresponding node which is probably not what you want. 

            rootNode.Select(vsUISelectionType.vsUISelectionTypeSelect);

            rootNode.DTE.SuppressUI = false;
        }

        private static void Collapse(UIHierarchyItem item, ref UIHierarchy solutionExplorer)
        {

            foreach (UIHierarchyItem innerItem in item.UIHierarchyItems)
            {
                if (innerItem.UIHierarchyItems.Count > 0)
                {

                    // Re-cursive call 
                    Collapse(innerItem, ref solutionExplorer);

                    // Collapse 
                    if (innerItem.UIHierarchyItems.Expanded)
                    {
                        innerItem.UIHierarchyItems.Expanded = false;
                        if (innerItem.UIHierarchyItems.Expanded == true)
                        {
                            // Bug in VS 2005 
                            innerItem.Select(vsUISelectionType.vsUISelectionTypeSelect);
                            solutionExplorer.DoDefaultAction();
                        }

                    }
                }

            }
        }

    }
}
