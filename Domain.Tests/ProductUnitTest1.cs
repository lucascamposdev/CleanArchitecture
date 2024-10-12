using Domain.Entities;
using Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new 
                Product("Chocolate", "delicious.", 10.20m, 1, "abcdefg");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithoutName_ThrowsException()
        {
            Action action = () => new 
                Product("", "delicious.", 10.20m, 1, "abcdefg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NameTooShort_ThrowsException()
        {
            Action action = () => new
                Product("ab", "delicious.", 10.20m, 1, "abcdefg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithoutDescription_ThrowsException()
        {
            Action action = () => new
                Product("Chocolate", "", 10.20m, 1, "abcdefg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_DescriptionTooShort_ThrowsException()
        {
            Action action = () => new
                Product("Chocolate", "ab", 10.20m, 1, "abcdefg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_ImageTooLong_ThrowsException()
        {
            Action action = () => new
                Product("Chocolate", "delicious.", 10.20m, 1, "thisssssssssssssssssssssssssssssss isssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssstoooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooonggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NullImage_DoesNotThrowException()
        {
            Action action = () => new
                Product("Chocolate", "delicious.", 10.20m, 1, null);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NullImage_DoesNotThrowNullReferenceException()
        {
            Action action = () => new
                Product("Chocolate", "delicious.", 10.20m, 1, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidPrice_ThrowsException(decimal value)
        {
            Action action = () => new
                Product("Chocolate", "delicious.", value, 1, "abcdefg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStock_ThrowsException(int value)
        {
            Action action = () => new
                Product("Chocolate", "delicious.", 10.20m, value, "abcdefg");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
