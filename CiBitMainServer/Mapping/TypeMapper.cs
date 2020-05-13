using AutoMapper;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.Mapping
{
    public static class TypeMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
            // This line ensures that internal properties are also mapped over.
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Transaction
            CreateMap<GetTransactionRequest, TransactionDTO>();
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<AddTransactionRequest, TransactionDTO>();
            CreateMap<RemoveCoinRequest, TransactionDTO>();
            CreateMap<GetHashRequest, TransactionDTO>();
            CreateMap<SetHashRequest, TransactionDTO>();
            CreateMap<GetCoinRequest, TransactionDTO>();
            CreateMap<GetAllCoinsRequest, TransactionDTO>();
            #endregion

            #region Research
            CreateMap<CreateResearchRequest, ResearchDTO>();
            #endregion

            #region User
            CreateMap<GetUserRequest, UserDTO>();
            CreateMap<CreateUserRequest, UserDTO>();
            CreateMap<RemoveUserRequest, UserDTO>();
            CreateMap<GetUserRequest, UserDTO>();
            #endregion
        }
    }
}
