using AutoMapper;
using CiBitMainServer.DBLogic;
using CiBitMainServer.Mapping;
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

            var userinfo = TypeMapper.Mapper.Map<CreateResearchRequest, ResearchDTO>(request);

            var spObj = Converters.CreateResearchConverter(userinfo);
            var reader = context.StoredProcedureSql("CreateReasarch", spObj);

            context.Connection.Close();
            return true;
        }
    }
}