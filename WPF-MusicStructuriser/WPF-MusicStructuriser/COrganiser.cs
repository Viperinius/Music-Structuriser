using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace WPF_MusicStructuriser
{
    class COrganiser
    {
        CSettings settings = new CSettings();

        public COrganiser(CSettings _settings)
        {
            settings = _settings;
        }


        public void MoveToFolders(List<FileInfo> lFiles)
        {
            if (Directory.Exists(settings.sRootDestDir) && settings.sRootDestDir != "__NO_VAL__")
            {
                foreach (FileInfo file in lFiles)
                {
                    CMetaData metaData = LoadFileTags(file.FullName);
                    settings.UpdateSort();

                    string sPath = "";

                    try
                    {
                        if (settings.bSortArtists && settings.bSortAlbums && !settings.bSortGenre && !settings.bSortDisc)
                        {
                            //sort Artists and Albums
                            if (metaData.sAlbum != null)
                            {
                                if (metaData.sAlbum.Contains("/"))
                                {
                                    metaData.sAlbum = metaData.sAlbum.Replace("/", "_");
                                }

                                sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbumArtists[0], metaData.sAlbum);

                                
                            }
                            else
                            {
                                sPath = Path.Combine(settings.sRootDestDir, "Unknown Artist", "Unknown Album");
                            }
                        }
                        else if (settings.bSortArtists && !settings.bSortAlbums && !settings.bSortGenre && !settings.bSortDisc)
                        {
                            //sort only Artists
                            sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbumArtists[0]);
                        }
                        else if (settings.bSortArtists && !settings.bSortAlbums && !settings.bSortGenre && settings.bSortDisc)
                        {
                            //sort Artists and Disc
                            sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbumArtists[0], "Disc " + metaData.uiDiscNo.ToString());
                        }
                        else if (settings.bSortArtists && settings.bSortAlbums && !settings.bSortGenre && settings.bSortDisc)
                        {
                            //sort Artists, Album and Disc
                            if (metaData.sAlbum != null)
                            {
                                if (metaData.sAlbum.Contains("/"))
                                {
                                    metaData.sAlbum = metaData.sAlbum.Replace("/", "_");
                                }
                                sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbumArtists[0], metaData.sAlbum, "Disc " + metaData.uiDiscNo.ToString());
                            }
                            else
                            {
                                sPath = Path.Combine(settings.sRootDestDir, "Unknown Artist", "Unknown Album", "Unknown Disc");
                            }
                        }
                        else if (!settings.bSortArtists && settings.bSortAlbums && !settings.bSortGenre && settings.bSortDisc)
                        {
                            //sort Album and Disc
                            if (metaData.sAlbum != null)
                            {
                                if (metaData.sAlbum.Contains("/"))
                                {
                                    metaData.sAlbum = metaData.sAlbum.Replace("/", "_");
                                }
                                sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbum, "Disc " + metaData.uiDiscNo.ToString());
                            }
                            else
                            {
                                sPath = Path.Combine(settings.sRootDestDir, "Unknown Album", "Unknown Disc");
                            }
                        }
                        else if (!settings.bSortArtists && settings.bSortAlbums && !settings.bSortGenre && !settings.bSortDisc)
                        {
                            //sort Album
                            if (metaData.sAlbum != null)
                            {
                                if (metaData.sAlbum.Contains("/"))
                                {
                                    metaData.sAlbum = metaData.sAlbum.Replace("/", "_");
                                }
                                sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbum);
                            }
                            else
                            {
                                sPath = Path.Combine(settings.sRootDestDir, "Unknown Album");
                            }
                        }
                        else if (!settings.bSortArtists && !settings.bSortAlbums && !settings.bSortGenre && settings.bSortDisc)
                        {
                            //sort Disc
                            sPath = Path.Combine(settings.sRootDestDir, "Disc " + metaData.uiDiscNo.ToString());
                        }
                        else if (!settings.bSortArtists && !settings.bSortAlbums && settings.bSortGenre && !settings.bSortDisc)
                        {
                            //sort Genre
                            sPath = Path.Combine(settings.sRootDestDir, metaData.sGenres[0]);
                        }


                        Directory.CreateDirectory(sPath);
                        File.Copy(file.FullName, Path.Combine(sPath, file.Name), true);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.WriteLine(e.InnerException);
                    }

                    if (settings.bSortAlbums)
                    {
                        try
                        {
                            if (settings.bSortArtists && metaData.sAlbum != null)
                            {
                                if (metaData.sAlbum.Contains("/"))
                                {
                                    metaData.sAlbum = metaData.sAlbum.Replace("/", "_");
                                }

                                sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbumArtists[0], metaData.sAlbum);

                                Directory.CreateDirectory(sPath);
                                File.Copy(file.FullName, Path.Combine(sPath, file.Name), true);
                            }
                            else if (metaData.sAlbum != null)
                            {
                                Directory.CreateDirectory(Path.Combine(settings.sRootDestDir, metaData.sAlbum));

                                sPath = Path.Combine(settings.sRootDestDir, metaData.sAlbum);
                                Directory.CreateDirectory(sPath);
                                File.Copy(file.FullName, Path.Combine(sPath, file.Name), true);
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Debug.WriteLine(e.Source);
                        }
                    }
                }
            }
        }



        public CMetaData LoadFileTags(string sFile)
        {
            CMetaData metaTags = new CMetaData();
            using (TagLib.File tagFile = TagLib.File.Create(sFile))
            {
                GetAllTags(tagFile, ref metaTags);
            }
            return metaTags;
        }

        public void GetArtistTag(TagLib.File tagFile, ref CMetaData metaTags)
        {
            metaTags.sAlbumArtists = tagFile.Tag.AlbumArtists;
        }

        public void GetAlbumTag(TagLib.File tagFile, ref CMetaData metaTags)
        {
            metaTags.sAlbum = tagFile.Tag.Album;
        }

        public void GetAllTags(TagLib.File tagFile, ref CMetaData metaTags)
        {
            metaTags.sTitle = tagFile.Tag.Title;
            metaTags.sAlbum = tagFile.Tag.Album;
            metaTags.sTrack = tagFile.Tag.Track.ToString();
            metaTags.sYear = tagFile.Tag.Year.ToString();
            metaTags.sArtists = tagFile.Tag.Performers;
            metaTags.sAlbumArtists = tagFile.Tag.AlbumArtists;
            metaTags.sComposers = tagFile.Tag.Composers;
            metaTags.uiDiscNo = tagFile.Tag.Disc;

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
    }
}
