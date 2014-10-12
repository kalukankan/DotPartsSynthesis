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
    public class BruteFourceManager<T> : IBruteForceManager<T>
    {
        /// <summary>組み合わせ対象リスト</summary>
        private IList<IList<T>> list;

        /// <summary>カウンター管理</summary>
        private ICounterManager counter;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="list">組み合わせを格納したList</param>
        public BruteFourceManager(IList<IList<T>> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list", Properties.MessageResources.Error_BruteForceManager_NullList);
            }
            if (list.Count < 2 || list[0].Count == 0 || list[1].Count == 0)
            {
                throw new ArgumentOutOfRangeException("list", Properties.MessageResources.Error_BruteForceManager_ListSizeUnder2);
            }

            this.list = list;
            int[] listSize = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                listSize[i] = list[i].Count;
            }
            counter = new CounterManager(listSize);
        }

        /// <summary>
        /// 現在の組み合わせを取得し、次の組み合わせを設定する
        /// </summary>
        /// <returns></returns>
        public IList<T> Next()
        {
            // 組み合わせのインデックスを取得
            IList<T> res = new List<T>();
            int[] indexs = counter.Next();

            // 組み合わせのインデックスから値を取得
            for (int i = 0; i < list.Count; i++)
            {
                res.Add(list[i][indexs[i]]);
            }
            return res;
        }

        /// <summary>
        /// 次の組み合わせが存在するか
        /// </summary>
        /// <returns>true:次の組み合わせが存在する false:存在しない</returns>
        public bool HasNext()
        {
            return counter.HasNext();
        }
    }
}
