// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MedMij
{
    /// <summary>
    /// Een gegevensdienst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    [Serializable]
    public class Gegevensdienst : IGegevensdienst
    {
        internal Gegevensdienst(string id, string zorgaanbiedernaam, Uri authorizationEndpointUri, Uri tokenEndpointUri, IReadOnlyDictionary<string, Systeemrol> systeemrollen)
        {
            this.Id = id;
            this.Zorgaanbiedernaam = zorgaanbiedernaam;
            this.AuthorizationEndpointUri = authorizationEndpointUri;
            this.TokenEndpointUri = tokenEndpointUri;
            this.Systeemrollen = systeemrollen;
        }

        /// <summary>
        /// Gets de binnen de zorgaanbieder unieke id van de gegevensdienst
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets de naam van de zorgaanbieder van deze gevensdienst. Eindigt altijd op "@medmij"
        /// </summary>
        public string Zorgaanbiedernaam { get; }

        /// <summary>
        /// Gets de AuthorizationEndpointUri van deze gevensdienst.
        /// </summary>
        public Uri AuthorizationEndpointUri { get; }

        /// <summary>
        /// Gets de TokenEndpointUri van deze gevensdienst.
        /// </summary>
        public Uri TokenEndpointUri { get; }

        /// <summary>
        /// Gets the Systeemrollen defined within this gegevensdienst.
        /// </summary>
        public IReadOnlyDictionary<string, Systeemrol> Systeemrollen { get; }

        public override string ToString()
        {
            string ret = $"id:{Id}\nName:{Zorgaanbiedernaam}\nAuthEndpoint{AuthorizationEndpointUri.OriginalString}\nTokenEndpoint{TokenEndpointUri.OriginalString}\n";
            this.Systeemrollen.ToList().ForEach(systeemrol => String.Concat(ret, systeemrol.ToString()));
            return ret;
        }
    }
}
