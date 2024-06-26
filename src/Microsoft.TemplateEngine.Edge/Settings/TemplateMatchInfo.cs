// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.TemplateEngine.Abstractions;
using Microsoft.TemplateEngine.Edge.Template;

namespace Microsoft.TemplateEngine.Edge.Settings
{
    [Obsolete("This implementation is deprecated, use " + nameof(TemplateMatchInfo) + " instead")]
    internal class TemplateMatchInfoEx : ITemplateMatchInfo
    {
        private readonly IList<MatchInfo> _matchDisposition;

        private readonly IList<MatchInfo> _dispositionOfDefaults;

        public TemplateMatchInfoEx(ITemplateInfo info, IReadOnlyList<MatchInfo> matchDispositions)
                            : this(info)
        {
            if (matchDispositions != null)
            {
                foreach (MatchInfo disposition in matchDispositions)
                {
                    AddDisposition(disposition);
                }
            }
        }

        public TemplateMatchInfoEx(ITemplateInfo info)
        {
            Info = info;
            _matchDisposition = new List<MatchInfo>();
            _dispositionOfDefaults = new List<MatchInfo>();
        }

        public ITemplateInfo Info { get; }

        public IReadOnlyList<MatchInfo> MatchDisposition => _matchDisposition.ToList();

        // Stores match info relative to default settings.
        // These don't have to match for the template to be a match, but they can be used to filter matches
        // in appropriate situations.
        // For example, matching or non-matching on the default language should only be used as a final disambiguation.
        // It shouldn't unconditionally disqualify a match.
        public IReadOnlyList<MatchInfo> DispositionOfDefaults => _dispositionOfDefaults.ToList();

        public bool IsMatch => MatchDisposition.Count > 0 && MatchDisposition.All(x => x.Kind != MatchKind.Mismatch);

        public bool IsPartialMatch => MatchDisposition.Any(x => x.Kind != MatchKind.Mismatch);

        public void AddDisposition(MatchInfo newDisposition)
        {
            if (newDisposition.Location == MatchLocation.DefaultLanguage)
            {
                _dispositionOfDefaults.Add(newDisposition);
            }
            else
            {
                _matchDisposition.Add(newDisposition);
            }
        }
    }

    internal class TemplateMatchInfo : Abstractions.TemplateFiltering.ITemplateMatchInfo
    {
        private readonly List<Abstractions.TemplateFiltering.MatchInfo> _matchDisposition = new List<Abstractions.TemplateFiltering.MatchInfo>();

        internal TemplateMatchInfo(ITemplateInfo info, IReadOnlyList<Abstractions.TemplateFiltering.MatchInfo> matchDispositions)
            : this(info)
        {
            if (matchDispositions != null)
            {
                foreach (Abstractions.TemplateFiltering.MatchInfo disposition in matchDispositions)
                {
                    AddMatchDisposition(disposition);
                }
            }
        }

        internal TemplateMatchInfo(ITemplateInfo info)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public ITemplateInfo Info { get; }

        public IReadOnlyList<Abstractions.TemplateFiltering.MatchInfo> MatchDisposition => _matchDisposition;

        public void AddMatchDisposition(Abstractions.TemplateFiltering.MatchInfo newDisposition)
        {
            _matchDisposition.Add(newDisposition);
        }
    }
}
