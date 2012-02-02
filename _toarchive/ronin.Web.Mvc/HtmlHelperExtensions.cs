#region

using System.Configuration;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using Recaptcha;

#endregion

namespace ronin.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static string GenerateCaptcha(this HtmlHelper helper, string theme = "white")
        {
            var captchaControl = new RecaptchaControl
                                     {
                                         ID = "recaptcha",
                                         Theme = theme,
                                         PublicKey = ConfigurationManager.AppSettings["recaptcha.key.public"],
                                         PrivateKey = ConfigurationManager.AppSettings["recaptcha.key.private"]
                                     };

            var htmlWriter = new HtmlTextWriter(new StringWriter());

            captchaControl.RenderControl(htmlWriter);

            return htmlWriter.InnerWriter.ToString();
        }
    }
}