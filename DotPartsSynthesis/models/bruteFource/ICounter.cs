using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.models.bruteFource
{
    /// <summary>
    /// カウントを行うモデル
    /// </summary>
    public interface ICounter
    {
        /// <summary>
        /// 現在値を取得する
        /// </summary>
        /// <returns>現在値</returns>
        int Get();

        /// <summary>
        /// 現在の値を取得し、次の値を設定する
        /// </summary>
        /// <returns>現在値</returns>
        int Next();

        /// <summary>
        /// 現在の値を初期化する
        /// </summary>
        void InitCount();

        /// <summary>
        /// 次の値が存在するか
        /// </summary>
        /// <returns>true:次の値が存在する false:存在しない</returns>
        bool HasNext();
    }
}
