using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;
using System.IO;
using System.Reflection;

namespace AddinTest
{
    public partial class WCFSolution : Form
    {
        private DTE2 _applicationObject;

        public WCFSolution()
        {
            InitializeComponent();
        }

        public void AttachDTE(DTE2 passedInDTE)
        {
            _applicationObject = passedInDTE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servicePath;
            Project bllProject;
            Project dataProject;
            Project contractProject;
            Project serviceProject;
            Project hostProject;
            Project testProject;
            string deploymentPath = string.Empty;

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Error: Must enter a name");
                return;
            }
            if (string.IsNullOrEmpty(NamespaceTextBox.Text))
            {
                MessageBox.Show("Error: Must enter a namespace");
                return;
            }
            if (string.IsNullOrEmpty(PathTextBox.Text))
            {
                MessageBox.Show("Error: Must enter a path");
                return;
            }

            string serviceName = NameTextBox.Text;
            string serviceNamespace = NamespaceTextBox.Text;

            try
            {
                servicePath = string.Format(@"{0}\", PathTextBox.Text);
                _applicationObject.Solution.Create(string.Format(@"{0}{1}\Trunk\", servicePath, serviceName), serviceName);
                
                string class40TemplatePath = ((Solution2)_applicationObject.Solution).GetProjectTemplate("ClassLibrary.zip", "csproj");
                string hostTemplatePath = ((Solution2)_applicationObject.Solution).GetProjectTemplate(@"WAPService.zip", "CSharp");
                string unitTestPath = ((Solution2)_applicationObject.Solution).GetProjectTemplate("TestProject.zip", "csproj");

                _applicationObject.Solution.AddFromTemplate(class40TemplatePath, String.Format(@"{0}{1}\Trunk\Controllers\", servicePath, serviceName), "Controllers", false);
                _applicationObject.Solution.AddFromTemplate(class40TemplatePath, String.Format(@"{0}{1}\Trunk\Data\", servicePath, serviceName), "Data", false);
                _applicationObject.Solution.AddFromTemplate(class40TemplatePath, String.Format(@"{0}{1}\Trunk\Contracts\", servicePath, serviceName), "Contracts", false);
                _applicationObject.Solution.AddFromTemplate(class40TemplatePath, String.Format(@"{0}{1}\Trunk\Services\", servicePath, serviceName), "Services", false);
                _applicationObject.Solution.AddFromTemplate(hostTemplatePath, String.Format(@"{0}{1}\Trunk\Host\", servicePath, serviceName), "Host", false);
                _applicationObject.Solution.AddFromTemplate(unitTestPath, String.Format(@"{0}{1}\Trunk\UnitTests\", servicePath, serviceName), "UnitTests", false);

                _applicationObject.Solution.SaveAs(String.Format(@"{0}{1}\Trunk\{2}.sln", servicePath, serviceName, serviceName));

                bllProject = Helper.GetProject(_applicationObject.Solution.Projects, "Controllers");
                string bllNamespace = String.Format("{0}.BLL.{1}", serviceNamespace, serviceName);
                SetProjectProperties(bllProject, bllNamespace, true, true);

                dataProject = Helper.GetProject(_applicationObject.Solution.Projects, "Data");
                string dalNamespace = String.Format("{0}.DAL.{1}", serviceNamespace, serviceName);
                SetProjectProperties(dataProject, dalNamespace, true, true);
                
                contractProject = Helper.GetProject(_applicationObject.Solution.Projects, "Contracts");
                string contractsNamespace = String.Format("{0}.SAL.{1}.Contracts", serviceNamespace, serviceName);
                SetProjectProperties(contractProject, contractsNamespace, true, true);

                serviceProject = Helper.GetProject(_applicationObject.Solution.Projects, "Services");
                string servicesNamespace = String.Format("{0}.SAL.{1}.Services", serviceNamespace, serviceName);
                SetProjectProperties(serviceProject, servicesNamespace, true, true);

                hostProject = Helper.GetProject(_applicationObject.Solution.Projects, "Host");
                AddHostFiles(hostProject, servicesNamespace, contractsNamespace, serviceName);
                RemoveDummyClasses(hostProject.ProjectItems);

                testProject = Helper.GetProject(_applicationObject.Solution.Projects, "UnitTests");
                const string nameSpace = "UnitTests";
                AddAppConfig(testProject, serviceNamespace, serviceName);
                SetProjectProperties(testProject, nameSpace, false, false);

                SetProjectReferences(serviceProject, contractProject, dataProject);
                SetProjectReferences(bllProject, contractProject);
                SetProjectReferences(dataProject, contractProject);
                SetProjectReferences(testProject, serviceProject, contractProject, dataProject);
                SetProjectReferences(hostProject, serviceProject, contractProject, dataProject);
                
                Helper.CollapseSolution(_applicationObject);
                
                Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {                
                PathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SetProjectProperties(Project project, string nameSpace, bool useStyleCop, bool useXmlComments)
        {
            VSLangProj.VSProject vsProject;
            VSLangProj.References vsReferences;
            Configurations configs;
            string outputPath;
            string projectName = project.Name;

            project.Properties.Item("DefaultNamespace").Value = nameSpace;
            project.Properties.Item("AssemblyName").Value = nameSpace;

            vsProject = (VSLangProj.VSProject)project.Object;
            vsReferences = vsProject.References;
            vsReferences.Add(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ServiceModel.dll");
            vsReferences.Add(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Runtime.Serialization.dll");

            if (nameSpace.Contains(".DAL") || nameSpace.Contains("UnitTests"))
            {
                vsReferences.Add(@"C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\System.configuration.dll");
            }

            if (useXmlComments)
            {
                configs = project.ConfigurationManager.ConfigurationRow("Release");
                foreach (Configuration config in configs)
                {
                    outputPath = config.Properties.Item("OutputPath").Value.ToString();
                    config.Properties.Item("DocumentationFile").Value = String.Format("{0}{1}.XML", outputPath, nameSpace);
                }
            }

            RemoveDummyClasses(project.ProjectItems);
        }

        private static void SetProjectReferences(Project project, params Project[] args)
        {
            if (project.Kind == "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}")
            {
                VSLangProj.VSProject vsProject = (VSLangProj.VSProject)project.Object;
                foreach (Project item in args)
                {
                    vsProject.References.AddProject(item);
                }
            }
            else if (project.Kind == "{E24C65DC-7377-472b-9ABA-BC803B73C61A}")
            {
                VsWebSite.VSWebSite webProject = (VsWebSite.VSWebSite)project.Object;
                foreach (Project item in args)
                {
                    webProject.References.AddFromProject(item);
                }
            }

        }

        private static void RemoveDummyClasses(ProjectItems projectItems)
        {
            foreach (ProjectItem item in projectItems)
            {
                if (item.Name.Contains("Class"))
                {
                    item.Delete();
                }
                else if (item.Name == "App_Code")
                {
                    RemoveDummyClasses(item.ProjectItems);
                }

            }
        }

        private void AddHostFiles(Project project, string serviceNamespace, string contractNamespace, string serviceName)
        {
            string output = string.Empty;
            string filename = string.Empty;

            //Remove
            {
                var item = project.ProjectItems.Cast<ProjectItem>()
                    .FirstOrDefault(i => i.Name.ToLower().Equals("service1.svc"));
                if (item != null)
                {
                    item.Remove();
                }

                item = project.ProjectItems.Cast<ProjectItem>()
                    .FirstOrDefault(i => i.Name.ToLower().Equals("service1.svc.cs"));
                if (item != null)
                {
                    item.Remove();
                }
            }

            //Modify
            foreach (ProjectItem item in project.ProjectItems)
            {
                if (item.Name.ToLower() == "web.config")
                {
                    Window window = item.Open(Constants.vsViewKindPrimary);
                    window.Activate();

                    string newConfig = GetFromResources("AddinTest.default.web.config");
                    newConfig = newConfig.Replace("[servicename]", serviceNamespace + ".SERVICENAME");
                    newConfig = newConfig.Replace("[contract]", contractNamespace + ".CONTRACTNAME");
                    newConfig = newConfig.Replace("[connectionstring]", serviceName + "ConnectionString");
                    TextSelection selection = (TextSelection)window.Document.Selection;
                    selection.StartOfDocument(false);
                    selection.SelectAll();
                    selection.Delete(selection.Text.Length);
                    selection.Insert(newConfig, (int)vsInsertFlags.vsInsertFlagsInsertAtStart);

                    window.Document.Close(vsSaveChanges.vsSaveChangesYes);
                }
            }

            //Add
            string projectPath = Path.GetDirectoryName(project.FullName);

            output = GetFromResources("AddinTest.default.RENAMEME.svc");
            filename = Path.Combine(projectPath, "RENAMEME.svc");
            output = output.Replace("[servicename]", serviceNamespace + ".SERVICENAME");
            File.WriteAllText(filename, output);
            project.ProjectItems.AddFromFile(filename);

            output = GetFromResources("AddinTest.default.controller.cs");
            filename = Path.Combine(projectPath, string.Format("{0}Controller", serviceName));
            output = output.Replace("[namespace]", serviceNamespace);
            output = output.Replace("[contractusing]", string.Format("{0}.{1}.SAL.Contracts", serviceNamespace, serviceName));
            output = output.Replace("[controllername]", string.Format("{0}Controller", serviceName));
            output = output.Replace("[contractname]", string.Format("I{0}", serviceName));
            File.WriteAllText(filename, output);
            project.ProjectItems.AddFromFile(filename);

        }

        private void AddAppConfig(Project project, string contractNamespace, string serviceName)
        {
            string itemPath = ((Solution2)_applicationObject.Solution).GetProjectItemTemplate("AppConfig.zip", "csproj");
            project.ProjectItems.AddFromTemplate(itemPath, "app.config");

            foreach (ProjectItem item in project.ProjectItems)
            {
                if (item.Name.ToLower() == "app.config")
                {
                    Window window = item.Open(Constants.vsViewKindPrimary);
                    window.Activate();

                    string newConfig = GetFromResources("AddinTest.default.app.config");
                    newConfig = newConfig.Replace("[connectionstring]", serviceName + "ConnectionString");
                    newConfig = newConfig.Replace("[contract]", contractNamespace + ".CONTRACTNAME");
                    TextSelection selection = (TextSelection)window.Document.Selection;
                    selection.StartOfDocument(false);
                    selection.SelectAll();
                    selection.Delete(selection.Text.Length);
                    selection.Insert(newConfig, (int)vsInsertFlags.vsInsertFlagsInsertAtStart);

                    window.Document.Close(vsSaveChanges.vsSaveChangesYes);

                    break;
                }
            }

        }

        private string GetFromResources(string resourceName)
        {
            Assembly assem = GetType().Assembly;
            using (Stream stream = assem.GetManifestResourceStream(resourceName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error retrieving from Resources. resource name: '"
                                             + resourceName + "'\r\n" + e);
                }
            }
        }
    }
}
