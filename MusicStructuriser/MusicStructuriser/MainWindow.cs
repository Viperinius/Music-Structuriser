using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace MusicStructuriser
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sPath = @"X:\Alexander\Videos\01 - Enough.mp3";

            TagLib.File tagFile = TagLib.File.Create(sPath);

            txtYear.Text = tagFile.Tag.Year.ToString();
            txtAlbumArtist.Text = tagFile.Tag.FirstAlbumArtist;
            txtTitle.Text = tagFile.Tag.Title;
            txtAlbum.Text = tagFile.Tag.Album;
            txtArtist.Text = tagFile.Tag.FirstPerformer;
            txtComposer.Text = tagFile.Tag.FirstComposer;
            txtDiscNum.Text = tagFile.Tag.DiscCount.ToString();
            txtGenre.Text = tagFile.Tag.Genres[0];
            txtTrack.Text = tagFile.Tag.Track.ToString();
        }
    }
}
