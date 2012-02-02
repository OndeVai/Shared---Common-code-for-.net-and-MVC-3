#region

using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using ronin.Domain.Validation;

#endregion

namespace ronin.ServiceModel.Web
{
    public abstract class BaseRestProxy<TService> where TService : class
    {
        protected BaseRestProxy(string remoteServiceAddress)
            : this(remoteServiceAddress, null)
        {
        }

        protected BaseRestProxy(string remoteServiceAddress, string remoteServiceAddressSecure)
        {
            var binding = new WebHttpBinding
                              {
                                  MaxReceivedMessageSize = Int32.MaxValue,
                                  ReaderQuotas =
                                      {
                                          MaxStringContentLength = Int32.MaxValue,
                                          MaxArrayLength = Int32.MaxValue
                                      }

                              };
            //binding.Security.Mode = WebHttpSecurityMode.None;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            var cf = new WebChannelFactory<TService>(binding, new Uri(remoteServiceAddress));
            Service = cf.CreateChannel();

            if (!string.IsNullOrWhiteSpace(remoteServiceAddressSecure))
            {
                SetCertPolicy();
                var secureBinding = new WebHttpBinding(WebHttpSecurityMode.Transport) { SendTimeout = new TimeSpan(1, 60, 0) };
                var cf1 = new WebChannelFactory<TService>(secureBinding, new Uri(remoteServiceAddressSecure));
                ServiceSecured = cf1.CreateChannel();
            }
        }

        protected TService Service { get; private set; }
        protected TService ServiceSecured { get; private set; }

        protected void HandleServiceError<TModel>(Exception ex)
        {
            if (ex is ProtocolException)
            {
                var webEx = ex.InnerException as WebException;

                if (webEx != null && webEx.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = webEx.Response as HttpWebResponse;
                    if (response != null && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        //re-constitute as business rule exception for the client
                        var rulesException = new RulesException<TModel>();
                        var rules = response.StatusDescription.Split(char.Parse(ErrorConstants.ErrorSeparator));
                        foreach (var nameVal in
                            rules.Select(rule => rule.Split(char.Parse(ErrorConstants.PropertySeparator))))
                        {
                            rulesException.ErrorFor(nameVal[0], nameVal[1]);
                        }
                        throw rulesException;
                    }
                }
            }

            throw new Exception(ex.Message, ex);
        }

        protected static void SetCertPolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertValidate;
        }

        private static bool RemoteCertValidate(object sender, X509Certificate cert, X509Chain chain,
                SslPolicyErrors error)
        {
            // trust any cert!!!
            return true;
        }

    }
}