using AutoMapper;
using CiBitMainServer.DBLogic;
using CiBitMainServer.Mapping;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost]
        public GetResearchConfirmListResponse GetAllUsers([FromBody]BaseWebRequest request)
        {

            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            GetUserRequest userRequest = new GetUserRequest
            {
                Token = request.Token,
                CibitId = ciBitId
            };

            var reader = _context.StoredProcedureSql("ResearchConfirmByBank", null);

            GetResearchConfirmListResponse response = new GetResearchConfirmListResponse();

            while (reader.Read())
            {
                response.ResearchConfirmList.Add(new GetResearchConfirmResponse()
                {
                    ReseachName = reader["researchName"].ToString(),
                    CiBitId = reader["cibitId"].ToString(),
                    Status = reader["r_status"].ToString(),
                    DateOfResearch = DateTime.Now  // Add created Date time to research table 
                });
            }

            _context.Connection.Close();
            return response;
        }

    }
}