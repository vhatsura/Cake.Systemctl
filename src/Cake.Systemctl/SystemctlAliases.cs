using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Systemctl.Models;
using Cake.Systemctl.Runners;
using Cake.Systemctl.Settings;

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
    public static partial class SystemctlAliases
    {
        [CakeMethodAlias]
        public static SystemctlRunner Systemctl(this ICakeContext context) => new SystemctlRunner(context);
    }
}