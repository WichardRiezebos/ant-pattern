﻿using NUnit.Framework;

namespace AntPathMatching.Tests
{
    [TestFixture]
    public class AntTests
    {
        [TestCase("/dir1/**/*.txt", "/dir1/dir2/dir3/file1.txt", true)]
        [TestCase("/dir1/**/*.txt", "/dir1/dir2/dir3/file1.zip", false)]
        [TestCase("/dir1/dir2/**/*.txt", "/dir1/dir2/dir3/file1.txt", true)]
        [TestCase("/dir1/dir2/**/*.txt", "/dir1/dir3/dir2/file1.txt", false)]
        [TestCase("/dir1/*.txt", "/dir1/file1.txt", true)]
        [TestCase("/dir1/*.txt", "/dir1/file1.zip", false)]
        [TestCase("/dir1/file?.txt", "/dir1/file1.txt", true)]
        [TestCase("/dir1/file?.txt", "/dir1/file12.txt", false)]
        [TestCase("/dir1/file?.*", "/dir1/file1.zip", true)]
        [TestCase("/dir1/file?.*", "/dir1/file12.zip", false)]
        [TestCase("/dir1/*/file.txt", "/dir1/dir1_1/file.txt", true)]
        [TestCase("/dir1/*/file.txt", "/dir1/dir1_1/dir1_2/file.txt", false)]
        [TestCase("/dir1/*/file.txt", "/dir1/dir1_1/dir1_2/file.txtt", false)]
        public void IsMatch_FromTable_ReturnsExpectedValue(
            string pattern,
            string scenario,
            bool expected)
        {
            var ant = new Ant(pattern);
            var match = ant.IsMatch(scenario);

            Assert.That(match, Is.EqualTo(expected));
        }
    }
}
