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
        private readonly CibitDb _context;

        public ResearchController(CibitDb context)
        {
            _context = context;
        }

        // INSERT: Research/CreateResearch/CreateResearchRequest
        public bool CreateResearch([FromBody]CreateResearchRequest request)
        {
            var userinfo = TypeMapper.Mapper.Map<CreateResearchRequest, ResearchDTO>(request);

            var spObj = Converters.CreateResearchConverter(userinfo);
            var reader = _context.StoredProcedureSql("CreateReasarch", spObj);

            _context.Connection.Close();
            return true;
        }
    }
}