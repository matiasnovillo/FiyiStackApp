using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Properties;

namespace FiyiStackApp
{
    public partial class ProjectForm : Form
    {
        bool Loading = false;
        bool ToggleForFilterYourProjects = false;
        
        public ProjectForm()
        {
            try
            {
                InitializeComponent();

                Loading = true;
                ToolStatusLabel.Text = "Loading";
                Cursor = Cursors.WaitCursor;

                //Set border radius to various components
                //LeftSide Panel
                txtSearchYourProjectByName.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
                ListViewYourProjects.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
                //RightSide Panel
                PropertyGridProject.SelectedObject = new Project();
               
                //Load your projects
                LoadYourProjects();

                NewProject();

                //Basic
                ToolStatusLabel.Text = "Ready";
                Cursor = Cursors.Default;
                Loading = false;
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        #region Primary Configuration LeftSidePanel
        private void btnDeleteYourProjects_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewYourProjects.Items.Count; i++)
                {
                    if (ListViewYourProjects.Items[i].Checked)
                    {
                        UserProject UserProject = new UserProject(Convert.ToInt32(ListViewYourProjects.Items[i].Tag));
                        UserProject.DeleteByProjectId();
                        
                        Project Project = new Project(Convert.ToInt32(ListViewYourProjects.Items[i].Tag));
                        Project.DeleteByProjectId();

                        List<DataBase> lstDataBase = new DataBase().GetAllByProjectIdToModel(Project.ProjectId);
                        foreach (DataBase DataBase in lstDataBase)
                        {
                            List<Table> lstTable = new Table().GetAllByDataBaseIdToModel(DataBase.DataBaseId);

                            foreach (Table Table in lstTable)
                            {
                                List<Field> lstField = new Field().GetAllByTableIdToModel(Table.TableId);

                                foreach (Field Field in lstField)
                                {
                                    Field.DeleteByFieldId(Field.FieldId);
                                }

                                Table.DeleteByTableId(Table.TableId);
                            }

                            DataBase.DeleteByDataBaseId();
                        }
                    }
                }
                LoadYourProjects();
            }
            catch (Exception ex)
            {
                ToolStatusLabel.Text = ex.Message;
            }
        }

        private void LoadYourProjects()
        {
            UserProject UserProject = new UserProject();
            List<UserProject> _lstUserProject = new List<UserProject>();
            _lstUserProject = UserProject.GetAllByUserIdByProjectNameByAccessTypeIdToModel(Program.WinFormConfigurationComponent.UserLogged.UserId, txtSearchYourProjectByName.Text, 0);
            ListViewYourProjects.Items.Clear();
            Program.WinFormConfigurationComponent.lstYourFiyiStackProjects.Clear();
            int i = 0;
            foreach (var userproject in _lstUserProject)
            {
                Project Project = new Project(userproject.ProjectId);
                ListViewItem lvi = new ListViewItem(Project.Name);
                lvi.Tag = Project.ProjectId;

                if (userproject.AccessTypeId == 1)  //Private
                {
                    lvi.ImageIndex = 0;
                    ListViewYourProjects.Items.Add(lvi);
                }
                if (userproject.AccessTypeId == 2)  //With link invitation
                {
                    lvi.ImageIndex = 1;
                    ListViewYourProjects.Items.Add(lvi);
                }
                if (userproject.AccessTypeId == 3)  //Public
                {
                    lvi.ImageIndex = 2;
                    ListViewYourProjects.Items.Add(lvi);
                }
                i += 1;

                Program.WinFormConfigurationComponent.lstYourFiyiStackProjects.Add(Project);
            }
        }

        private void txtSearchYourProjectByName_KeyDown(object sender, KeyEventArgs e)
        {
            LoadYourProjects();
        }

        private void cmbAccessTypeForYourProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYourProjects();
        }

        private void ListViewYourProjects_ItemActivate(object sender, EventArgs e)
        {
            ToolStatusLabel.Text = "Loading";
            Cursor = Cursors.WaitCursor;
            btnNewOrEdit.Image = Resources.btnEdit;

            foreach (ListViewItem item in ListViewYourProjects.Items)
            {
                LoadOneProjectToEdit(item, "myprojects");
            }

            ToolStatusLabel.Text = "Ready";
            Cursor = Cursors.Default;
        }

        private void LoadOneProjectToEdit(ListViewItem lviWithProjectInformation, string ProjectType)
        {
            if (lviWithProjectInformation.Selected)
            {
                labelNewOrEditProject.Text = lviWithProjectInformation.Text.Length > 8 ? lviWithProjectInformation.Text.Substring(0, 8) + "..." : lviWithProjectInformation.Text;

                Project ProjectChosen = new Project();
                if (ProjectType == "myprojects")
                {
                    ProjectChosen = Program.WinFormConfigurationComponent.lstYourFiyiStackProjects.Find(project =>
                            project.ProjectId == Convert.ToInt32(lviWithProjectInformation.Tag)); 
                }
                else // externalprojects
                {
                    ProjectChosen = Program.WinFormConfigurationComponent.lstNotYourFiyiStackProjects.Find(project =>
                            project.ProjectId == Convert.ToInt32(lviWithProjectInformation.Tag));
                }

                //Load Basic panel of selected project
                Program.WinFormConfigurationComponent.ProjectChosen = new Project(ProjectChosen.ProjectId);
                PropertyGridProject.SelectedObject = Program.WinFormConfigurationComponent.ProjectChosen;
            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void NewProject()
        {
            ToolStatusLabel.Text = "Loading";
            Cursor = Cursors.WaitCursor;

            //Configure panel navigator
            Panel0Basic.Visible = true;

            //Basic
            btnNewOrEdit.Image = Resources.btnNew;
            labelNewOrEditProject.Text = "NEW PROJECT";
            PropertyGridProject.SelectedObject = new Project();

            //Create a "zero" Project
            Program.WinFormConfigurationComponent.ProjectChosen = new Project();

            ToolStatusLabel.Text = "Ready";
            Cursor = Cursors.Default;
        }
        #endregion

        #region Secondary Configuration LeftSidePanel
        private void btnShowFiltersForSavedProjects_Click(object sender, EventArgs e)
        {
            if (ToggleForFilterYourProjects)
            {
                btnShowFiltersForYourProjects.Image = Resources.Filter;
                PanelYourProjects.Visible = true;
                PanelFiltersForYourProjects.Visible = false;
                ToggleForFilterYourProjects = false;
            }
            else
            {
                btnShowFiltersForYourProjects.Image = Resources.Previous;
                PanelYourProjects.Visible = false;
                PanelFiltersForYourProjects.Visible = true;
                ToggleForFilterYourProjects = true;
            }
        }

        private void ListViewYourProjects_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnImportProject_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnJoinProject_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnGoBackToListOfSavedProjects_Click(object sender, EventArgs e)
        {
            PanelYourProjects.Visible = true;
            PanelFiltersForYourProjects.Visible = false;
        }

        private void txtSearchYourProjectByName_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void cmbAccessTypeForYourProjects_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void txtSearchUser_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewPublicProjectsToJoin_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewPublicProjectsJoined_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }
        #endregion

        #region Primary Configuration RightSidePanel
        private void btnNewOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStatusLabel.Text = "Validating";
                Cursor = Cursors.WaitCursor;

                //Reset timer
                Program.WinFormConfigurationComponent.timer.Stop();
                Program.WinFormConfigurationComponent.timer.Start();

                int _ProjectId = 0;
                if (Program.WinFormConfigurationComponent.ProjectChosen.ProjectId == 0) //New project
                {
                    ToolStatusLabel.Text = "Creating new project";

                    #region Basic
                    Program.WinFormConfigurationComponent.ProjectChosen = (Project)PropertyGridProject.SelectedObject;
                    Program.WinFormConfigurationComponent.ProjectChosen.Active = true;
                    Program.WinFormConfigurationComponent.ProjectChosen.DateTimeCreation = DateTime.Now;
                    Program.WinFormConfigurationComponent.ProjectChosen.DateTimeLastModification = Program.WinFormConfigurationComponent.ProjectChosen.DateTimeCreation;
                    Program.WinFormConfigurationComponent.ProjectChosen.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    Program.WinFormConfigurationComponent.ProjectChosen.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId; 
                    #endregion

                    _ProjectId = Program.WinFormConfigurationComponent.ProjectChosen.Add();

                    #region Access
                    UserProject UserProject = new UserProject();
                    UserProject.UserId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    UserProject.AccessTypeId = 1;
                    UserProject.ProjectId = _ProjectId;
                    #endregion

                    UserProject.Active = true;
                    UserProject.DateTimeCreation = DateTime.Now;
                    UserProject.DateTimeLastModification = UserProject.DateTimeCreation;
                    UserProject.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    UserProject.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    UserProject.Add();
                }
                else //Edit project
                {
                    ToolStatusLabel.Text = "Editing project";

                    _ProjectId = Program.WinFormConfigurationComponent.ProjectChosen.ProjectId;

                    #region Basic
                    Program.WinFormConfigurationComponent.ProjectChosen = (Project)PropertyGridProject.SelectedObject;
                    Program.WinFormConfigurationComponent.ProjectChosen.Active = true;
                    //Program.WinFormConfigurationComponent.ProjectChosen.DateTimeCreation = DateTime.Now; NO MODIFICATION
                    Program.WinFormConfigurationComponent.ProjectChosen.DateTimeLastModification = DateTime.Now;
                    //Program.WinFormConfigurationComponent.ProjectChosen.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId; NO MODIFICATION
                    Program.WinFormConfigurationComponent.ProjectChosen.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;

                    Program.WinFormConfigurationComponent.ProjectChosen.Update(); 
                    #endregion

                    #region Access
                    UserProject UserProject = new UserProject(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId);
                    #endregion

                    #region Delete a UserId that is present in the table but is not present in the listview
                    if (UserProject.UsersIdThatHasBeenInvited != null && UserProject.UsersIdThatHasBeenInvited != "")
                    {
                        //Se pasa el valor de UserProject/UsersIdThatHasBeenInvited a un string temporal para no afectar su valor original
                        //en las proximas lineas
                        string tmpUsersIdThatHasBeenInvited = UserProject.UsersIdThatHasBeenInvited;
                        //Se saca el ; del final para no generar error en las siguientes lineas
                        tmpUsersIdThatHasBeenInvited = tmpUsersIdThatHasBeenInvited.TrimEnd(';');
                        string[] strUsersIdThatHasBeenInvited = tmpUsersIdThatHasBeenInvited.Split(';');
                        bool flagofdeletion1 = true;
                        foreach (string strUserIdThatHasBeenInvited in strUsersIdThatHasBeenInvited)
                        {
                            if (flagofdeletion1)
                            {
                                //Ways to delete in a tag column
                                if (UserProject.UsersIdThatHasBeenInvited == $"{strUserIdThatHasBeenInvited};")
                                {
                                    UserProject.UsersIdThatHasBeenInvited = "";
                                }
                                else
                                {
                                    if (UserProject.UsersIdThatHasBeenInvited.EndsWith($"{strUserIdThatHasBeenInvited};"))
                                    {
                                        UserProject.UsersIdThatHasBeenInvited = UserProject.UsersIdThatHasBeenInvited.Replace($"{strUserIdThatHasBeenInvited};", ";");
                                    }
                                    else
                                    {
                                        if (!UserProject.UsersIdThatHasBeenInvited.EndsWith($"{strUserIdThatHasBeenInvited};"))
                                        {
                                            UserProject.UsersIdThatHasBeenInvited = UserProject.UsersIdThatHasBeenInvited.Replace($"{strUserIdThatHasBeenInvited};", "");
                                        }
                                    }
                                }
                            }
                            else { flagofdeletion1 = true; } //To reset the flag for the next Items[i]
                        }
                    }

                    if (UserProject.UsersIdThatAcceptedInvitation != null && UserProject.UsersIdThatAcceptedInvitation != "")
                    {
                        string tmpUsersIdThatAcceptedInvitation = UserProject.UsersIdThatAcceptedInvitation;
                        tmpUsersIdThatAcceptedInvitation = tmpUsersIdThatAcceptedInvitation.TrimEnd(';');
                        string[] strUsersIdThatAcceptedInvitation = tmpUsersIdThatAcceptedInvitation.Split(';');
                        bool flagofdeletion2 = true;
                        foreach (string strUserIdThatAcceptedInvitation in strUsersIdThatAcceptedInvitation)
                        {
                            if (flagofdeletion2)
                            {
                                //Ways to delete in a tag column
                                if (UserProject.UsersIdThatAcceptedInvitation == $"{strUserIdThatAcceptedInvitation};")
                                {
                                    UserProject.UsersIdThatAcceptedInvitation = "";
                                }
                                else
                                {
                                    if (UserProject.UsersIdThatAcceptedInvitation.EndsWith($"{strUserIdThatAcceptedInvitation};"))
                                    {
                                        UserProject.UsersIdThatAcceptedInvitation = UserProject.UsersIdThatAcceptedInvitation.Replace($"{strUserIdThatAcceptedInvitation};", ";");
                                    }
                                    else
                                    {
                                        if (!UserProject.UsersIdThatAcceptedInvitation.EndsWith($"{strUserIdThatAcceptedInvitation};"))
                                        {
                                            UserProject.UsersIdThatAcceptedInvitation = UserProject.UsersIdThatAcceptedInvitation.Replace($"{strUserIdThatAcceptedInvitation};", "");
                                        }
                                    }
                                }
                            }
                            else { flagofdeletion2 = true; } //To reset the flag for the next Items[i]
                        }
                    } 
                    #endregion

                    UserProject.Active = true;
                    //UserProject.DateTimeCreation = DateTime.Now; NO MODIFICATION
                    UserProject.DateTimeLastModification = UserProject.DateTimeCreation;
                    //UserProject.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId; NO MODIFICATION
                    UserProject.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    UserProject.UpdateByUserProjectId();
                }

                Program.WinFormConfigurationComponent.ProjectChosen = new Project(_ProjectId);
                ToolStatusLabel.Text = "Data saved. Configuring generator. This may take a while";
                Cursor = Cursors.Default;
                this.Dispose();
                GeneratorForm GeneratorForm = new GeneratorForm();
                GeneratorForm.ShowDialog();
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }
        #endregion

        #region Secondary Configuration RightSidePanel
        private void chbIAcceptTermsAndConditions_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                ToolStatusLabel.Text = "Saving configuration";
                Cursor = Cursors.WaitCursor;

                int _UserId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                Program.WinFormConfigurationComponent.UserLogged.UpdateByUserId();
                Program.WinFormConfigurationComponent.UserLogged = new User(_UserId);

                ToolStatusLabel.Text = "Ready. Configuration saved";
                Cursor = Cursors.Default; 
            }
        }

        private void txtAddUserToProject_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewPeopleWithInvitationLink_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void cmbDataBase_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void cmbProjectTypeId_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void cmbBackEnd_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void cmbFrontEnd_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void ListViewIHaveMyOwnLibrariesAndTemplates_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewFiyiStackLibrariesAndTemplates_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewStackDataBase_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewStackBackEnd_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewStackFrontEnd_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtProjectName_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtGeneralHistoryUser_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtPath_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnNew_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }
        #endregion

        #region Third Configuration. All Form
        private void ProjectForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Reset timer
            Program.WinFormConfigurationComponent.timer.Stop();
            Program.WinFormConfigurationComponent.timer.Start();
        }
        #endregion

        #region Configuration MenuStrip
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WinFormConfigurationComponent.UserLogged =  (User)Converter.SetObjectPropertiesToNull(Program.WinFormConfigurationComponent.UserLogged);
            Program.WinFormConfigurationComponent = new WinFormConfigurationComponent();
            this.Dispose();
            LoginForm LoginForm = new LoginForm();
            LoginForm.ShowDialog();
        }

        private void StatusStrip_Click(object sender, EventArgs e)
        {
            Program.WinFormConfigurationComponent.SetClipBoard(ToolStatusLabel.Text + "\n");
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserData ChangePassword = new ChangeUserData();
            ChangePassword.ShowDialog();
        }
        #endregion

        private void btnFolderBrowserDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = FolderBrowserDialog.ShowDialog();
        }
    }
}
