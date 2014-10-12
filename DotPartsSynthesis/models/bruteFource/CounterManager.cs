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
    public class CounterManager : ICounterManager
    {
        /// <summary>カウンター</summary>
        private ICounter[] counters;

        /// <summary>次の値が存在するか</summary>
        private bool hasNext = true;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="listSize">組み合わせ対象の要素数</param>
        public CounterManager(int[] listSize)
        {
            if (listSize == null)
            {
                throw new ArgumentNullException("listSize", string.Format(Properties.MessageResources.Error_CounterManager_NullListSize, null));
            }
            if (listSize.Length < 2)
            {
                throw new ArgumentOutOfRangeException("listSize", string.Format(Properties.MessageResources.Error_CounterManager_ListSizeUnder2, listSize.Length));
            }

            counters = new Counter[listSize.Length];
            for (int i = 0; i < listSize.Length; i++)
            {
                counters[i] = new Counter(listSize[i] - 1);
            }
        }

        /// <summary>
        /// 現在の組み合わせを取得し、次の組み合わせを設定する
        /// </summary>
        /// <returns>現在の組み合わせ</returns>
        public int[] Next()
        {
            int[] res = new int[counters.Length];

            // 現在の値取得
            for (int i = 0; i < counters.Length; i++)
            {
                res[i] = counters[i].Get();
            }

            // 次の値の設定
            // 1桁目(countersの要素0)
            bool isMoveUp = !counters[0].HasNext();
            if (isMoveUp) counters[0].InitCount();
            if (!isMoveUp) counters[0].Next();

            // 2桁目(countersの要素1～)
            for (int i = 1; i < counters.Length; i++)
            {
                // 下位からの繰り上がりがない場合、計算済み
                if (!isMoveUp) break;

                // 下位からの繰り上がりがある場合
                // 現在の位の繰り上がり処理
                isMoveUp = !counters[i].HasNext();
                if (isMoveUp) counters[i].InitCount();
                if (!isMoveUp) counters[i].Next();
                
                // 現在の位の繰り上がりあり、かつ、最後の位の場合、全組み合わせ終了
                if (isMoveUp && i == counters.Length - 1) hasNext = false;
            }

            return res;
        }

        /// <summary>
        /// 次の組み合わせが存在するか
        /// </summary>
        /// <returns>true:次の組み合わせが存在する false:存在しない</returns>
        public bool HasNext()
        {
            return hasNext;
        }
    }
}
