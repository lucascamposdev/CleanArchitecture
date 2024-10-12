using Domain.Entities;
using Domain.Validation;
using FluentAssertions;

namespace Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid Parameters")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1 , "Doces");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category without a name")]
        public void CreateCategory_WithoutName_ThrowsException()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category with an short name")]
        public void CreateCategory_NameTooShort_ThrowsException()
        {
            Action action = () => new Category(1, "ab");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category with an null name")]
        public void CreateCategory_NullName_ThrowsException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}