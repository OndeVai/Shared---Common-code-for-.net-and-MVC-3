using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using ronin.Configuration;
using ronin.Net;
using ronin.ServiceModel.Syndication.Model;

namespace ronin.ServiceModel.Syndication
{
    public class YahooTermService : BaseTermService
    {
        #region Overrides of BaseTermService


        /// <summary>
        /// Queries yahoo term extaction web service

        /// </summary>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public override List<Term> ExtractTerms(string context, string query)
        {
            context = HttpUtility.UrlEncode(context);
            var url = ConfigurationUtility.GetAppSetting("yahooTermService.url",
                                                         "http://search.yahooapis.com/ContentAnalysisService/V1/termExtraction");
            var appId = ConfigurationUtility.GetAppSetting("yahooTermService.appId", "WkfrtP70");

            var sbPostData = new StringBuilder();
            sbPostData.AppendFormat("appid={0}&context={1}", appId, context);
            if (!string.IsNullOrWhiteSpace(query))
                sbPostData.AppendFormat("&query={0}", query);

            var responseData = WebUtility.SendPostRequest(url, sbPostData.ToString());


            //sample xml returned
            //<ResultSet xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="urn:yahoo:cate" xsi:schemaLocation="urn:yahoo:cate http://search.yahooapis.com/ContentAnalysisService/V1/TermExtractionResponse.xsd">  
            //  <Result>italian sculptors</Result>  
            //  <Result>virgin mary</Result>  
            //  <Result>painters</Result>  
            //  <Result>renaissance</Result>  
            //  <Result>inspiration</Result>  
            //</ResultSet>

            XNamespace ns = "urn:yahoo:cate";
            var doc = XDocument.Parse(responseData);
            return doc.Descendants(ns + "Result").Select(d => new Term { Content = (string)d }).ToList();



        }

        #endregion


    }
}
