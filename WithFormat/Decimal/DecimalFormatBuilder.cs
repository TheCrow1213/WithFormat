﻿using System;
using System.Globalization;
using WithFormat.Cultures;

namespace WithFormat.Decimal
{
    public class DecimalFormatBuilder
    {
        private decimal Subject { get; set; }
        private string FormatSpecifier { get; set; }
        private CultureInfo Culture { get; set; }
        private int? Precision { get; set; }

        internal DecimalFormatBuilder(decimal subject, string formatSpecifier)
        {
            Subject = subject;
            FormatSpecifier = formatSpecifier;
        }

        public DecimalFormatBuilder Using<T>() where T : IFormatCulture, new()
        {
            Culture = new T().Culture();
            return this;
        }

        public DecimalFormatBuilder WithPrecision(int precision)
        {
            Precision = precision;
            return this;
        }

        public string Format()
        {
            var formatString = String.Format("{0}{1}", FormatSpecifier, Precision);
            return Subject.ToString(formatString, Culture);
        }
    }
}