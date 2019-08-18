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
using System.Reflection;

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
        COrganiser organiser;

        private MetaDataPage metaDataPage;
        private StructurePage structurePage;
        private FolderPage folderPage;
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

            metaDataPage = new MetaDataPage(this);
            structurePage = new StructurePage(settings, this);
            folderPage = new FolderPage(settings, this);

            tabStruct.Content = structurePage;
            tabMeta.Content = metaDataPage;
            tabPath.Content = folderPage;

            organiser = new COrganiser(settings);

            settings.sRootSourceDir = settings.GetRootSourceDir();
            settings.sRootDestDir = settings.GetRootDestDir();

            //testing
            //settings.SetRootSourceDir(@"X:\Alexander\Videos\Rock CD");
            //settings.SetRootDestDir(@"X:\Alexander\Videos\RockCD");

            PopulateTreeView();
            LoadAllFilesTags();


            //organiser.MoveToFolders(lFiles);
        }

        public void LoadAllFilesTags()
        {
            foreach (FileInfo file in lFiles)
            {
                lFileTags.Add(organiser.LoadFileTags(file.FullName));
            }
        }

        public void PopulateTreeView()
        {
            if (settings.sRootSourceDir == null || settings.sRootSourceDir == "")
            {
                return;
            }
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
                TagLib.File tagFile = TagLib.File.Create(file.FullName);
                bool hasTitleTag = true;
                if (tagFile.Tag.Title is null)
                {
                    hasTitleTag = false;
                }

                var item = new FileItem()
                {
                    Title = file.Name,
                    Path = file.FullName,
                    HasTags = hasTitleTag
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
                CMetaData metaData = organiser.LoadFileTags(file.Path);
                metaDataPage.ShowTags(metaData);
            }

        }

        public void MoveFiles()
        {
            organiser.MoveToFolders(lFiles);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (object item in treeView.Items)
            {
                TreeViewItem treeItem = treeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (treeItem.DataContext.GetType() == typeof(FileItem))
                {
                    FileItem fileItem = (FileItem)treeItem.DataContext;
                    if (!fileItem.HasTags)
                    {
                        treeItem.Background = Brushes.Red;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }


    public class TreeItem
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public bool HasTags { get; set; }
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
