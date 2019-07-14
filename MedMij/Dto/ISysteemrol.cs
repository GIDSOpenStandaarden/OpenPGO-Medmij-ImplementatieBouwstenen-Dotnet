// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

using System;

namespace MedMij
{
    /// <summary>
    /// Een systeemrol zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public interface ISysteemrol
    {
        /// <summary>
        /// Gets de Code van deze systeemrol.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets de ResourceEndpointuri van deze systeemrol.
        /// </summary>
        Uri ResourceEndpointuri { get; }
    }
}