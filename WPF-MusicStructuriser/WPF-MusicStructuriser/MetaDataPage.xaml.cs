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
        MainWindow mainWindow;

        public MetaDataPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
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

        private string CombineArray(string[] sArray)
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
