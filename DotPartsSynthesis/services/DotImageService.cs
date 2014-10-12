using DotPartsSynthesis.commons;
using DotPartsSynthesis.models;
using DotPartsSynthesis.models.bruteFource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.services
{
    /// <summary>
    /// ドット絵サービス
    /// </summary>
    public class DotImageService : IDotImageService
    {
        /// <summary>
        /// ドット絵の合成を行う
        /// </summary>
        public void Synthesis()
        {
            IList<IList<IDotImage>> dotList = new List<IList<IDotImage>>();
            try
            {
                // 画像読み込み
                Logger.Info(Properties.MessageResources.Info_DotImageService_SuccessSynthesis);
                IList<DirectoryInfo> partsDirList = AppConfig.DotPartsDirs;
                for (int i = 0; i < partsDirList.Count; i++)
                {
                    Logger.Info(Properties.MessageResources.Info_DotImageService_ReadingDotImages, new object[] { "(" + (i + 1) + "/" + partsDirList.Count + ")" });

                    IList<FileInfo> partsList = partsDirList[i].GetFiles("*" + AppConfig.DotPartsExtension);
                    // 画像を読み込みリストに詰める
                    dotList.Add(ToDotImages(partsList));

                    Logger.Info(Properties.MessageResources.Info_DotImageService_ReadedDotImages, new object[] { partsList.Count });
                }

                // 出力フォルダの生成
                if(!AppConfig.ExportDir.Exists)
                {
                    Logger.Info(Properties.MessageResources.Info_DotImageService_CreateExportDir, new object[] { AppConfig.ExportDir.FullName });
                    AppConfig.ExportDir.Create();
                }

                // 組み合わせ設定
                Logger.Info(Properties.MessageResources.Info_DotImageService_SynthesisDotImage);
                IBruteForceManager<IDotImage> bruteForceManager = new BruteFourceManager<IDotImage>(dotList);

                while (bruteForceManager.HasNext())
                {
                    // 画像合成
                    IList<IDotImage> targets = bruteForceManager.Next();
                    IDotImage image = targets.First();
                    for (int i = 1; i < targets.Count; i++)
                    {
                        image = DotImageSynthesis.Execute(image, targets[i]);
                    }

                    // 画像出力
                    image.SetDirectory(AppConfig.ExportDir);
                    image.Write();
                }

                Logger.Info(Properties.MessageResources.Info_DotImageService_SuccessSynthesis);
            }
            catch(Exception e)
            {
                Logger.Error(Properties.MessageResources.Error_DotImageService_FailedSynthesis, e);
            }
            finally
            {
                // ドット絵のリソース開放
                if (dotList != null && dotList.Count > 0)
                {
                    foreach(IList<IDotImage> parts in dotList)
                    {
                        foreach(IDotImage image in parts)
                        {
                            if(image != null)
                            {
                                image.Dispose();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ドット絵モデルに変換する
        /// </summary>
        /// <param name="fileInfos"></param>
        /// <returns></returns>
        private IList<IDotImage> ToDotImages(IList<FileInfo> fileInfos)
        {
            IList<IDotImage> images = new List<IDotImage>();
            foreach (FileInfo fileInfo in fileInfos)
            {
                IDotImage image = new DotImage(fileInfo);
                image.Read();
                images.Add(image);
            }
            return images;
        }
    }
}
