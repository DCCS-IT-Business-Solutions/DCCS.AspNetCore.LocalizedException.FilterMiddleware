using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCCS.LocalizedString.NetStandard;
using Microsoft.AspNetCore.Mvc;

namespace DCCS.AspNetCore.LocalizedString.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        public ValuesController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        static readonly LocalizedStringKey Error = new LocalizedStringKey("This is an error");

        [HttpGet()]
        public void LocalizedException()
        {
            throw new LocalizedException(_translationService.Create(Error));
        }
    }
}
