﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.CommandLine;
using Microsoft.TemplateEngine.Abstractions;

namespace Microsoft.TemplateEngine.Cli.Commands
{
    internal class InstallCommand : BaseInstallCommand
    {
        public InstallCommand(
                NewCommand parentCommand,
                Func<ParseResult, ITemplateEngineHost> hostBuilder,
                Func<ParseResult, ITelemetryLogger> telemetryLoggerBuilder,
                NewCommandCallbacks callbacks)
            : base(parentCommand, hostBuilder, telemetryLoggerBuilder, callbacks, "install")
        {
            parentCommand.AddNoLegacyUsageValidators(this);
        }
    }
}