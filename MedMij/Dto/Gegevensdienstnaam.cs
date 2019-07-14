// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

using System;

namespace MedMij
{
    /// <summary>
    /// The gegevensdienstnaam. see definition on https://afsprakenstelsel.medmij.nl/
    /// </summary>
    [Serializable]
    public class Gegevensdienstnaam
    {
        /// <summary>
        /// Gets the GegevensdienstId
        /// </summary>
        public string GegevensdienstId { get; set; }

        /// <summary>
        /// Gets Weergavenaam
        /// </summary>
        public string Weergavenaam { get; set; }
    }
}
