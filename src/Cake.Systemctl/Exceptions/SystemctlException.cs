using System;
using System.Collections.Generic;

namespace Cake.Systemctl.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemctlException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemctlException"/>
        /// </summary>
        /// <param name="exitCode"></param>
        /// <param name="errorOutput"></param>
        public SystemctlException(int exitCode, IList<string> errorOutput)
            : this("Something went wrong", exitCode, errorOutput)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemctlException"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exitCode"></param>
        /// <param name="errorOutput"></param>
        public SystemctlException(string message, int exitCode, IList<string> errorOutput)
            : base(message)
        {
            ExitCode = exitCode;
            ErrorOutput = errorOutput;
        }

        /// <summary>
        /// The exit code of the systemctl command
        /// </summary>
        public int ExitCode { get; }

        /// <summary>
        /// Information from error output
        /// </summary>
        public IList<string> ErrorOutput { get; }
    }
}