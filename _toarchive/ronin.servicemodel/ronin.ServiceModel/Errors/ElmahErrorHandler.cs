#region

using System;
using System.ServiceModel.Channels;
using System.Web;
using Elmah;

#endregion

namespace ronin.ServiceModel.Errors
{
    public class ElmahErrorHandler : System.ServiceModel.Dispatcher.IErrorHandler
    {
        #region IErrorHandler Members

        public bool HandleError(Exception error)
        {
            return false;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error == null)
                return;
            if (HttpContext.Current == null) //In case we run outside of IIS
                return;
            ErrorSignal.FromCurrentContext().Raise(error);
        }

        #endregion
    }
}