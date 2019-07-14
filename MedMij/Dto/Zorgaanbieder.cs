// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedMij
{
    /// <summary>
    /// Een zorgaanbieder zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    [Serializable]
    public class Zorgaanbieder
    {
        internal Zorgaanbieder(string naam, IDictionary<string, Gegevensdienst> gegevensdiensten)
        {
            this.Naam = naam;
            this.Gegevensdiensten = new ReadOnlyDictionary<string, Gegevensdienst>(gegevensdiensten);
        }

        /// <summary>
        /// Gets de unieke en gebruiksvriendelijke naam van een zorgaanbieder
        /// </summary>
        public string Naam { get; }

        /// <summary>
        /// Gets de lijst met gegevensdiensten die horen bij deze zorgaanbieder
        /// </summary>
        public IReadOnlyDictionary<string, Gegevensdienst> Gegevensdiensten { get; }
    }
}
