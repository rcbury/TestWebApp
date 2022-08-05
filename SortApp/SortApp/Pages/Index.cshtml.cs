using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SortApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var temp = Request.Query["collection"].ToString().Split(',');
            var tstr = "";
            foreach (var item in temp)
            {
                tstr += $"<li>{item}</li>";
            }
            ViewData["collection"] = tstr;
            if (!String.IsNullOrEmpty(Request.Query["collection"].ToString())) 
            {
                MyList newList = new MyList(Request.Query["collection"].ToString());
                newList.Sort(Request.Query["sort"].ToString());
                tstr = "";
                foreach (var item in newList.Sorted)
                {
                    tstr += $"<li>{item}</li>";
                }
                ViewData["sorted"] = tstr;
            }
        }
    }
}
