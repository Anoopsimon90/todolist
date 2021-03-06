using Moq;
using ToDoList.Models;
using ToDoList.Services;
using Xunit;

namespace ToDoList.Tests
{
    public class ValidationTests
    {
        [Fact]
        [Trait("validation","inputvalidation")]
        public void ValidateEmptyTaskName()
        {
            Mock<ITodoListService> mockService = new Mock<ITodoListService>();
            var status = mockService.Object.AddItem(new Item() { Name = "" });

            Assert.False(status,"Should be False because Task Name is Empty");
        }

        [Fact]
        [Trait("validation", "inputvalidation")]
        public void ValidateNullTaskName()
        {
            Mock<ITodoListService> mockService = new Mock<ITodoListService>();
            var status = mockService.Object.AddItem(new Item() { Name = null });
                
            Assert.False(status, "Should be False because Task Name is null");
        }

        [Theory]
        [Trait("validation", "inputvalidation")]
        [InlineData("test")]
        [InlineData("hello")]
        [InlineData("demo")]
        public void ValidateProfanityCheck(string itemName)
        {
            Mock<ITodoListService> mockService = new Mock<ITodoListService>();
            var status = mockService.Object.AddItem(new Item() { Name = itemName });

            Assert.False(status, "Should be False because Task Name is null");

        }




    }
}
