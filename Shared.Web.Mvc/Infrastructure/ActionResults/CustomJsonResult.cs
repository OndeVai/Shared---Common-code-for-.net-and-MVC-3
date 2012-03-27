using System.Web.Mvc;
using Shared.Web.Dto;

namespace Shared.Web.Mvc.Infrastructure.ActionResults
{
    public class CustomJsonResult : ActionResult
    {
        private readonly string _validationErrorMessage;
        private readonly object _data;

        public CustomJsonResult(object data)
        {
            _data = data;
        }

        public CustomJsonResult(string validationErrorMessage)
        {
            _validationErrorMessage = validationErrorMessage;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = new JsonResponse { Data = _data, ValidationErrorMessage = _validationErrorMessage };
            var json = new JsonResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            json.ExecuteResult(context);
        }
    }
}