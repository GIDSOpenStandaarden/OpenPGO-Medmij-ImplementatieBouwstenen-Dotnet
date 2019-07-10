using System;

namespace MedMij
{
    /// <summary>
    /// Een systeemrol zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    [Serializable]
    public class Systeemrol : ISysteemrol
    {
        internal Systeemrol(string code, Uri resourceEndpointuri)
        {
            this.Code = code;
            this.ResourceEndpointuri = resourceEndpointuri;
        }

        public string Code { get; }

        public Uri ResourceEndpointuri { get; }

        public override string ToString()
        {
            return $"Systeemrolcode:{Code}\nResourceEndpointuri:{ResourceEndpointuri}";
        }
    }
}