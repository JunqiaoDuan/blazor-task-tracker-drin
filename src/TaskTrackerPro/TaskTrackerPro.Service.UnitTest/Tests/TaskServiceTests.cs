using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;
using TaskTrackerPro.Service.Services;
using TaskTrackerPro.Service.Shared.Repository;
using TaskTrackerPro.Service.Specifications.TaskItems;
using Xunit;

namespace TaskTrackerPro.Service.UnitTest.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<IRepository<TaskItem>> _repoMock;
        private readonly TaskService _service;

        public TaskServiceTests()
        {
            _repoMock = new Mock<IRepository<TaskItem>>();
            _service = new TaskService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsSortedTasks()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Low", 
                    TaskItemPriority = TaskItemPriority.Low
                },
                new TaskItem 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "High",
                    TaskItemPriority = TaskItemPriority.High,
                }
            };
            _repoMock.Setup(r => r.ListAsync(It.IsAny<TaskItemListSpec>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(tasks);

            // Act
            var result = await _service.GetAllFilterredAsync("", "", null, null);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(TaskItemPriority.High, result[1].TaskItemPriority);
        }

        [Fact]
        public async Task AddAsync_AddsTask()
        {
            // Arrange
            var task = new TaskItem
            {
                Title = "Test",
                TaskItemPriority = TaskItemPriority.Medium
            };
            _repoMock.Setup(r => r.AddAsync(It.Is<TaskItem>(t => t.Title == "Test"), default))
                     .ReturnsAsync((TaskItem t, CancellationToken _) => t);

            // Act
            await _service.AddAsync(task);

            // Assert
            _repoMock.Verify(r => r.AddAsync(It.Is<TaskItem>(t => t.Title == "Test"), default), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesTask()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existing = new TaskItem
            {
                Id = id,
                Title = "Old",
                TaskItemPriority = TaskItemPriority.Low
            };
            _repoMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<TaskItemByIdSpec>(), default(CancellationToken)))
                     .ReturnsAsync(existing);
            var cancellationToken = CancellationToken.None;

            _repoMock.Setup(r => r.UpdateAsync(It.IsAny<TaskItem>(), cancellationToken))
                     .ReturnsAsync(1);

            var updated = new TaskItem { Id = id, Title = "New", TaskItemPriority = TaskItemPriority.High };

            // Act
            await _service.UpdateAsync(updated);

            // Assert
            _repoMock.Verify(r =>
                r.UpdateAsync(
                    It.Is<TaskItem>(t => t.Title == "New" && t.TaskItemPriority == TaskItemPriority.High),
                    cancellationToken),
                Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_DeletesTask()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existing = new TaskItem { Id = id };
            _repoMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<TaskItemByIdSpec>(), default(CancellationToken)))
                     .ReturnsAsync(existing);

            var cancellationToken = CancellationToken.None;
            _repoMock.Setup(r => r.DeleteAsync(It.IsAny<TaskItem>(), cancellationToken))
                     .ReturnsAsync(1);

            // Act
            await _service.DeleteAsync(id);

            // Assert
            _repoMock.Verify(r => r.UpdateAsync(existing, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task ToggleCompletionAsync_TogglesStatus()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existing = new TaskItem { Id = id, TaskItemStatus = TaskItemStatus.Pending };
            _repoMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<TaskItemByIdSpec>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(existing);

            var cancellationToken = CancellationToken.None;
            _repoMock.Setup(r => r.UpdateAsync(It.IsAny<TaskItem>(), cancellationToken))
                     .ReturnsAsync(1);

            // Act
            await _service.ToggleCompletionAsync(id, TaskItemStatus.Completed);

            // Assert
            Assert.Equal(TaskItemStatus.Completed, existing.TaskItemStatus);
            _repoMock.Verify(r => r.UpdateAsync(existing, cancellationToken), Times.Once);
        }
    }
}
