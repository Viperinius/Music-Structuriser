using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MusicStructuriser
{
    /// <summary>
    /// Interaktionslogik für FolderPage.xaml
    /// </summary>
    public partial class FolderPage : UserControl
    {
        public string sSourcePath = "";
        public string sDestPath = "";

        CSettings settings = new CSettings();
        MainWindow mainWindow;// = new MainWindow();

        public FolderPage(CSettings _settings, MainWindow window)
        {
            InitializeComponent();
            settings = _settings;
            mainWindow = window;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtDest.Text == "" || txtDest.Text == "INSERT DESTINATION LINK")
            {
                txtDest.Text = "INSERT DESTINATION LINK";
                return;
            }
            if (txtSource.Text == "" || txtSource.Text == "INSERT SOURCE LINK")
            {
                txtSource.Text = "INSERT SOURCE LINK";
                return;
            }

            sSourcePath = txtSource.Text;
            sDestPath = txtDest.Text;

            settings.SetRootSourceDir(sSourcePath);
            settings.SetRootDestDir(sDestPath);

            mainWindow.PopulateTreeView();
            mainWindow.LoadAllFilesTags();
        }

        private void BtnChooseSource_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSource.Text = folderBrowserDialog.SelectedPath;
                    sSourcePath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void BtnChooseDest_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDest.Text = folderBrowserDialog.SelectedPath;
                    sDestPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void TxtSource_Loaded(object sender, RoutedEventArgs e)
        {
            txtSource.Text = settings.sRootSourceDir;
        }

        private void TxtDest_Loaded(object sender, RoutedEventArgs e)
        {
            txtDest.Text = settings.sRootDestDir;
        }
    }
}
