using System.Web.Mvc;
using Shared.Web.Dto;

namespace Shared.Web.Mvc.Infrastructure.ActionResults
{
    public class CustomJsonResult : ActionResult
    {
        private readonly string _validationErrorMessage;
        private readonly string _fatalErrorUrl;
        private readonly object _data;

        public CustomJsonResult(object data)
        {
            _data = data;
        }

        public CustomJsonResult(string validationErrorMessage, string fatalErrorUrl)
        {
            _validationErrorMessage = validationErrorMessage;
            _fatalErrorUrl = fatalErrorUrl;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = new JsonResponse
                               {
                                   FatalErrorUrl = _fatalErrorUrl,
                                   ValidationErrorMessage = _validationErrorMessage,
                                   Data = _data, Success = string.IsNullOrWhiteSpace(_validationErrorMessage)
                               };
            var json = new JsonResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            json.ExecuteResult(context);
        }
    }
}