﻿using Xunit;

namespace VDT.Core.RecurringDates.Tests {
    public class DailyRecurrencePatternExtensionsTests {
        [Fact]
        public void IncludeWeekends() {
            var pattern = new DailyRecurrencePattern() {
                IncludingWeekends = false
            };

            pattern.IncludeWeekends();

            Assert.True(pattern.IncludingWeekends);
        }

        [Fact]
        public void ExcludeWeekends() {
            var pattern = new DailyRecurrencePattern() {
                IncludingWeekends = true
            };

            pattern.ExcludeWeekends();

            Assert.False(pattern.IncludingWeekends);
        }
    }
}
