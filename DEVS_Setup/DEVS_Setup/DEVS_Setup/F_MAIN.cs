using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DEVS_Setup.Properties;

namespace DEVS_Setup
{
    public partial class F_MAIN : Form
    {
        static int fileNumber = 0;
        static int directoryNumber = 0;

        string INISaveFilepath = Application.StartupPath + @"\DEVSinfo.ini";

        public F_MAIN()
        {
            InitializeComponent();
        }

        private void F_MAIN_Load(object sender, EventArgs e)
        {
            FileStream fs;
            StreamWriter sw;

            try
            {
                using (fs = new FileStream(INISaveFilepath, FileMode.OpenOrCreate))
                {
                    using (sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("");
                    }
                }
            }
            catch
            {
                
            }                                                                           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs;
            StreamReader sr;

            try
            {
                using (fs = new FileStream(INISaveFilepath, FileMode.Open))
                {
                    using (sr = new StreamReader(fs))
                    {

                    }
                }

                OpenFileDialog ofd = new OpenFileDialog();

                ofd.FileName = "";
                ofd.DefaultExt = "exe";
                ofd.Filter = "exe Files (*.exe)|*.exe";

                if (DialogResult.OK == ofd.ShowDialog())
                {
                    textBox1.Text = ofd.FileName;
                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (DialogResult.OK == fbd.ShowDialog())
            {
                textBox2.Text = fbd.SelectedPath;
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
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string MainPath = Settings.Default["MainPath"].ToString();

            string firstPath = Settings.Default["SESEditorPath"].ToString();
            string secondPath = Settings.Default["DEVSObjectPath"].ToString();
            string thirdPath = Settings.Default["DEVSDiagramDisplayPath"].ToString();

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
                    File.Copy(textBox1.Text, firstPath);

                    fileNumber++;
                }

                if (textBox3.Text != "")
                {
                    destDirectory = new DirectoryInfo(MainPath);

                    if (!destDirectory.Exists)
                    {
                        destDirectory.Create();
                    }

                    File.Copy(textBox3.Text, thirdPath);

                    fileNumber++;
                }

                if (textBox2.Text != "")
                {
                    DirectoryInfo sourceDirectory = new DirectoryInfo(textBox2.Text);
                    destDirectory = new DirectoryInfo(secondPath);

                    if (!destDirectory.Exists)
                    {
                        destDirectory.Create();
                    }

                    CopyDirectories(sourceDirectory, destDirectory);
                }

                toolStripStatusLabel1.Text = string.Format("복사 완료, 총 {0}개의 디렉토리와 {1}개의 파일을 복사함", directoryNumber, fileNumber);
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
                file.CopyTo(destDirectory.FullName + "\\" + file.Name);
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
    }
}
