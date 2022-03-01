using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webmotors.Repository.Api.Controllers
{
    public class BaseController : ControllerBase
    {

        //"exception": null,
        //"status": 5,
        //"isCanceled": false,
        //"isCompleted": true,
        //"isCompletedSuccessfully": true,
        //"creationOptions": 0,
        //"asyncState": null,
        //"isFaulted": false
        protected IActionResult GetResponse<T>(Task<T> _model)
        {
            try
            {
                var statusCode = (int)_model.Status;
                if (statusCode == 500) return BadRequest(_model);

                return Ok(_model.Result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
