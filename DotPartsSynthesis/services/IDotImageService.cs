using DotPartsSynthesis.models;
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
    public interface IDotImageService
    {
        /// <summary>
        /// ドット絵の合成を行う
        /// </summary>
        void Synthesis();
    }
}
