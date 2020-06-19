using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TranslatorApi.Models;
using TranslatorApi.Services;

namespace TranslatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslatorController : ControllerBase
    {
        //翻译 
        [HttpGet("translate")]
        public ActionResult<string> GetTranslation(string text, string from, string to)
        {
            TranslationResults results = new TranslationResults();
            try
            {
                if (from == null) from = "auto";
                if (to == null) to = "auto";
                TranslatorService translator = new TranslatorService(text, from, to);
                results = translator.GetTranslationResult();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            Console.WriteLine(JsonConvert.SerializeObject(results));
            return JsonConvert.SerializeObject(results);
        }
    }
}
