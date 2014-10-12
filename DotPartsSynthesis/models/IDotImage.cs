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
    public interface IDotImage
    {
        Image Image { get; }

        /// <summary>
        /// ドット絵の幅
        /// </summary>
        int Width { get; }

        /// <summary>
        /// ドット絵の高さ
        /// </summary>
        int Height { get; }

        /// <summary>
        /// ドット絵のサイズ
        /// </summary>
        Size Size { get; }

        /// <summary>
        /// フルパス
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// フォルダのフルパス
        /// </summary>
        string DirectoryName { get; }

        /// <summary>
        /// 拡張子を除いたファイル名
        /// </summary>
        string NameWithoutExtension { get; }

        /// <summary>
        /// 拡張子
        /// </summary>
        String Extension { get; }

        /// <summary>
        /// フォルダ名を設定する
        /// </summary>
        /// <param name="dir">フォルダ</param>
        void SetDirectory(DirectoryInfo dir);

        /// <summary>
        /// ドット絵を読み込む
        /// </summary>
        void Read();
        
        /// <summary>
        /// ドット絵を書き込む
        /// </summary>
        void Write();

        /// <summary>
        /// リソースを開放する
        /// </summary>
        void Dispose();
    }
}
