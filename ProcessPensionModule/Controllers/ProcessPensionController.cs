using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ProcessPensionModule.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPensionModule.Controllers
{
    [Route("api/ProcessPension")]
    [ApiController]
    [Authorize]
    public class ProcessPensionController : ControllerBase
    {
        private readonly ICallAPIRepository _callAPIREpository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProcessPensionController));

        public ProcessPensionController(ICallAPIRepository callAPIREpository)
        {
            this._callAPIREpository = callAPIREpository;
        }

        //[HttpGet("[action]/{aadharNumber}")]
        //public async Task<IActionResult> GetPensionerDetails(string aadharNumber)
        //{
        //    var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

        //    _log4net.Info(" Http Get Request From GetPensionerDetails method of: " + nameof(ProcessPensionController));
        //    var result = await _callAPIREpository.GetPensionerDetailAsync(aadharNumber, token);

        //    if (result != null)
        //    {
        //        _log4net.Info(" Return OK result From GetPensionerDetails method of: " + nameof(ProcessPensionController));
        //        return Ok(result);
        //    }
        //    _log4net.Warn(" Badrequest returned from Http GET Request From GetPensionerDetails method of: " + nameof(ProcessPensionController));
        //    return BadRequest();
        //}

        [HttpPost("[action]/{aadharNumber}")]
        public async Task<IActionResult> PensionerDetail(string aadharNumber)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            _log4net.Info(" Http POST Request From PensionerDetail method of: " + nameof(ProcessPensionController));
            var result = await _callAPIREpository.GetPensionerDetailAsync(aadharNumber, token);

            if (result==null)
            {
                _log4net.Warn(" Badrequest returned from Http POST Request From PensionerDetail method of: " + nameof(ProcessPensionController));
                return BadRequest(new {message="Error Ocurred!!"});
            }
            var pensionerDetail = result;

            _log4net.Info(" API call Request to Repository for Calculation From PensionerDetail method of: " + nameof(ProcessPensionController));
            var res = _callAPIREpository.CalculatePensionDetail(pensionerDetail);

            _log4net.Info(" API call Request to Repository for saving From PensionerDetail method of: " + nameof(ProcessPensionController));
            await _callAPIREpository.SaveDataAsync(token);

            _log4net.Info(" API call Request to Repository for update result From PensionerDetail method of: " + nameof(ProcessPensionController));
            await _callAPIREpository.Update(res);

            _log4net.Info(" Return OK result From GetPensionerDetail method of: " + nameof(ProcessPensionController));
            return Ok(res);
        }
    }
}
