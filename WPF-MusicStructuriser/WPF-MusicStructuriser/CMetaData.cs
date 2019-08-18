using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPF_MusicStructuriser
{
    public class CMetaData
    {
        public string sTitle;
        public string sAlbum;
        public string sTrack;
        public string sYear;
        public string[] sArtists;
        public string[] sAlbumArtists;
        public string[] sComposers;
        public BitmapImage image;
        public string[] sGenres;
        public uint uiDiscNo;

        public CMetaData()
        {
        }
    }
}
