using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TagLib;

namespace MusicStructuriser
{
    public partial class MainWindow : Form
    {
        List<string> lFiles = new List<string>();
        List<CMetaData> lFileTags = new List<CMetaData>();
        List<string> lAudioDataEnding = new List<string>();

        CSettings settings = new CSettings();

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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sPath = @"X:\Alexander\Videos\Rock CD\test\01 - Enough.mp3";

            TagLib.File tagFile = TagLib.File.Create(sPath);

            settings.sRootSourceDir = @"X:\Alexander\Videos\Rock CD";

            SearchDirectories(@"X:\Alexander\Videos\Rock CD");
            LoadAllFilesTags();

            PopulateTreeView();
            //CreateDirectories(@"X:\Test");
        }

        private void ChkArtist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArtist.Checked)
            {
                settings.bSortArtists = true;
            }
            else
            {
                settings.bSortArtists = false;
            }
        }

        private void ChkAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlbum.Checked)
            {
                settings.bSortAlbums = true;
            }
            else
            {
                settings.bSortAlbums = false;
            }
        }

        private void ChkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                settings.bChangeName = true;
            }
            else
            {
                settings.bChangeName = false;
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sRootParentDir = Directory.GetParent(settings.sRootSourceDir).FullName;
            string sPath = sRootParentDir + Path.DirectorySeparatorChar + treeView1.SelectedNode.FullPath;

            foreach (string sSuffix in lAudioDataEnding)
            {
                if (sPath.EndsWith(sSuffix))
                {
                    CMetaData metaData = LoadFileTags(sPath);
                }
            }

        }

        private void PicCover_Click(object sender, EventArgs e)
        {
            openPicDialog.Title = "Open image";
            openPicDialog.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            if (openPicDialog.ShowDialog() == DialogResult.OK)
            {
                picCover.Image = new Bitmap(openPicDialog.FileName);
            }
        }

        private void PicCover_MouseEnter(object sender, EventArgs e)
        {
            picCover.BackgroundImageLayout = ImageLayout.Zoom;
            picCover.BackgroundImage = picCover.Image;
            picCover.Image = picOverlay.Image;
        }

        private void PicCover_MouseLeave(object sender, EventArgs e)
        {
            picCover.Image = picCover.BackgroundImage;
            picCover.BackgroundImage = null;
        }

        public string CombineArray(string[] sArray)
        {
            string sTmpResult = "";
            if (sArray.Length > 1)
            {
                for (int i = 0; i < sArray.Length - 1; i++)
                {
                    sTmpResult += sArray[i] + ", ";
                }
                sTmpResult += sArray[sArray.Length - 1];
            }
            else if (sArray.Length == 1)
            {
                sTmpResult = sArray[0];
            }
            return sTmpResult;
        }

        public string[] SeparateToArray(string sSourceString)
        {
            List<string> lTmpResult = new List<string>();

            if (sSourceString.Contains(", "))
            {
                lTmpResult = sSourceString.Split(',').ToList();
                foreach (string sItem in lTmpResult)
                {
                    sItem.Trim();
                }
            }
            return lTmpResult.ToArray();
        }

        public void MoveFiles(string sSource, string sDest)
        {
            //create destination directories
            bool bDirectoryResult = CreateDirectories(sDest);

            //move files

        }

        public void PopulateTreeView()
        {
            List<string> lPaths = new List<string>();

            foreach (string sFile in lFiles)
            {
                lPaths.Add(sFile.Replace(settings.sRootSourceDir + Path.DirectorySeparatorChar, ""));
            }

            TreeNode newNode = PathsToRootNode(lPaths, settings.sRootSourceDir, Path.DirectorySeparatorChar);
            if (newNode != null)
            {
                treeView1.Nodes.Add(newNode);
            }
        }

        public TreeNode PathsToRootNode(List<string> lPaths, string sRootPath, char separator)
        {
            var rootSplit = sRootPath.Split(separator);

            try
            {
                string sTopNodeName = treeView1.TopNode.Text;
                if (treeView1.TopNode.Text == rootSplit[rootSplit.Length - 1])
                {
                    return null;
                }
            }
            catch (NullReferenceException)
            {
            }

            TreeNode rootNode = new TreeNode(rootSplit[rootSplit.Length - 1]);
            foreach (string file in lPaths.Where(x => !string.IsNullOrEmpty(x.Trim())))
            {
                TreeNode currentNode = rootNode;
                string[] pathItems = file.Split(separator);

                foreach (string sItem in pathItems)
                {
                    var tmp = currentNode.Nodes.Cast<TreeNode>().Where(x => x.Text.Equals(sItem));
                    currentNode = tmp.Count() > 0 ? tmp.Single() : currentNode.Nodes.Add(sItem);
                }
            }
            return rootNode;
        }

        public void LoadAllFilesTags()
        {
            foreach (string sFile in lFiles)
            {
                lFileTags.Add(LoadFileTags(sFile));
            }
        }

        public CMetaData LoadFileTags(string sFile)
        {
            CMetaData metaTags = new CMetaData();
            using (TagLib.File tagFile = TagLib.File.Create(sFile))
            {
                GetTags(tagFile, ref metaTags);
                ShowTags(metaTags);
            }
            return metaTags;
        }

        public void GetTags(TagLib.File tagFile, ref CMetaData metaTags)
        {
            metaTags.sTitle = tagFile.Tag.Title;
            metaTags.sAlbum = tagFile.Tag.Album;
            metaTags.sTrack = tagFile.Tag.Track.ToString();
            metaTags.sYear = tagFile.Tag.Year.ToString();
            metaTags.sArtists = tagFile.Tag.Performers;
            metaTags.sAlbumArtists = tagFile.Tag.AlbumArtists;
            metaTags.sComposers = tagFile.Tag.Composers;

            try
            {
                MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                metaTags.image = Image.FromStream(ms);
            }
            catch (IndexOutOfRangeException)
            {
                metaTags.image = new Bitmap(800, 800);
            }

            metaTags.sGenres = tagFile.Tag.Genres;
        }

        public void ShowTags(CMetaData metaTags)
        {
            txtTitle.Text = metaTags.sTitle;
            txtAlbum.Text = metaTags.sAlbum;
            txtTrack.Text = metaTags.sTrack;
            txtYear.Text = metaTags.sYear;
            txtArtists.Text = CombineArray(metaTags.sArtists);
            txtAlbumArtists.Text = CombineArray(metaTags.sAlbumArtists);
            txtComposers.Text = CombineArray(metaTags.sComposers);
            picCover.Image = metaTags.image;
            txtGenre.Text = CombineArray(metaTags.sGenres);
        }
        
        public void EditTags(ref TagLib.File tagFile)
        {
            tagFile.Tag.Title = txtTitle.Text;
            tagFile.Tag.Album = txtAlbum.Text;
            tagFile.Tag.Track = Convert.ToUInt32(txtTrack.Text);
            tagFile.Tag.Year = Convert.ToUInt32(txtYear.Text);
            tagFile.Tag.Performers = SeparateToArray(txtArtists.Text);
            tagFile.Tag.AlbumArtists = SeparateToArray(txtAlbumArtists.Text);
            tagFile.Tag.Composers = SeparateToArray(txtComposers.Text);
            //pic
            tagFile.Tag.Genres = SeparateToArray(txtGenre.Text);

            tagFile.Save();
        }

        public void SearchDirectories(string sRootDir)
        {
            try
            {
                //search for files
                foreach (string sFile in Directory.GetFiles(sRootDir))
                {
                    foreach (string sSuffix in lAudioDataEnding)
                    {
                        if (sFile.EndsWith(sSuffix))
                        {
                            lFiles.Add(sFile);
                            break;
                        }
                    }
                }

                //search for subdirectories
                foreach (string sSubDir in Directory.GetDirectories(sRootDir))
                {
                    //maybe do sth like saving in a folder list?

                    //recursive call to search the sub directory
                    SearchDirectories(sSubDir);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while searching the directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CreateDirectories(string sDest)
        {
            bool bSuccess = true;
            foreach (CMetaData metaTags in lFileTags)
            {
                if (settings.bSortArtists)
                {
                    if (metaTags.sArtists[0] != "")
                    {
                        try
                        {
                            Directory.CreateDirectory(sDest + @"\" + metaTags.sArtists[0]);
                        }
                        catch (NotSupportedException)
                        {
                            MessageBox.Show(String.Format("Error when creating artist ({0}) folder. Maybe contains non allowed characters?", metaTags.sArtists[0]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bSuccess = false;
                        }
                    }
                }

                if (settings.bSortAlbums && settings.bSortArtists)
                {
                    if (metaTags.sAlbum != "")
                    {
                        try
                        {
                            Directory.CreateDirectory(sDest + @"\" + metaTags.sArtists[0] + @"\" + metaTags.sAlbum);
                        }
                        catch (NotSupportedException)
                        {
                            MessageBox.Show(String.Format("Error when creating album ({0}) folder. Maybe contains non allowed characters?", metaTags.sAlbum), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bSuccess = false;
                        }
                    }
                }
                else if (settings.bSortAlbums)
                {
                    if (metaTags.sAlbum != "")
                    {
                        try
                        {
                            Directory.CreateDirectory(sDest + @"\" + metaTags.sAlbum);
                        }
                        catch (NotSupportedException)
                        {
                            MessageBox.Show(String.Format("Error when creating album ({0}) folder. Maybe contains non allowed characters?", metaTags.sAlbum), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bSuccess = false;
                        }
                    }
                }
            }
            return bSuccess;
        }

        public void MoveFile(string sSource, string sDest)
        {
            System.IO.File.Move(sSource, sDest);
        }

        public void MoveDirectory(string sSource, string sDest)
        {
            Directory.Move(sSource, sDest);
        }

        public void RenameFile(string sPath, string sOldName, string sNewName)
        {
            System.IO.File.Replace(sPath + sOldName, sPath + sNewName, "");       //check if correct
        }

        public string GetRenamedFile(string sPathEndingWithSeparator, string sOldName, ref CMetaData metaTags)
        {
            string sTmpPath = "";
            if (settings.bChangeName)
            {
                sTmpPath = sPathEndingWithSeparator;
                if (settings.bChangeToTrack)
                {
                    sTmpPath += (settings.bChangeToTitle || settings.bChangeToArtist) ? metaTags.sTrack + " - " : metaTags.sTrack;
                }
                if (settings.bChangeToArtist)
                {
                    try
                    {
                        sTmpPath += settings.bChangeToTitle ? metaTags.sArtists[0] + " - " : metaTags.sArtists[0];
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(String.Format("Error renaming file {0}, no artist meta data?", sOldName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (settings.bChangeToTitle)
                {
                    sTmpPath += metaTags.sTitle;
                }
            }
            else
            {
                sTmpPath = sPathEndingWithSeparator + sOldName;
            }
            return sTmpPath;
        }
    }
}
