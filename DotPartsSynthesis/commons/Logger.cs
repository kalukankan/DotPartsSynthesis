//Copyright (c) 2014, kalukankan <kalukankan@gmail.com>
//All rights reserved.
//
//Redistribution and use in source and binary forms, with or without
//modification, are permitted provided that the following conditions are met:
//* Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer.
//* Redistributions in binary form must reproduce the above copyright notice, 
//  this list of conditions and the following disclaimer in the documentation 
//  and/or other materials provided with the distribution.
//* Neither the name of the <organization> nor the　names of its contributors 
//  may be used to endorse or promote products derived from this software 
//  without specific prior written permission.
//
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
//DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//
//Copyright (c) 2004-2011 Jaroslaw Kowalski <jaak@jkowalski.net>
//
//All rights reserved.
//
//Redistribution and use in source and binary forms, with or without 
//modification, are permitted provided that the following conditions 
//are met:
//
//* Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer. 
//
//* Redistributions in binary form must reproduce the above copyright notice,
//  this list of conditions and the following disclaimer in the documentation
//  and/or other materials provided with the distribution. 
//
//* Neither the name of Jaroslaw Kowalski nor the names of its 
//  contributors may be used to endorse or promote products derived from this
//  software without specific prior written permission. 
//
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
//IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
//ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
//LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
//CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
//SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
//INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
//CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
//ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
//THE POSSIBILITY OF SUCH DAMAGE.

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPartsSynthesis.commons
{
    /// <summary>
    /// NLogアダプター
    /// </summary>
    public class Logger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Info(string message, Object[] param)
        {
            logger.Info(string.Format(message, param));
        }

        public static void Info(string message, Exception e)
        {
            logger.Info(message, e);
        }

        public static void Info(string message, Object[] param, Exception e)
        {
            logger.Info(string.Format(message, param), e);
        }

        public static void Warn(string message)
        {
            logger.Warn(message);
        }

        public static void Warn(string message, Object[] param)
        {
            logger.Warn(string.Format(message, param));
        }

        public static void Warn(string message, Exception e)
        {
            logger.Warn(message, e);
        }

        public static void Warn(string message, Object[] param, Exception e)
        {
            logger.Warn(string.Format(message, param), e);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Error(string message, Object[] param)
        {
            logger.Error(string.Format(message, param));
        }

        public static void Error(string message, Exception e)
        {
            logger.Error(message, e);
        }

        public static void Error(string message, Object[] param, Exception e)
        {
            logger.Error(string.Format(message, param), e);
        }

        public static void Trace(string message)
        {
            logger.Trace(message);
        }

        public static void Trace(string message, Object[] param)
        {
            logger.Trace(string.Format(message, param));
        }

        public static void Trace(string message, Exception e)
        {
            logger.Trace(message, e);
        }

        public static void Trace(string message, Object[] param, Exception e)
        {
            logger.Trace(string.Format(message, param), e);
        }

        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        public static void Debug(string message, Object[] param)
        {
            logger.Debug(string.Format(message, param));
        }

        public static void Debug(string message, Exception e)
        {
            logger.Debug(message, e);
        }

        public static void Debug(string message, Object[] param, Exception e)
        {
            logger.Debug(string.Format(message, param), e);
        }

        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public static void Fatal(string message, Object[] param)
        {
            logger.Fatal(string.Format(message, param));
        }

        public static void Fatal(string message, Exception e)
        {
            logger.Fatal(message, e);
        }

        public static void Fatal(string message, Object[] param, Exception e)
        {
            logger.Fatal(string.Format(message, param), e);
        }
    }
}
