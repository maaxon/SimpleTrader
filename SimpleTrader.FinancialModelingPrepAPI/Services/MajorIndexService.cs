using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly FinancialModelingPrepHttpClient _client;

        public MajorIndexService(FinancialModelingPrepHttpClient client)
        {
            _client = client;
        }

        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            string uri = "majors-indexes/";

            List<MajorIndex> majorIndexs = await _client.GetAsync<List<MajorIndex>>(uri);
            var majorIndex = majorIndexs[GetUriSuffix(indexType)];
            majorIndex.Type = indexType;

            return majorIndex;
        }

        private int GetUriSuffix(MajorIndexType indexType)
        {
            switch(indexType)
            {
                case MajorIndexType.DowJones:
                    return 0;
                case MajorIndexType.Nasdaq:
                    return 1;
                case MajorIndexType.SP500:
                    return 2;
                default:
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}