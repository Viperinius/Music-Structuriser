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

namespace WPF_MusicStructuriser
{
    /// <summary>
    /// Interaktionslogik für MetaDataPage.xaml
    /// </summary>
    public partial class MetaDataPage : UserControl
    {
        public MetaDataPage()
        {
            InitializeComponent();
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
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.EndInit();

                metaTags.image = bitmap;
            }
            catch (IndexOutOfRangeException)
            {
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
            picCover.Source = metaTags.image;
            txtGenre.Text = CombineArray(metaTags.sGenres);
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
    }
}
