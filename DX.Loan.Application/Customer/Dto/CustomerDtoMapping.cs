using AutoMapper;
using DX.Loan.DtoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DX.Loan.Customer.Dto
{
    // Customer Info 对应的相关 Mapper
    public class CustomerInfoDtoMapping : IDtoMapping
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
        
        private void CreateMapperIntenal(IMapperConfigurationExpression mapperConfig) {
            var map = mapperConfig.CreateMap<CustomerInfo, CustomerForUserPageDto>().AfterMap((src, dest) => dest.IdCard = src.IdCard.HideIdCard()); //隐藏身份证位数
            map.ForMember(dto => dto.ShowForUserStatus, opt => opt.MapFrom(n => (n.TransTimes??0) < AppConsts.RecordCanSaleTimes ? CustomerStatus.Y.ToString() : CustomerStatus.N.ToString())); //限制出售的次数
        }
        
    }
}
