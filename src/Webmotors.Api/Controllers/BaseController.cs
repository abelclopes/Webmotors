using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webmotors.Repository.Api.Controllers
{
    public class BaseController : ControllerBase
    {

        protected IActionResult GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
