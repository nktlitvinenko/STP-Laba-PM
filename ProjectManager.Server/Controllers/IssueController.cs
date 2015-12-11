using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.Server.Controllers
{
    public class IssueController : ApiController
    {
        private IDataBaseFacade _dataBaseFacade;
        private IIssueRepository _issueRepository;

        public IssueController(IDataBaseFacade dataBaseFacade, IIssueRepository issueRepository)
        {
            _dataBaseFacade = dataBaseFacade;
            _issueRepository = issueRepository;
        }

        // GET: api/Issue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public JsonResult<List<Issue>> GetByProjectId(string projectId)
        {
            return Json(_dataBaseFacade.GetBy<Issue>(i=>i.Project.Id==new Guid(projectId)).Select(
                i=> new Issue
                {
                    Name = i.Name, 
                    Id = i.Id, 
                    Created = i.Created,
                    Updated = i.Updated,
                    Status = i.Status,
                    Type = i.Type,
                    Priority = i.Priority
                }).ToList());
        } 
        [HttpGet]
        // GET: api/Issue/5
        public JsonResult<Issue> Get(string issueId)
        {
            return Json(_issueRepository.GetFullIssueById(new Guid(issueId)).Single());
        }

        // POST: api/Issue
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Issue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Issue/5
        public void Delete(int id)
        {
        }
    }
}
