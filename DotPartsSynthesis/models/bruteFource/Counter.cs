using NLog;
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
    class Counter : ICounter
    {
        /// <summary>カウンター</summary>
        private int count;
        /// <summary>カウンターの最大値</summary>
        private int maxCount;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="maxCount">カウンターの最大値(0以上を指定してください)</param>
        public Counter(int maxCount)
        {
            if (maxCount < 0)
            {
                throw new ArgumentOutOfRangeException("maxCount", String.Format(Properties.MessageResources.Error_Counter_MaxCountUnder0, maxCount));
            }
            this.maxCount = maxCount;
            InitCount();
        }

        public int Get()
        {
            return count;
        }

        public int Next()
        {
            return count++;
        }

        public void InitCount()
        {
            count = 0;
        }

        public bool HasNext()
        {
            return count < maxCount;
        }
    }
}
