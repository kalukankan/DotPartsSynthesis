using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.commons
{
    /// <summary>
    /// 
    /// </summary>
    static class AppConfig
    {
        private static IList<DirectoryInfo> dotPartsDirs;

        public static IList<DirectoryInfo> DotPartsDirs
        {
            get
            {
                if (dotPartsDirs != null) return dotPartsDirs;

                // 初回取得時はapp.configからパスを読み込む
                string dirsString = ConfigurationManager.AppSettings[AppConst.AppConfigKey.DOT_PARTS_DIRS];
                if (dirsString == null)
                {
                    throw new ConfigurationErrorsException(Properties.MessageResources.Error_AppConfig_NullDotPartsDirs);
                }

                string[] dirs = dirsString.Split(',');
                if(dirs.Length < 2)
                {
                    throw new ConfigurationErrorsException(Properties.MessageResources.Error_AppConfig_DotPartsDirsUnder2);
                }

                dotPartsDirs = new List<DirectoryInfo>();
                for (int i = 0; i < dirs.Length; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    if(!dir.Exists)
                    {
                        // フォルダが存在しない場合、処理続行
                        Logger.Warn(Properties.MessageResources.Warn_AppConfig_NotExistsDotPartsDir, new string[]{dirs[i]});
                        continue;
                    }
                    dotPartsDirs.Add(dir);
                }

                if (dotPartsDirs.Count < 2)
                {
                    throw new ConfigurationErrorsException(Properties.MessageResources.Error_AppConfig_DotPartsDirsUnder2);
                }

                return dotPartsDirs;
            }
        }

        private static DirectoryInfo exportDir;

        public static DirectoryInfo ExportDir
        {
            get
            {
                if (exportDir != null) return exportDir;

                // 初回取得時はapp.configからパスを読み込む
                string dirString = ConfigurationManager.AppSettings[AppConst.AppConfigKey.EXPORT_DIR];
                if (dirString == null)
                {
                    throw new ConfigurationErrorsException(Properties.MessageResources.Error_AppConfig_NullDotPartsDirs);
                }

                return exportDir = new DirectoryInfo(dirString);
            }
        }

        private static string dotPartsExtension;

        public static string DotPartsExtension
        {
            get
            {
                if (dotPartsExtension != null) return dotPartsExtension;

                dotPartsExtension = ConfigurationManager.AppSettings[AppConst.AppConfigKey.DOT_PARTS_EXTENSION];
                return dotPartsExtension;
            }
        }
    }
}
