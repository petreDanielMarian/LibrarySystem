using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Library.ExtensionMethods;
using Xunit;

namespace AutomaticTests.Tests.ExtensionsMethodsTests
{
    public class CollectionExtensionsTests
    {
        private readonly IList<string> _list;
        public CollectionExtensionsTests()
        {
            _list = new List<string>{"first", "second", "third"};
        }

        [Fact]
        public void ShouldRemoveFirstElementThatFulfillsTheMatch()
        {
            //Arrange
            Predicate<string> match = str => str.EndsWith("nd");
            
            //Act
            _list.RemoveFirst(match);
            
            //Assert
            _list.Count.Should().Be(2);
            _list.Should().Equal("first", "third");
        }

        [Fact]
        public void ShouldReturnTheOriginalListIfThereWasNoMatch()
        {
            //Arrange
            Predicate<string> match = str => str.EndsWith("th");
            
            //Act
            _list.RemoveFirst(match);
            
            //Assert
            _list.Count.Should().Be(3);
            _list.Should().Equal("first", "second", "third");
        }
    }
}