﻿using System.Collections.Generic;
using System.IO;
using VDT.Core.XmlConverter.Elements;
using Xunit;

namespace VDT.Core.XmlConverter.Tests.Elements {
    public class NoOpElementConverterTests {
        [Fact]
        public void IsValidFor_Returns_True() {
            var converter = new NoOpElementConverter();

            Assert.True(converter.IsValidFor(new ElementData("bar", new Dictionary<string, string>(), false)));
        }

        [Fact]
        public void RenderStart_Renders_StartOuput() {
            using var writer = new StringWriter();
            var converter = new NoOpElementConverter();

            converter.RenderStart(new ElementData("bar", new Dictionary<string, string>() {
                { "baz", "baz" },
                { "foo", "\"foo\"" },
                { "quux", "qu&ux" }
            }, false), writer);

            Assert.Equal("<bar baz=\"baz\" foo=\"&quot;foo&quot;\" quux=\"qu&amp;ux\">", writer.ToString());
        }

        [Fact]
        public void RenderStart_Renders_SelfClosing_StartOuput_IsSelfClosing_Is_True() {
            using var writer = new StringWriter();
            var converter = new NoOpElementConverter();

            converter.RenderStart(new ElementData("bar", new Dictionary<string, string>(), true), writer);

            Assert.Equal("<bar/>", writer.ToString());
        }

        [Fact]
        public void ShouldRenderContent_Returns_True_When_IsSelfClosing_Is_False() {
            var converter = new NoOpElementConverter();

            Assert.True(converter.ShouldRenderContent(new ElementData("bar", new Dictionary<string, string>(), false)));
        }

        [Fact]
        public void ShouldRenderContent_Returns_False_When_IsSelfClosing_Is_True() {
            var converter = new NoOpElementConverter();

            Assert.False(converter.ShouldRenderContent(new ElementData("bar", new Dictionary<string, string>(), true)));
        }

        [Fact]
        public void RenderEnd_Renders_EndOuput_When_IsSelfClosing_Is_False() {
            using var writer = new StringWriter();
            var converter = new NoOpElementConverter();

            converter.RenderEnd(new ElementData("bar", new Dictionary<string, string>(), false), writer);

            Assert.Equal("</bar>", writer.ToString());
        }
    }
}