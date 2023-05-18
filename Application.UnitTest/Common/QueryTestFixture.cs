using Application.Common.Mappings;
using AutoMapper;
using Infrastructure.Persistence;
using System;

namespace Application.UnitTest.Common
{
    public class QueryTestFixture : IDisposable
    {
        public BrowserTravelTestContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = BrowserTravelTestContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
