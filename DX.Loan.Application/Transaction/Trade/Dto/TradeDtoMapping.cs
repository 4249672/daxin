using AutoMapper;
using DX.Loan.DtoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DX.Loan.Transaction.Trade.Dto
{
    public class TradeDtoMapping : IDtoMapping
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        public void CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }
                CreateMapperIntenal(mapperConfig);
                _mappedBefore = true;
            }
        }

        private void CreateMapperIntenal(IMapperConfigurationExpression mapperConfig)
        {
            var map = mapperConfig.CreateMap<FinanceTradeDetail, TradeDetailsDto>(); 
            map.ForMember(dto => dto.TradeType, opt => opt.MapFrom(n => typeof(TradeType).GetDescription(n.TradeType)));

            var map2 = mapperConfig.CreateMap<FinanceTradeDetail, TradeDetailsForUserDto>();
            map2.ForMember(dto => dto.TradeType, opt => opt.MapFrom(n => typeof(TradeType).GetDescription(n.TradeType)));


        }

    }
}
