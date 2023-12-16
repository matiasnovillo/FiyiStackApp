using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Models.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiyiStackApp
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();

            //Set positions for panels and set the form size. This is used to move the panels to any place in the design layout
            Size = new Size(900, 580);
            PanelDatabaseConfiguration.Location = new Point(250, 21);
            PanelPathFilesConfiguration.Location = new Point(250, 21);

            //Load Configuration inside WinForm
            chbclonedConfigurationAddAuditingFieldsToNewTable.Checked = Program.WinFormConfigurationComponent.Configuration.AddAuditingFieldsToNewTable;
            chbclonedConfigurationDeleteTable.Checked = Program.WinFormConfigurationComponent.Configuration.DeleteTable;
            chbclonedConfigurationDeleteField.Checked = Program.WinFormConfigurationComponent.Configuration.DeleteField;
            chbclonedConfigurationDeleteStoredProcedure.Checked = Program.WinFormConfigurationComponent.Configuration.DeleteStoredProcedure;
            chbclonedConfigurationDeleteFiles.Checked = Program.WinFormConfigurationComponent.Configuration.DeleteFiles;

            //Back-end
            if (Program.WinFormConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer.Trim() != "")
            {
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# Models with SPs"));
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# Services"));
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# Interfaces"));
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# .NET Core Web APIs"));
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# Filters"));
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# .NET Core Razor Pages"));
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("C# DTOs"));
                ListViewBackEndFilesGenerators.Items[0].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpModelsWithSPs;
                ListViewBackEndFilesGenerators.Items[1].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpServices;
                ListViewBackEndFilesGenerators.Items[2].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpInterfaces;
                ListViewBackEndFilesGenerators.Items[3].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpWebAPIs;
                ListViewBackEndFilesGenerators.Items[4].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpFilters;
                ListViewBackEndFilesGenerators.Items[5].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpRazorPages;
                ListViewBackEndFilesGenerators.Items[6].Checked = Program.WinFormConfigurationComponent.Configuration.WantCSharpDTOs;
            }
            else if (Program.WinFormConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture.Trim() != "")
            {
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Backend API"));
                ListViewBackEndFilesGenerators.Items[0].Checked = Program.WinFormConfigurationComponent.Configuration.WantBackendAPI;
            }
            else if(Program.WinFormConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB.Trim() != "")
            {
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Backend API"));
                ListViewBackEndFilesGenerators.Items[0].Checked = Program.WinFormConfigurationComponent.Configuration.WantBackendAPINodeJsExpressMongoDB;
            }
            else
            {
                ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Backend API"));
                ListViewBackEndFilesGenerators.Items[0].Checked = Program.WinFormConfigurationComponent.Configuration.WantNET8MSSQLServerAPI;
            }

            //Front-end
            if (Program.WinFormConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer.Trim() != "")
            {
                ListViewFrontEndFilesGenerators.Items.Add(new ListViewItem("TypeScript Models"));
                ListViewFrontEndFilesGenerators.Items.Add(new ListViewItem("jQuery"));
                ListViewFrontEndFilesGenerators.Items.Add(new ListViewItem("TypeScript DTOs"));
                ListViewFrontEndFilesGenerators.Items[0].Checked = Program.WinFormConfigurationComponent.Configuration.WantTypeScriptModels;
                ListViewFrontEndFilesGenerators.Items[1].Checked = Program.WinFormConfigurationComponent.Configuration.WantjQueryDOMManipulator;
                ListViewFrontEndFilesGenerators.Items[2].Checked = Program.WinFormConfigurationComponent.Configuration.WantTypeScriptDTOs;
            }
            else
            {

            }

            //Hide elements except
            HideAllPanelsExcept(new Panel[] { PanelDatabaseConfiguration });
            HideAllPicturesExcept(new PictureBox[] { picStep1Databases });

            ToolStatusLabel.Text = "Ready.";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Reset timer
                Program.WinFormConfigurationComponent.timer.Stop();
                Program.WinFormConfigurationComponent.timer.Start();

                //TODO Send email about kind of information in UserConfiguration...PropertiesConfiguration

                if (Program.WinFormConfigurationComponent.ProjectChosen.ProjectId == 0) { throw new Exception("Project not selected"); }
                else
                {
                    Configuration Configuration = new Configuration().GetOneByProjectIdToModel(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId);

                    Configuration.AddAuditingFieldsToNewTable = chbclonedConfigurationAddAuditingFieldsToNewTable.Checked;
                    Configuration.DeleteTable = chbclonedConfigurationDeleteTable.Checked;
                    Configuration.DeleteField = chbclonedConfigurationDeleteField.Checked;
                    Configuration.DeleteStoredProcedure = chbclonedConfigurationDeleteStoredProcedure.Checked;
                    Configuration.DeleteFiles = chbclonedConfigurationDeleteFiles.Checked;

                    //Back-end
                    if (Program.WinFormConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer.Trim() != "")
                    {
                        Configuration.WantCSharpModelsWithSPs = ListViewBackEndFilesGenerators.Items[0].Checked;
                        Configuration.WantCSharpServices = ListViewBackEndFilesGenerators.Items[1].Checked;
                        Configuration.WantCSharpInterfaces = ListViewBackEndFilesGenerators.Items[2].Checked;
                        Configuration.WantCSharpWebAPIs = ListViewBackEndFilesGenerators.Items[3].Checked;
                        Configuration.WantCSharpFilters = ListViewBackEndFilesGenerators.Items[4].Checked;
                        Configuration.WantCSharpRazorPages = ListViewBackEndFilesGenerators.Items[5].Checked;
                        Configuration.WantCSharpDTOs = ListViewBackEndFilesGenerators.Items[6].Checked;
                    }
                    else if(Program.WinFormConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture.Trim() != "")
                    {
                        Configuration.WantBackendAPI = ListViewBackEndFilesGenerators.Items[0].Checked;
                    }
                    else if(Program.WinFormConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB.Trim() != "")
                    {
                        Configuration.WantBackendAPINodeJsExpressMongoDB = ListViewBackEndFilesGenerators.Items[0].Checked;
                    }
                    else
                    {
                        Configuration.WantNET8MSSQLServerAPI = ListViewBackEndFilesGenerators.Items[0].Checked;
                    }



                    //Front-end
                    if (Program.WinFormConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer.Trim() != "")
                    {
                        Configuration.WantTypeScriptModels = ListViewFrontEndFilesGenerators.Items[0].Checked;
                        Configuration.WantjQueryDOMManipulator = ListViewFrontEndFilesGenerators.Items[1].Checked;
                        Configuration.WantTypeScriptDTOs = ListViewFrontEndFilesGenerators.Items[2].Checked;
                    }

                    if (Configuration.ConfigurationId != 0) //Edit
                    {
                        Configuration.DateTimeLastModification = DateTime.Now;
                        Configuration.UserLastModificationId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                        Configuration.UpdateByConfigurationId();
                    }
                    else //Add
                    {
                        Configuration.DateTimeCreation = DateTime.Now;
                        Configuration.DateTimeLastModification = DateTime.Now;
                        Configuration.UserCreationId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                        Configuration.UserLastModificationId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                        Configuration.Add();
                    }
                }

                Program.WinFormConfigurationComponent.LoadConfiguration();
                this.Close();
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        #region Secondary configuration. Painting mostly
        private void labelDataBase_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(new Panel[]{ PanelDatabaseConfiguration });
            HideAllPicturesExcept(new PictureBox[]{ picStep1Databases });
        }

        private void labelBackEnd_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(new Panel[] { PanelPathFilesConfiguration });
            HideAllPicturesExcept(new PictureBox[] { picStep2PathFiles });
        }

        private void cmbLevelConfiguration_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void cmbFontTitleStyle_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void cmbParagraphStyle_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void cmbTemplate_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void txtColourDefault_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtColourSuccess_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtColourPrimary_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtColourWarning_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtColourInfo_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtColourDanger_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }
        
        private void txtFontTitleSize_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void txtFontParagraphSize_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void btnSave_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void txtclonedConfigurationConnectionStringForMSSQLServer_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtclonedConfigurationConnectionStringForPostgreSQL_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtclonedConfigurationConnectionStringForPLSQL_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtclonedConfigurationConnectionStringForSQLite_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtclonedConfigurationConnectionStringForMongoDB_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtclonedConfigurationConnectionStringForMySQL_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ConfigurationForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Reset timer
            Program.WinFormConfigurationComponent.timer.Stop();
            Program.WinFormConfigurationComponent.timer.Start();
        }

        private void HideAllPanelsExcept(Panel[] PanelsToAvoid = null)
        {
            PanelDatabaseConfiguration.Visible = false;
            PanelPathFilesConfiguration.Visible = false;

            if (PanelsToAvoid != null)
            {
                foreach (Panel PanelToAvoid in PanelsToAvoid)
                {
                    PanelToAvoid.Visible = true;
                }
            }
        }

        private void HideAllPicturesExcept(PictureBox[] PicturesToAvoid = null)
        {
            picStep1Databases.Visible = false;
            picStep2PathFiles.Visible = false;

            if (PicturesToAvoid != null)
            {
                foreach (PictureBox PictureToAvoid in PicturesToAvoid)
                {
                    PictureToAvoid.Visible = true;
                }
            }
        }

        private void StatusStrip_Click(object sender, EventArgs e)
        {
            Program.WinFormConfigurationComponent.SetClipBoard(ToolStatusLabel.Text + "\n");
        }

        private void cmbclonedConfigurationTemplateId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListViewGenerators_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewProjectType_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnNewFiles_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }
        #endregion
    }
}
