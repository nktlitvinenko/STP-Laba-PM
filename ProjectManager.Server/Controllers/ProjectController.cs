using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using ProjectManager.Common.DAL;
using ProjectManager.Entity;

namespace ProjectManager.Server.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        private IDataBaseFacade _dataBaseFacade;

        public ProjectController(IDataBaseFacade dataBaseFacade)
        {
            _dataBaseFacade = dataBaseFacade;
        }

        // GET: api/Project
        public JsonResult<List<Project>> Get()
        {
            return Json(_dataBaseFacade.GetAll<Project>().Select(p=> new Project {Name = p.Name, Id=p.Id,}).ToList());
        }

        // GET: api/Project/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Project
        public void Post([FromBody]string value)
        {
            var proj = JsonConvert.DeserializeObject<Project>(value);
            var entity = new Project()
            {
                Name = proj.Name,
                Description = proj.Description
            };
            _dataBaseFacade.Add<Project>(entity);
            _dataBaseFacade.Save<Project>();
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Project/5
        public void Delete(string id)
        {
            _dataBaseFacade.Delete<Project>(id);
            _dataBaseFacade.Save<Project>();
        }
    }
}
