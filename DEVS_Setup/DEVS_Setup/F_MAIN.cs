using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using DEVS_Setup.Properties;

namespace DEVS_Setup
{
    public partial class F_MAIN : Form
    {
        Global m_global = new Global();

        static int fileNumber = 0;
        static int directoryNumber = 0;

        string INISaveFilepath = Application.StartupPath + @"\DEVSinfo.ini";

        string MainPath = "";
        string FirstSelect = "";
        string SecondSelect = "";
        string ThirdSelect = "";

        string firstFileName = ""; //파일명만 o 경로명 x
        string secondFileName = ""; //파일명만 o 경로명 x

        public F_MAIN()
        {
            InitializeComponent();
        }

        private void F_MAIN_Load(object sender, EventArgs e)
        {
            string textinput1 = ""; // 현재 textbox에서 사용하는 경로
            string textinput2 = ""; // 현재 textbox에서 사용하는 경로
            string textinput3 = ""; // 현재 textbox에서 사용하는 경로

            m_global.CreateSubKey();
            m_global.CreateSubKey("FileName");

            m_global.GetValue("FirstSelect", out textinput1);
            m_global.GetValue("SecondSelect", out textinput2);
            m_global.GetValue("ThirdSelect", out textinput3);

            m_global.GetValue("FirstFile", out firstFileName, "FileName");
            m_global.GetValue("SecondFile", out secondFileName, "FileName");

            m_global.SetValue("MainPath", @"C:\DEVS_ObjectC"); //절대경로 (가끔 바뀜)
            m_global.SetValue("SESEditorPath", @"C:\DEVS_ObjectC\DEVS_DD.exe"); //절대경로 (가끔 바뀜)
            m_global.SetValue("DEVSObjectPath", @"C:\DEVS_ObjectC\framework"); //절대경로 (가끔 바뀜)
            m_global.SetValue("DEVSDiagramDisplayPath", @"C:\DEVS_ObjectC\SES_Editor.exe"); //절대경로 (가끔 바뀜)

            m_global.GetValue("MainPath", out this.MainPath);
            m_global.GetValue("SESEditorPath", out this.FirstSelect);
            m_global.GetValue("DEVSObjectPath", out this.SecondSelect);
            m_global.GetValue("DEVSDiagramDisplayPath", out this.ThirdSelect);

            textBox1.Text = textinput1;
            textBox2.Text = textinput2;
            textBox3.Text = textinput3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "";
            ofd.DefaultExt = "exe";
            ofd.Filter = "exe Files (*.exe)|*.exe";

            if (DialogResult.OK == ofd.ShowDialog())
            {
                textBox1.Text = ofd.FileName;
                firstFileName = ofd.SafeFileName;
                m_global.SetValue("FirstSelect", textBox1.Text);
                m_global.SetValue("FirstFile", firstFileName, "FileName");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (DialogResult.OK == fbd.ShowDialog())
            {
                textBox2.Text = fbd.SelectedPath;
                m_global.SetValue("SecondSelect", textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.FileName = "";
            ofd.DefaultExt = "exe";
            ofd.Filter = "exe Files (*.exe)|*.exe";

            if (DialogResult.OK == ofd.ShowDialog())
            {
                textBox3.Text = ofd.FileName;
                secondFileName = ofd.SafeFileName;
                m_global.SetValue("ThirdSelect", textBox3.Text);
                m_global.SetValue("SecondFile", secondFileName, "FileName");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "현재 상태";

            DirectoryInfo destDirectory;
            try
            {
                if (textBox1.Text != "")
                {
                    destDirectory = new DirectoryInfo(MainPath);

                    if (!destDirectory.Exists)
                    {
                        destDirectory.Create();
                    }

                    foreach (Process proc in Process.GetProcesses())
                    {
                        if (proc.ProcessName.StartsWith(firstFileName))
                        {
                            proc.Kill();
                        }
                    }

                    File.Copy(textBox1.Text, FirstSelect, true);

                    fileNumber++;
                }

                if (textBox3.Text != "")
                {
                    destDirectory = new DirectoryInfo(MainPath);

                    if (!destDirectory.Exists)
                    {
                        destDirectory.Create();
                    }

                    foreach (Process proc in Process.GetProcesses())
                    {
                        if (proc.ProcessName.StartsWith(secondFileName))
                        {
                            proc.Kill();
                        }
                    }

                    File.Copy(textBox3.Text, ThirdSelect, true);

                    fileNumber++;
                }

                if (textBox2.Text != "")
                {
                    DirectoryInfo sourceDirectory = new DirectoryInfo(textBox2.Text);
                    destDirectory = new DirectoryInfo(SecondSelect);

                    if (!destDirectory.Exists)
                    {
                        destDirectory.Create();
                    }

                    CopyDirectories(sourceDirectory, destDirectory);
                }

                toolStripStatusLabel1.Text = string.Format("복사 완료, 총 {0}개의 디렉토리와 {1}개의 파일을 복사함", directoryNumber, fileNumber);

                fileNumber = 0;
                directoryNumber = 0;
            }
            catch(IOException ie)
            {
            }
            catch
            {
            }
        }

        #region 폴더 복사
        private void CopyDirectories(DirectoryInfo sourceDirectory, DirectoryInfo destDirectory)
        {
            FileInfo[] sourceFiles = sourceDirectory.GetFiles();

            foreach (FileInfo file in sourceFiles)
            {
                file.CopyTo(destDirectory.FullName + "\\" + file.Name, true);
                fileNumber++;
            }

            DirectoryInfo[] sourceSubDirectories = sourceDirectory.GetDirectories();

            foreach (DirectoryInfo subDirectory in sourceSubDirectories)
            {
                DirectoryInfo destSubDirectory = destDirectory.CreateSubdirectory(subDirectory.Name);

                CopyDirectories(subDirectory, destSubDirectory);
                directoryNumber++;
            }

        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m_global.SetValue("FirstSelect", textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            m_global.SetValue("SecondSelect", textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            m_global.SetValue("ThirdSelect", textBox3.Text);
        }
    }
}
