﻿using System.Configuration;
using System.IO;

namespace Eventos.IO.TestesAutomatizados.Config
{
    public class ConfigurationHelper
    {
        public static string SiteUrl => ConfigurationManager.AppSettings["SiteUrl"];
        public static string RegisterUrl => string.Concat(SiteUrl, ConfigurationManager.AppSettings["RegisterUrl"]);
        public static string LoginUrl => string.Concat(SiteUrl, ConfigurationManager.AppSettings["LoginUrl"]);
        public static string ChromeDrive => ConfigurationManager.AppSettings["ChromeDrive"];
        public static string TestUserName => ConfigurationManager.AppSettings["TestUserName"];
        public static string TestPassword => ConfigurationManager.AppSettings["TestPassword"];
        public static string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public static string FolderPicture => string.Concat(FolderPath, ConfigurationManager.AppSettings["FolderPicture"]);
    }
}