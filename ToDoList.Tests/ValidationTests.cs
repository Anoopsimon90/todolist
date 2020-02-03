using Moq;
using System;
using ToDoList.Models;
using ToDoList.Services;
using Xunit;

namespace ToDoList.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ValidateEmptyTaskName()
        {
            Mock<ITodoListService> mockService = new Mock<ITodoListService>();
            var status = mockService.Object.AddItem(new Item() { Name = "" });

            Assert.False(status,"Should be False because Task Name is Empty");
        }

        [Fact]
        public void ValidateNullTaskName()
        {
            Mock<ITodoListService> mockService = new Mock<ITodoListService>();
            var status = mockService.Object.AddItem(new Item() { Name = null });

            Assert.False(status, "Should be False because Task Name is null");
        }
    }
}
