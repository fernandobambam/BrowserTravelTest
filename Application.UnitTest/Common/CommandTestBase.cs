using Infrastructure.Persistence;
using System;

namespace Application.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly BrowserTravelTestContext _context;

        public CommandTestBase()
        {
            _context = BrowserTravelTestContextFactory.Create();
        }

        public void Dispose()
        {
            BrowserTravelTestContextFactory.Destroy(_context);
        }
    }
}
