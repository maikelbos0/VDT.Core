﻿using System;
using System.Collections.Generic;
using Xunit;

namespace VDT.Core.RecurringDates.Tests {
    public class MonthlyRecurrencePatternTests {
        [Theory]
        [InlineData(1, "2022-01-01", "2022-01-01", 0, 0)]
        [InlineData(1, "2022-01-01", "2022-02-02", 0, 1)]
        [InlineData(3, "2022-01-01", "2022-02-15", 1, 14)]
        [InlineData(3, "2022-01-01", "2022-05-15", 1, 14)]
        [InlineData(3, "2022-01-15", "2022-01-15", 0, 14)]
        [InlineData(3, "2022-01-15", "2022-03-14", 2, 13)]
        public void GetCurrentDay(int interval, DateTime start, DateTime current, int expectedMonth, int expectedDay) {
            var pattern = new MonthlyRecurrencePattern(new Recurrence() {
                Interval = interval,
                Start = start
            }) {
            };

            var result = pattern.GetCurrentDay(current);

            Assert.Equal(new DateSpan(expectedMonth, expectedDay), result);
        }

        [Theory]
        [InlineData(1, "2022-01-03", "2022-01-01", false, 0, 5, 5, 25)]
        [InlineData(1, "2022-01-03", "2022-01-06", false, 0, 20, 5, 25)]
        [InlineData(1, "2022-01-03", "2022-01-06", true, 0, 0, 5, 25)]
        [InlineData(3, "2022-01-03", "2022-02-01", false, 2, 5, 5, 25)]

        // TODO fix month overflow test cases
        [InlineData(1, "2022-02-01", "2022-02-01", false, 1, 30, 30)]
        [InlineData(3, "2022-01-01", "2022-01-01", false, 6, 30, 30)]

        // TODO more tests
        public void GetDateSpanUntilNextDay_Only_DaysOfMonth(int interval, DateTime start, DateTime current, bool allowCurrent, int expectedMonth, int expectedDay, params int[] daysOfMonth) {
            var pattern = new MonthlyRecurrencePattern(new Recurrence() {
                Interval = interval,
                Start = start
            }) {
                DaysOfMonth = new HashSet<int>(daysOfMonth)
            };

            var result = pattern.GetDateSpanUntilNextDay(current, allowCurrent);

            Assert.Equal(new DateSpan(expectedMonth, expectedDay), result);
        }
    }
}
