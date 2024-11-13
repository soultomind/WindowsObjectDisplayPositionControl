﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsObjectDisplayPositionControl
{
    public class LogLevel
    {
        static LogLevel()
        {
            try
            {
                string value = ConfigurationManager.AppSettings[nameof(AllIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    AllIntValue = int.Parse(value);
                }

                value = ConfigurationManager.AppSettings[nameof(TraceIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    TraceIntValue = int.Parse(value);
                }

                value = ConfigurationManager.AppSettings[nameof(DebugIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    DebugIntValue = int.Parse(value);
                }

                value = ConfigurationManager.AppSettings[nameof(WarnIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    WarnIntValue = int.Parse(value);
                }

                value = ConfigurationManager.AppSettings[nameof(ErrorIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    ErrorIntValue = int.Parse(value);
                }

                value = ConfigurationManager.AppSettings[nameof(FatalIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    FatalIntValue = int.Parse(value);
                }

                value = ConfigurationManager.AppSettings[nameof(OffIntValue)];
                if (!String.IsNullOrEmpty(value))
                {
                    OffIntValue = int.Parse(value);
                }
            }
            catch (Exception ex)
            {
                Toolkit.TraceWriteLine(ex);
            }
        }

        #region ALL
        /// <summary>
        /// 모두 사용(ALL) 정수 값
        /// </summary>
        public static readonly int AllIntValue = 11000;

        /// <summary>
        /// 모두 사용(ALL) 문자열 값
        /// </summary>
        public const string AllString = "ALL";

        /// <summary>
        /// 모두 사용(ALL) 로그레벨
        /// </summary>
        public static readonly LogLevel All = new LogLevel(AllString, AllIntValue);
        #endregion

        #region TRACE
        /// <summary>
        /// 추적(TRACE) 정수 값
        /// </summary>
        public static readonly int TraceIntValue = 10000;

        /// <summary>
        /// 추적(TRACE) 레벨 문자열 값
        /// </summary>

        public const string TraceString = "TRACE";
        /// <summary>
        /// 추적(TRACE) 로그레벨
        /// </summary>
        public static readonly LogLevel Trace = new LogLevel(TraceString, TraceIntValue);
        #endregion

        #region DEBUG
        /// <summary>
        /// 디버그(DEBUG) 정수 값
        /// </summary>
        public static readonly int DebugIntValue = 9000;

        /// <summary>
        /// 디버그(DEBUG) 문자열 값
        /// </summary>
        public const string DebugString = "DEBUG";

        /// <summary>
        /// 디버그(DEBUG) 로그레벨
        /// </summary>
        public static readonly LogLevel Debug = new LogLevel(DebugString, DebugIntValue);

        #endregion

        #region INFO
        /// <summary>
        /// 정보 정수 값
        /// </summary>
        public static readonly int InfoIntValue = 8000;

        /// <summary>
        /// 정보(INFO) 문자열 값
        /// </summary>
        public const string InfoString = "INFO";

        /// <summary>
        /// 정보(INFO) 로그 레벨
        /// </summary>
        public static readonly LogLevel Info = new LogLevel(InfoString, InfoIntValue);
        #endregion

        #region WARN
        /// <summary>
        /// 경고(WARN) 정수 값
        /// </summary>
        public static readonly int WarnIntValue = 7000;

        /// <summary>
        /// 경고(WARN) 문자열 값
        /// </summary>
        public const string WarnString = "WARN";
        /// <summary>
        /// 경고(WARN) 로그레벨
        /// </summary>
        public static readonly LogLevel Warn = new LogLevel(WarnString, WarnIntValue);
        #endregion

        #region ERROR
        /// <summary>
        /// 에러(ERROR) 정수 값
        /// </summary>
        public static readonly int ErrorIntValue = 6000;

        /// <summary>
        /// 에러(ERROR) 문자열 값
        /// </summary>
        public const string ErrorString = "ERROR";

        /// <summary>
        /// 에러(ERROR) 로그 레벨
        /// </summary>
        public static readonly LogLevel Error = new LogLevel(ErrorString, ErrorIntValue);
        #endregion

        #region FATAL
        /// <summary>
        /// 정수 값
        /// </summary>

        public static readonly int FatalIntValue = 5000;

        /// <summary>
        /// 
        /// </summary>
        public const string FatalString = "FATAL";

        /// <summary>
        /// 
        /// </summary>
        public static readonly LogLevel Fatal = new LogLevel(FatalString, FatalIntValue);
        #endregion

        #region OFF
        /// <summary>
        /// 모두 사용하지 않음 정수 값
        /// </summary>
        public static readonly int OffIntValue = 4000;

        /// <summary>
        /// 
        /// </summary>
        public const string OffString = "OFF";

        /// <summary>
        /// 모두 사용하지 않음
        /// </summary>
        public static readonly LogLevel Off = new LogLevel(OffString, OffIntValue);
        #endregion

        public static LogLevel[] LogLevels
        {
            get
            {
                return new LogLevel[]
                {
                    All, Trace, Debug, Info, Warn, Error, Fatal, Off
                };
            }
        }

        /// <summary>
        /// 로그레벨 문자열 속성입니다.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 로그 우선순위 속성입니다.
        /// </summary>
        public int IntValue { get; private set; }

        private LogLevel(string name, int intValue)
        {
            Name = name;
            IntValue = intValue;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel.IntValue <= IntValue)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Name;
        }

        public static LogLevel ValueOf(int intValue)
        {
            foreach (var item in LogLevels)
            {
                if (item.IntValue == intValue)
                {
                    return item;
                }
            }

            throw new ArgumentException(nameof(intValue));
        }
    }
}
