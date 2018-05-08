using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Payroll.API.Controllers
{
    public class DepartementsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<DepartementViewModel> Get()
        {
            return DepartementRepo.Get();
        }

        // GET api/<controller>/5
        public DepartementViewModel Get(int id)
        {
            return DepartementRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]DepartementViewModel entity)
        {
            return DepartementRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]DepartementViewModel entity)
        {
            entity.Id = id;
            return DepartementRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return DepartementRepo.Delete(id);
        }
    }
}