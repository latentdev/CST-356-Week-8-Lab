using CST_356_Week_7_Lab.Models;
using CST_356_Week_7_Lab.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CST_356_Week_7_Lab.Controllers
{
    [RoutePrefix("api/rest")]
    public class RestController : ApiController
    {
        private IClassService mService;
        public RestController(IClassService service)
        {
            mService = service;
        }
        [Route("~/api/class")]
        [HttpGet]
        public IEnumerable<ClassViewModel> GetAllClasses()
        {
            return mService.GetAllClasses();
        }

        [Route("~/api/class/{id}")]
        [HttpGet]
        public IHttpActionResult GetClass(int id)
        {
            var @class = mService.GetClass(id);
            if (@class == null)
            {
                return NotFound();
            }
            return Ok(@class);
        }

        [Route("~/api/class")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateUser()
        {
            string content = await Request.Content.ReadAsStringAsync();
            var classViewModel = JsonConvert.DeserializeObject<ClassViewModel>(content);
            //classViewModel.ID = null;
            mService.SaveClass(classViewModel);
            return Ok();
        }
    }
}
