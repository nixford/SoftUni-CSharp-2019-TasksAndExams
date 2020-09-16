using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIntro.Controllers
{
    public class DemosController : Controller
    {
        public IActionResult Add()
        {
            return this.View();
        }
    }
}
