using DotPartsSynthesis.commons;
using DotPartsSynthesis.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.services
{
    /// <summary>
    /// ドット絵合成サービス
    /// </summary>
    public class DotImageSynthesis
    {
        /// <summary>
        /// ドット絵を合成する
        /// </summary>
        /// <param name="lower">合成時に下になるドット絵</param>
        /// <param name="upper">合成時に上になるドット絵</param>
        /// <returns>合成したドット絵</returns>
        public static IDotImage Execute(IDotImage lower, IDotImage upper)
        {
            Logger.Info(Properties.MessageResources.Info_DotImageSynthesis_ExecuteSynthesis, new string[] { lower.FullName, upper.FullName });

            // ドット絵合成
            Bitmap bitmap = new Bitmap(lower.Width, lower.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(
                    lower.Image,
                    new Rectangle(new Point(0, 0), lower.Size),
                    0,
                    0,
                    lower.Width,
                    lower.Height,
                    GraphicsUnit.Pixel);
                g.DrawImage(
                    upper.Image,
                    new Rectangle(new Point(0, 0), upper.Size),
                    0,
                    0,
                    upper.Width,
                    upper.Height,
                    GraphicsUnit.Pixel);
            }

            // ファイル名合成
            string path = lower.DirectoryName + "\\" + lower.NameWithoutExtension + "_" + upper.NameWithoutExtension + "." + lower.Extension;
            IDotImage res = new DotImage(new FileInfo(path), bitmap);

            return res;
        }
    }
}
