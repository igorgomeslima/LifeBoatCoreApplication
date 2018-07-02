using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeBoatCoreApplication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeBoatCoreApplication.Pages
{
    public class DefaultResponse : PageModel
    {
        private readonly IDefaultResponse _defaultResponse;
        public string CurrentDefaultResponse { get; set; }
        public DefaultResponse(IDefaultResponse defaultResponse)
        {
            _defaultResponse = defaultResponse;
        }
        public void OnGet(string name)
        {
            CurrentDefaultResponse = $"{name} : {_defaultResponse.GetDefaultResponse()}";
        }
    }
}