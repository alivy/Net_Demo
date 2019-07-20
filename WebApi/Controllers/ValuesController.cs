using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        /// <summary>
        /// 这是一个Post测试
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<object> GetJsonValue([FromBody]InputValue para)
        {

            string ss = "http://localhost:11388/api/Values/GetJsonValue";
            return Json<object>(para);
        }
        /// <summary>
        /// 这是一个Post测试
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<object> GetJson(int ids)
        {
            InputValue para = new InputValue()
            {
                Id = ids,
                Name = "测试"
            };
            string ss = "http://localhost:11388/api/Values/GetJsonValue";
            return Json<object>(para);
        }


        /// <summary>
        /// 这是一个Post测试
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult<object> GetJsonTo(string name)
        {
            InputValue para = new InputValue()
            {
                Id = 10,
                Name = name
            };
            string ss = "http://localhost:11388/api/Values/GetJsonValue";
            return Json<object>(para);
        }
    }

    /// <summary>
    /// 传入参数
    /// </summary>
    public class InputValue
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
