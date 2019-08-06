using Moq;
using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using Xunit;

namespace Test
{
    public class Test
    {
        [Fact]
        public async Task TestRoomController()
        {
            var mockRepo = new Mock<IDatabaseService>();
            mockRepo.Setup(repo => repo.RoomModel.Get(new API.Models.Room()))
                .ReturnsAsync(new List<IRoom>());
            var controller = new RoomController(mockRepo.Object);
            var result = await controller.Get(new API.Models.Room());
        }
    }
}
