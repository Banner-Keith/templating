﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.TemplateEngine.Abstractions.Installer;
using Newtonsoft.Json;

namespace Microsoft.TemplateEngine.Edge.BuiltInManagedProvider
{
    /// <summary>
    /// Used just to serialize/deserialize data to/from settings.json file.
    /// </summary>
    internal sealed class GlobalSettingsData
    {
        internal GlobalSettingsData(IReadOnlyList<TemplatePackageData> packages)
        {
            Packages = packages;
        }

        [JsonProperty]
        internal IReadOnlyList<TemplatePackageData> Packages { get; }
    }
}
