using Autocompletion.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AutocompletionWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AutocompletionController : Controller
    {
        private readonly ISearcherAutocompletion _searcherAutocompletion;

        public AutocompletionController(ISearcherAutocompletion searcherAutocompletion)
        {
            _searcherAutocompletion = searcherAutocompletion;
        }


        [Route("search/{expression}")]
        [HttpGet]
        public IActionResult Search(string expression)
        {
            try
            {
                return Ok(_searcherAutocompletion.SearchAutocompletion(expression));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("update")]
        [HttpPost]
        public IActionResult UpdateDate()
        {
            try
            {
                _searcherAutocompletion.UpdateData();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
