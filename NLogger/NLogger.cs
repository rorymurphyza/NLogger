using System;
using NLog;

namespace RJM.localLog
{
    /// <summary>
    /// Singleton-pattern class logger, based of NLog package. Make sure to have NLog.config and NLog.xsd in the root directory.
    /// </summary>
    public sealed class localLog
    {
        private static volatile localLog instance;
        private static object syncRoot = new object();
        private static Logger logger = null;

        /// <summary>
        /// Log a message using the NLog package. Check configuration file for output.
        /// </summary>
        private localLog() { }    //Explicit declaration to fit singleton pattern

        public static localLog Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new localLog();
                        }
                    }
                }
                return null;
            }
        }

        #region basic logging
        /// <summary>
        /// Log debug level message to class Logger.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="caller"></param>
        public static void Debug(string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            if (logger == null)
                logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Debug | {0} | {1}", caller, input);
        }

        /// <summary>
        /// Log info level message to class Logger.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="caller"></param>
        public static void Info(string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            if (logger == null)
                logger = LogManager.GetCurrentClassLogger();
            logger.Info("Info | {0} | {1}", caller, input);
        }

        /// <summary>
        /// Log warning level message to class Logger.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="caller"></param>
        public static void Warn(string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            if (logger == null)
                logger = LogManager.GetCurrentClassLogger();
            logger.Warn("Warn | {0} | {1}", caller, input);
        }

        /// <summary>
        /// Log Fatal level message to class Logger.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="caller"></param>
        public static void Fatal(string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            if (logger == null)
                logger = LogManager.GetCurrentClassLogger();
            logger.Fatal("Fatal | {0} | {1}", caller, input);
        }

        /// <summary>
        /// Log error level message to class Logger.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="caller"></param>
        public static void Error(string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            if (logger == null)
                logger = LogManager.GetCurrentClassLogger();
            logger.Error("Error | {0} | {1}", caller, input);
        }

        public static void Exception(Exception ex, string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            if (logger == null)
                logger = LogManager.GetCurrentClassLogger();
            logger.Fatal(ex, input);
        }
        #endregion
    }

    /// <summary>
    /// Logs to a specific log, as determined by the enum used in description
    /// </summary>
    public sealed class logSpecific
    {
        private static volatile logSpecific instance;
        private static object syncRoot = new object();

        /// <summary>
        /// Log a message using the NLog package. Check configuration file for output.
        /// </summary>
        private logSpecific() { }    //Explicit declaration to fit singleton pattern

        public static logSpecific Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new logSpecific();
                        }
                    }
                }
                return null;
            }
        }

        #region logging
        public static void Info(LoggingDestination destination, string input, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            Logger logger = LogManager.GetLogger(destination.ToString());
            GlobalDiagnosticsContext.Set("custom", input);
            logger.Info("Info | {0} | {1}", caller, input);
        }
        #endregion
    }

    /// <summary>
    /// Choose a specific logging destination for a message
    /// </summary>
    public enum LoggingDestination
    {
        Delayed
    }
}
