using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.models.bruteFource
{
    /// <summary>
    /// 2次元配列風にネストしているListオブジェクトに対して
    /// 縦の組み合わせを総当りで取得/管理するモデル
    /// </summary>
    public interface IBruteForceManager<T>
    {
        /// <summary>
        /// 現在の組み合わせを取得し、次の組み合わせを設定する
        /// </summary>
        /// <returns></returns>
        IList<T> Next();

        /// <summary>
        /// 次の組み合わせが存在するか
        /// </summary>
        /// <returns>true:次の組み合わせが存在する false:存在しない</returns>
        bool HasNext();
    }
}
