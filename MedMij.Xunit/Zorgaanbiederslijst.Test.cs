// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;
    using global::Xunit.Abstractions;


    public class ZorgaanbiederslijstTest
    {
        private readonly ITestOutputHelper output;

        public ZorgaanbiederslijstTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML)]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML)]
        public void ZorgaanbiedersCollectionParseOK(string xmlData)
        {
            output.WriteLine(xmlData);
            var result = Zorgaanbiederslijst.FromXMLData(xmlData);
            output.WriteLine(result.ToString());
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML)]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML)]
        public void ZorgaanbiedersCollectionIsIterable(string xmlData)
        {
            output.WriteLine($"[ZorgaanbiedersCollectionIsIterable] Parsing: {xmlData}");
            var col = Zorgaanbiederslijst.FromXMLData(xmlData);
            output.WriteLine($"[ZorgaanbiedersCollectionIsIterable] {col.Data.Count} records found");
            // Assert.True(col.Data.Count > 0);
            foreach (var c in col.Data)
            {
                output.WriteLine(c.Naam);
                foreach (var pair in c.Gegevensdiensten)
                {
                    output.WriteLine($"{pair.Key} == {pair.Value.Id}");
                    output.WriteLine(pair.Value.AuthorizationEndpointUri.ToString());
                    output.WriteLine(pair.Value.TokenEndpointUri.ToString());
                    foreach (var role in pair.Value.Systeemrollen)
                        output.WriteLine(role.ToString());
                }
                output.WriteLine("");
            }
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.InvalidXML)]
        public void ZorgaanbiedersCollectionInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => Zorgaanbiederslijst.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionXSDFail1)]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionXSDFail2)]
        public void ZorgaanbiedersCollectionXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => Zorgaanbiederslijst.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("umcharderwijk@medmij")]
        [InlineData("radiologencentraalflevoland@medmij")]
        public void ZorgaanbiedersCollectionContains(string name)
        {
            var zorgaanbieders = Zorgaanbiederslijst.FromXMLData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML);
            Assert.NotNull(zorgaanbieders.GetByName(name));
        }

        [Theory]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML, "umcharderwijk")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML, "UMCHarderwijk@medmij")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionExampleXML, "")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML, "")]
        [InlineData(ZorgaanbiederslijstTestMock.ZorgaanbiedersCollectionEmptyExampleXML, "umcharderwijk@medmij")]
        public void ZorgaanbiedersCollectionNotContains(string xml, string name)
        {
            var zorgaanbieders = Zorgaanbiederslijst.FromXMLData(xml);
            Assert.Throws<KeyNotFoundException>(() => zorgaanbieders.GetByName(name));
        }
    }
}
