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
    public class SampleController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        public SampleController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        static readonly LocalizedStringKey ErrorKey = new LocalizedStringKey("This is an error");

        [HttpGet("error")]
        public void Error()
        {
            throw new LocalizedException(_translationService.Create(ErrorKey));
        }

        static readonly LocalizedStringKey InformationKey = new LocalizedStringKey("This is a information");

        [HttpGet("information")]
        public ILocalizedString Information()
        {
            return _translationService.Create(InformationKey);
        }
    }
}
