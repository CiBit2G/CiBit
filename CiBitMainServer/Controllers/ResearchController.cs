using AutoMapper;
using CiBitMainServer.DBLogic;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using Microsoft.AspNetCore.Mvc;

namespace CiBitMainServer.Controllers
{
    public class ResearchController : Controller
    {
        // INSERT: Research/CreateResearch/CreateResearchRequest
        public bool CreateResearch([FromBody]CreateResearchRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var config = new MapperConfiguration(mc => mc.CreateMap<CreateResearchRequest, ResearchDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<CreateResearchRequest, ResearchDTO>(request);

            var spObj = Converters.CreateResearchConverter(userinfo);
            var reader = context.StoredProcedureSql("CreateReasarch", spObj);

            context.Connection.Close();
            return true;
        }
    }
}