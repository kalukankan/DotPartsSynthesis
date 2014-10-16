using DotPartsSynthesis.commons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.models
{
    /// <summary>
    /// ドット絵モデル
    /// </summary>
    public class DotImage : IDotImage
    {
        private FileInfo File { get; set; }
        public Image Image { get; private set; }

        public DotImage(FileInfo file) : this(file, null) { }
        public DotImage(FileInfo file, Image image)
        {
            if(file == null)
            {
                throw new ArgumentNullException("file", Properties.MessageResources.Error_DotImage_NullFile);
            }
            File = file;
            Image = image;
        }

        /// <summary>
        /// ドット絵の幅
        /// </summary>
        public int Width
        {
            get { return Image.Width; }
        }

        /// <summary>
        /// ドット絵の高さ
        /// </summary>
        public int Height
        {
            get { return Image.Height; }
        }

        /// <summary>
        /// ドット絵のサイズ
        /// </summary>
        public Size Size
        {
            get { return Image.Size; }
        }

        /// <summary>
        /// フルパス
        /// </summary>
        public string FullName
        {
            get { return File.FullName; }
        }

        /// <summary>
        /// フォルダのフルパス
        /// </summary>
        public string DirectoryName
        {
            get { return File.DirectoryName; }
        }

        /// <summary>
        /// 拡張子を除いたファイル名
        /// </summary>
        public string NameWithoutExtension
        {
            get { return File.Name.Replace(File.Extension, ""); }
        }

        /// <summary>
        /// 拡張子
        /// </summary>
        public String Extension
        {
            get
            {
                string extension = File.Extension;
                return (extension.StartsWith(".")) ? extension.Substring(1) : extension;
            }
        }

        /// <summary>
        /// ドット絵を読み込む
        /// </summary>
        public void Read()
        {
            Image = Image.FromFile(File.FullName);
        }

        /// <summary>
        /// ドット絵を書き込む
        /// </summary>
        public void Write()
        {
            Logger.Info(Properties.MessageResources.Info_DotImage_WriteDotImage, new string[] { File.FullName });
            Image.Save(File.FullName);
        }

        /// <summary>
        /// フォルダ名を設定する
        /// </summary>
        /// <param name="dir">フォルダ名</param>
        public void SetDirectory(DirectoryInfo dir)
        {
            File = new FileInfo(dir.FullName + "\\" + File.Name);
        }

        /// <summary>
        /// リソースを開放する
        /// </summary>
        public void Dispose()
        {
            if (Image != null)
            {
                try { Image.Dispose(); }
                catch (Exception e)
                {
                    Logger.Debug(Properties.MessageResources.Debug_DotImage_FailedDisposeImage, new string[] { this.FullName }, e);
                }
            }
        }
    }
}
