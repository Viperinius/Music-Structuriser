using System;
using System.Collections.Generic;
using System.IO;
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
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using TagLib;
using System.Globalization;

namespace WPF_MusicStructuriser
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        List<FileInfo> lFiles = new List<FileInfo>();
        List<CMetaData> lFileTags = new List<CMetaData>();
        List<string> lAudioDataEnding = new List<string>();

        CSettings settings = new CSettings();

        private MetaDataPage metaDataPage;
        private StructurePage structurePage;
        private object dummyNode = null;

        public MainWindow()
        {
            InitializeComponent();

            //populate list with possible audio suffixes
            lAudioDataEnding.Add(".mp3");
            lAudioDataEnding.Add(".wav");
            lAudioDataEnding.Add(".wma");
            lAudioDataEnding.Add(".flac");
            lAudioDataEnding.Add(".aac");
            lAudioDataEnding.Add(".m4a");
            lAudioDataEnding.Add(".m4b");
            lAudioDataEnding.Add(".ogg");

            metaDataPage = new MetaDataPage();
            structurePage = new StructurePage();

            tabStruct.Content = structurePage;
            tabMeta.Content = metaDataPage;



            //testing
            settings.sRootSourceDir = @"X:\Alexander\Videos\Rock CD";

            PopulateTreeView();
            LoadAllFilesTags();

        }

        public void LoadAllFilesTags()
        {
            foreach (FileInfo file in lFiles)
            {
                lFileTags.Add(metaDataPage.LoadFileTags(file.FullName));
            }
        }

        private void PopulateTreeView()
        {
            var items = GetTreeItems(settings.sRootSourceDir);
            treeView.DataContext = items;
        }


        private ObservableCollection<TreeItem> GetTreeItems(string sPath)
        {
            var items = new ObservableCollection<TreeItem>();
            DirectoryInfo dirInfo = new DirectoryInfo(sPath);

            foreach (DirectoryInfo directory in dirInfo.GetDirectories())
            {
                var item = new DirectoryItem()
                {
                    Title = directory.Name,
                    Path = directory.FullName,
                    Items = GetTreeItems(directory.FullName)
                };

                items.Add(item);
            }

            foreach (FileInfo file in dirInfo.GetFiles().Where(n => lAudioDataEnding.Contains(System.IO.Path.GetExtension(n.FullName), StringComparer.OrdinalIgnoreCase)))
            {
                var item = new FileItem()
                {
                    Title = file.Name,
                    Path = file.FullName
                };

                items.Add(item);
                lFiles.Add(file);
            }

            return items;
        }

        private void TreeView_Folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    TreeViewItem subItem = new TreeViewItem
                    {
                        Header = "sub",
                        Tag = "sub",
                        FontWeight = FontWeights.Normal
                    };
                    subItem.Items.Add(dummyNode);
                    subItem.Expanded += new RoutedEventHandler(TreeView_Folder_Expanded);
                    item.Items.Add(subItem);
                }
                catch (Exception)
                {

                }
            }
        }

        private void BtnStyle_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (treeView.SelectedItem is FileItem file)
            {
                CMetaData metaData = metaDataPage.LoadFileTags(file.Path);
            }

        }
    }


    public class TreeItem
    {
        public string Title { get; set; }

        public string Path { get; set; }
    }

    public class FileItem : TreeItem
    {        
    }

    public class DirectoryItem : TreeItem
    {
        public ObservableCollection<TreeItem> Items { get; set; }

        public DirectoryItem()
        {
            Items = new ObservableCollection<TreeItem>();
        }
    }
}
