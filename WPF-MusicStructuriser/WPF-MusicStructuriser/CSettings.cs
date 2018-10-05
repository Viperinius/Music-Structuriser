using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using System.Net;
using System.IO;

namespace WPF_MusicStructuriser
{
    public class CSettings
    {
        public bool bSortAlbums;
        public bool bSortArtists;
        public bool bSortGenre;
        public bool bSortDisc;
        public bool bChangeName;
        public bool bChangeToTrack;
        public bool bChangeToArtist;
        public bool bChangeToTitle;
        public string sRootSourceDir;
        public string sRootDestDir;

        private string GetAppSetting(string key)
        {
            //load AppSettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //check if key exists
            if (config.AppSettings.Settings[key] != null)
            {
                //get value paired with the key
                return config.AppSettings.Settings[key].Value;
            }
            else
            {
                return "__NO_VAL__";
            }
        }

        private void SetAppSetting(string sKey, string sValue)
        {
            //load AppSettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //check if key exists
            if (config.AppSettings.Settings[sKey] != null)
            {
                //key exists, remove it for overriding
                config.AppSettings.Settings.Remove(sKey);
            }
            //add new key value pair
            config.AppSettings.Settings.Add(sKey, sValue);
            //save updated AppSettings
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void ClearAppSetting(string sKey)
        {
            //load AppSettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //check if key exists
            if (config.AppSettings.Settings[sKey] != null)
            {
                //remove key
                config.AppSettings.Settings.Remove(sKey);
            }
            config.Save(ConfigurationSaveMode.Modified);
        }

        public void SetRootSourceDir(string sPath)
        {
            SetAppSetting("RootSourceDir", sPath);
        }

        public string GetRootSourceDir()
        {
            return GetAppSetting("RootSourceDir");
        }

        public void SetRootDestDir(string sPath)
        {
            SetAppSetting("RootDestDir", sPath);
        }

        public string GetRootDestDir()
        {
            return GetAppSetting("RootDestDir");
        }

        public void SetSort()
        {
            int iTmp = 0;
            iTmp = Convert.ToInt32(bSortAlbums) << 3;
            iTmp += Convert.ToInt32(bSortArtists) << 2;
            iTmp += Convert.ToInt32(bSortGenre) << 1;
            iTmp += Convert.ToInt32(bSortDisc) << 0;

            SetAppSetting("Sort", Convert.ToString(iTmp, 2));
        }

        public void UpdateSort()
        {
            string sTmp = GetAppSetting("Sort");
            int iTmp = Convert.ToInt32(sTmp, 2);

            bSortDisc = Convert.ToBoolean(iTmp & 0b0001);
            bSortGenre = Convert.ToBoolean(iTmp & 0b0010);
            bSortArtists = Convert.ToBoolean(iTmp & 0b0100);
            bSortAlbums = Convert.ToBoolean(iTmp & 0b1000);
        }

        public void SetNameChanges()
        {
            int iTmp = 0;
            iTmp = Convert.ToInt32(bChangeName) << 3;
            iTmp += Convert.ToInt32(bChangeToTrack) << 2;
            iTmp += Convert.ToInt32(bChangeToArtist) << 1;
            iTmp += Convert.ToInt32(bChangeToTitle) << 0;

            SetAppSetting("Change", Convert.ToString(iTmp, 2));
        }

        public void UpdateNameChanges()
        {
            string sTmp = GetAppSetting("Change");
            int iTmp = Convert.ToInt32(sTmp, 2);

            bChangeToTitle = Convert.ToBoolean(iTmp & 0b0001);
            bChangeToArtist = Convert.ToBoolean(iTmp & 0b0010);
            bChangeToTrack = Convert.ToBoolean(iTmp & 0b0100);
            bChangeName = Convert.ToBoolean(iTmp & 0b1000);
        }
    }
}
