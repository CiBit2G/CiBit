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

        // POST: Research/CreateResearch/CreateResearchRequest
        [HttpPost]
        public CreateResearchResponse CreateResearch([FromBody]CreateResearchRequest request)
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
            var response = new CreateResearchResponse();
            var userinfo = TypeMapper.Mapper.Map<CreateResearchRequest, ResearchDTO>(request);
            userinfo.CiBitId = userRequest.CibitId;

            var spObj = Converters.CreateResearchConverter(userinfo);
            var reader = _context.StoredProcedureSql("CreateResearch", spObj);

            _context.Connection.Close();
            response.IsSuccessful= true;
            response.Token = Tokens.CreateToken(userinfo.CiBitId);

            return response;
        }

        [HttpPost]
        public GetResearchConfirmListResponse GetAllResearchs([FromBody]BaseWebRequest request)
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

            var bankInfo = TypeMapper.Mapper.Map<GetUserRequest, BankDTO>(userRequest);
            var spObj = Converters.GetBankConverter(bankInfo);
            var reader = _context.StoredProcedureSql("ResearchConfirmByBank", spObj);

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

        [HttpPost]
        public GetResearchListResponse GetAllUserResearchs([FromBody] GetResearchListRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            var userInfo = TypeMapper.Mapper.Map<GetResearchListRequest, UserDTO>(request);
            var spObj = Converters.GetUserConverter(userInfo);
            var reader = _context.StoredProcedureSql("GetResearchListByUser", spObj);

            GetResearchListResponse response = new GetResearchListResponse();

            while (reader.Read())
            {
                response.ResearchNamesList.Add(
                
                    reader["researchId"].ToString(),
                    reader["researchName"].ToString()
                );
            }

            _context.Connection.Close();
            return response;
        }
    }
}
