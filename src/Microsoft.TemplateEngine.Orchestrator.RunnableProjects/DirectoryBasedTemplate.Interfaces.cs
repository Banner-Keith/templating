﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TemplateEngine.Abstractions;
using Microsoft.TemplateEngine.Abstractions.Constraints;
using Microsoft.TemplateEngine.Abstractions.Parameters;

namespace Microsoft.TemplateEngine.Orchestrator.RunnableProjects
{
    internal abstract partial class DirectoryBasedTemplate : ITemplateMetadata, ITemplateLocator
    {
        string ITemplateMetadata.Identity => TemplateIdentity;

        Guid ITemplateLocator.GeneratorId => Generator.Id;

        string? ITemplateMetadata.Author => ConfigurationModel.Author;

        string? ITemplateMetadata.Description => ConfigurationModel.Description;

        IReadOnlyList<string> ITemplateMetadata.Classifications => ConfigurationModel.Classifications;

        string? ITemplateMetadata.DefaultName => ConfigurationModel.DefaultName;

        string? ITemplateMetadata.GroupIdentity => ConfigurationModel.GroupIdentity;

        int ITemplateMetadata.Precedence => ConfigurationModel.Precedence;

        string ITemplateMetadata.Name => ConfigurationModel.Name ?? throw new TemplateValidationException("Template configuration should have name defined");

        IReadOnlyList<string> ITemplateMetadata.ShortNameList => ConfigurationModel.ShortNameList ?? new List<string>();

        public IParameterDefinitionSet ParameterDefinitions => Parameters;

        string ITemplateLocator.MountPointUri => ConfigFile?.MountPoint.MountPointUri ?? throw new InvalidOperationException($"{nameof(ConfigFile)} should be set in order to continue");

        string ITemplateLocator.ConfigPlace => ConfigFile?.FullPath ?? throw new InvalidOperationException($"{nameof(ConfigFile)} should be set in order to continue");

        string? ITemplateMetadata.ThirdPartyNotices => ConfigurationModel.ThirdPartyNotices;

        IReadOnlyDictionary<string, IBaselineInfo> ITemplateMetadata.BaselineInfo => ConfigurationModel.BaselineInfo;

        IReadOnlyDictionary<string, string> ITemplateMetadata.TagsCollection => ConfigurationModel.Tags;

        IReadOnlyList<Guid> ITemplateMetadata.PostActions => ConfigurationModel.PostActionModels.Select(pam => pam.ActionId).ToArray();

        IReadOnlyList<TemplateConstraintInfo> ITemplateMetadata.Constraints => ConfigurationModel.Constraints;

        public IReadOnlyList<IValidationEntry> ValidationErrors => throw new NotImplementedException();
    }
}
