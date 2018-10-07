using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Systemctl
{
    /// <summary>
    ///     Systemctl aliases.
    ///     A set of aliases for <see cref="http://cakebuild.net">Cake Build</see> to help with
    ///     <see cref="https://www.freedesktop.org/software/systemd/man/systemctl.html">systemctl</see> operations
    /// </summary>
    [CakeAliasCategory("Systemctl")]
    [CakeNamespaceImport("Cake.Systemctl.Models")]
    [CakeNamespaceImport("Cake.Systemctl.Settings")]
    public static class SystemctlAliases
    {
        [CakePropertyAlias]
        public static SystemctlRunner Systemctl(this ICakeContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new SystemctlRunner(context);
        }
    }
}