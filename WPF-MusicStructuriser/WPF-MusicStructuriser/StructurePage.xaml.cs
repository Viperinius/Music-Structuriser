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
    /// Interaktionslogik für StructurePage.xaml
    /// </summary>
    public partial class StructurePage : UserControl
    {
        CSettings settings = new CSettings();
        MainWindow mainWindow;


        public StructurePage(CSettings _settings, MainWindow _mainWindow)
        {
            InitializeComponent();

            settings = _settings;
            mainWindow = _mainWindow;
        }

        private void ChkArtist_Checked(object sender, RoutedEventArgs e)
        {
            settings.bSortArtists = true;
            settings.SetSort();
        }

        private void ChkAlbum_Checked(object sender, RoutedEventArgs e)
        {
            settings.bSortAlbums = true;
            settings.SetSort();
        }

        private void ChkName_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChkArtist_Unchecked(object sender, RoutedEventArgs e)
        {
            settings.bSortArtists = false;
            settings.SetSort();
        }

        private void ChkAlbum_Unchecked(object sender, RoutedEventArgs e)
        {
            settings.bSortAlbums = false;
            settings.SetSort();
        }

        private void ChkName_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            settings.UpdateSort();
            if (settings.bSortAlbums)
            {
                chkAlbum.IsChecked = true;
            }

            if (settings.bSortArtists)
            {
                chkArtist.IsChecked = true;
            }

            
        }

        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MoveFiles();
        }
    }
}
