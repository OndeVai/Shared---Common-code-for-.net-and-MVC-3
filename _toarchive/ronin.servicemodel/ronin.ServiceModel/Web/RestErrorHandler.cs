#region

using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using ronin.Domain.Validation;
using ronin.ServiceModel.Errors;

#endregion

namespace ronin.ServiceModel.Web
{
    public class RestErrorHandler : IErrorHandler
    {
        #region Implementation of IErrorHandler

        public void HandleRequestViolationException(RulesException rulesException)
        {
            var rulesFormatted =
                rulesException.Errors.Select(
                    v => string.Format("{0}{2}{1}", v.GetPropertyName(), v.Message, ErrorConstants.PropertySeparator));
            var message = string.Join(ErrorConstants.ErrorSeparator, rulesFormatted);
            HandleWebFault(message, HttpStatusCode.BadRequest, rulesException);

            throw rulesException;
        }

        public void HandleSystemException(Exception exception)
        {
            HandleWebFault(
                "An unexpected server error occured. Our technical staff has been notified.",
                HttpStatusCode.InternalServerError, new Exception("Internal Error"), false);

            throw exception;

        }

        private static void HandleWebFault(string message, HttpStatusCode statusCode, Exception origException, bool rethrow = true)
        {
            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusDescription = message;

                if (rethrow)
                    throw new WebFaultException<string>(string.Format("{0}::{1}", message, origException), statusCode);

                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
            }

        }

        #endregion
    }
}