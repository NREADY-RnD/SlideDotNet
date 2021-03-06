﻿using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using SlideDotNet.Enums;
using SlideDotNet.Models.SlideComponents.Chart;
using SlideDotNet.Shared;
using SlideDotNet.Spreadsheet;
using C = DocumentFormat.OpenXml.Drawing.Charts;

// ReSharper disable PossibleMultipleEnumeration

namespace SlideDotNet.Collections
{
    /// <summary>
    /// Represents a collection of the chart series.
    /// </summary>
    public class SeriesCollection : LibraryCollection<Series>
    {
        private IChartRefParser _chartRefParser;

        #region Constructors

        /// <summary>
        /// Initializes a new collection of the chart series.
        /// </summary>
        public SeriesCollection(IEnumerable<OpenXmlElement> sdkCharts, ChartPart sdkChartPart, IChartRefParser chartRefParser)
        {
            _chartRefParser = chartRefParser;
            Check.NotEmpty(sdkCharts, nameof(sdkCharts));
            Check.NotNull(sdkChartPart, nameof(sdkChartPart));

            var tempSeriesCollection = new LinkedList<Series>(); //TODO: make weak reference
            foreach (var nextSdkChart in sdkCharts)
            {
                Enum.TryParse(nextSdkChart.LocalName, true, out ChartType chartType);
                var nextSdkChartSeriesCollection = nextSdkChart.ChildElements
                    .Where(e => e.LocalName.Equals("ser", StringComparison.Ordinal));
                foreach (var sdkSeries in nextSdkChartSeriesCollection)
                {
                    var series = new Series(chartType, sdkSeries, sdkChartPart, _chartRefParser);
                    tempSeriesCollection.AddLast(series);
                }
            }

            CollectionItems = new List<Series>(tempSeriesCollection);
        }

        #endregion Constructors
    }
}