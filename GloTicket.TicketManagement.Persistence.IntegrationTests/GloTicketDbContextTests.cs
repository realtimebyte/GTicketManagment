using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
namespace GloTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloTicketDbContextTests
    {
        private readonly GloboTicketDbContext _globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _loggedInUserId = "0000000000-0000-0000-0000-0000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);

        }
    }
}
