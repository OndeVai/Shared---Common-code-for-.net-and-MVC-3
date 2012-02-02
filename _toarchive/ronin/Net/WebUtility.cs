#region

using System.IO;
using System.Net;
using System.Text;

#endregion

namespace ronin.Net
{
    public static class WebUtility
    {
        public static string SendPostRequest(string url, string postData)
        {
            // Create a request using a URL that can receive a post. 
            var request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.

            var byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            var dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            var response = request.GetResponse();
            // Display the status.

            string responseData = null;
            // Get the stream containing content returned by the server.
            if (response != null)
            {
                if (((HttpWebResponse) response).StatusDescription != "OK")
                    throw new WebException("Post did not complete successfully");


                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    // Read the content.
                    responseData = reader.ReadToEnd();

                    // Clean up the streams.
                    reader.Close();

                    dataStream.Close();
                }
                response.Close();
            }

            return responseData;
        }
    }
}