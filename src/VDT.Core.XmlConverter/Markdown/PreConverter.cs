﻿using System.IO;

namespace VDT.Core.XmlConverter.Markdown {
    /// <summary>
    /// Converter for rendering code blocks as Markdown
    /// </summary>
    public class PreConverter : BlockElementConverter {
        /// <summary>
        /// Construct an instance of a pre converter
        /// </summary>
        public PreConverter() : base("```", "pre") { }

        /// <inheritdoc/>
        public override void RenderEnd(ElementData elementData, TextWriter writer) {
            base.RenderEnd(elementData, writer);

            elementData.GetContentTracker().WriteLine(writer, "```");
        }
    }
}