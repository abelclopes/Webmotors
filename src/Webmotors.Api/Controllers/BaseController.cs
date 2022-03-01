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
        protected async Task<IActionResult> GetResponseAsync<T>(Task<T> _model)
        {
            var statusCode = (int)_model.Status;
            if (statusCode == 500) return BadRequest(_model);

            return Ok(_model.Result);
        }
    }
}
