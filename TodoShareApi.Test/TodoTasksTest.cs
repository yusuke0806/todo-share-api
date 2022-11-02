using System.Diagnostics;
using Moq;
using TodoShareApi.Controllers;
using TodoShareApi.Repositories;
using TodoShareApi.Models;

namespace TodoShareApi.Test;

public class TodoTasksTest
{
    [Test]
    public async Task Get()
    {
        // Arrange
        var mockData = new List<TodoTask> { new TodoTask
        {
            Id = 1, 
            TagId = 1,
            Name = "test", 
            Completed = false, 
            Deadline = DateTimeOffset.Now, 
            CreatedAt = DateTimeOffset.Now
        } };
        
        var mock = new Mock<ITodoTaskRepository>();
        mock.Setup(repos => repos.GetAsync())
            .ReturnsAsync(mockData);
        
        var controller = new TodoTasksController(mock.Object);

        // Act
        var result = await controller.Get();

        var todoTasks = result as TodoTask[] ?? result.ToArray();
        
        Assert.That(todoTasks.Length, Is.EqualTo(1));
        Assert.That(todoTasks.First(), Is.EqualTo(mockData.First()));
    }
}