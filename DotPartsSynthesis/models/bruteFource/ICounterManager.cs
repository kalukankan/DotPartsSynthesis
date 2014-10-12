using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.models.bruteFource
{
    /// <summary>
    /// カウンター管理モデル
    /// </summary>
    public interface ICounterManager
    {
        /// <summary>
        /// 現在の組み合わせを取得し、次の組み合わせを設定する
        /// </summary>
        /// <returns>現在の組み合わせ</returns>
        int[] Next();

        /// <summary>
        /// 次の組み合わせが存在するか
        /// </summary>
        /// <returns>true:次の組み合わせが存在する false:存在しない</returns>
        bool HasNext();
    }
}
