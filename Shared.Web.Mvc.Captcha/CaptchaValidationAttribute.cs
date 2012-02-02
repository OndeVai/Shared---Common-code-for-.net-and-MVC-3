#region

using System.Configuration;
using System.Web.Mvc;
using Recaptcha;

#endregion

namespace Shared.Web.Mvc.Captcha
{
    public class CaptchaValidationAttribute : ActionFilterAttribute
    {
        private const string CHALLENGE_FIELD_KEY = "recaptcha_challenge_field";
        private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";

        private readonly string _markerProperty;
        private readonly string _validationMessage = "Your text does not match the Recaptcha values.";

        public CaptchaValidationAttribute()
            : this(null, "Recaptcha")
        {
        }

        public CaptchaValidationAttribute(string validationMessage, string markerProperty)
        {
            if (!string.IsNullOrWhiteSpace(validationMessage))
                _validationMessage = validationMessage;

            _markerProperty = markerProperty;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[CHALLENGE_FIELD_KEY];
            var captchaResponseValue = filterContext.HttpContext.Request.Form[RESPONSE_FIELD_KEY];
            var captchaValidtor = new RecaptchaValidator
                                      {
                                          PrivateKey = ConfigurationManager.AppSettings["recaptcha.key.private"],
                                          RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                                          Challenge = captchaChallengeValue,
                                          Response = captchaResponseValue
                                      };

            var recaptchaResponse = captchaValidtor.Validate();

            // this will push the result value into a parameter in our Action  
            filterContext.ActionParameters["captchaValid"] = recaptchaResponse.IsValid;

            //add validation
            if (!recaptchaResponse.IsValid)
            {
                filterContext.Controller.ViewData.ModelState.AddModelError(_markerProperty, _validationMessage);
            }


            base.OnActionExecuting(filterContext);
        }
    }
}