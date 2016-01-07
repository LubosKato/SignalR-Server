using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;

namespace Messenger.Server
{
    [RoutePrefix("")]
    public class VersionController : ApiController
    {

        /// <summary>
        /// Gets the list of ascend snapshots.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(string))]
        [HttpGet]
        [Route()]
        public IHttpActionResult GetAscendSnapshots()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return Ok(new
            {
                Name = fvi.FileDescription,
                Company = fvi.CompanyName,
                Copyright = fvi.LegalCopyright,
                Version = fvi.FileVersion
            });
        }

    }
}
