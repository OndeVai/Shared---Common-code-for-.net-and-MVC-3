namespace Shared.Web.Dto
{
    public class JsonResponse
    {
        public bool Success { get; set; }
        public string FatalErrorUrl { get; set; }
        
        private string _validationErrorMessage;

        public JsonResponse()
        {
            Success = true;
        }

        public string ValidationErrorMessage
        {
            get { return _validationErrorMessage; }
            set
            {
                _validationErrorMessage = value;
                Success = string.IsNullOrWhiteSpace(value);
            }
        }

        public object Data { get; set; }
    }
}