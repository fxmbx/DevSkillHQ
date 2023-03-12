namespace DevSkillHQ_BE.CustomException
{
    public class ReuseableCustomException : Exception
    {
        private int statusCode = 500;
        public ReuseableCustomException() { }

        public ReuseableCustomException(string message, int code)
            : base(message)
        {
            SetStatusCode(code);
        }

        public void SetStatusCode(int code)
        {
            statusCode = code;
        }
        public int GetStatusCode()
        {
            return statusCode;
        }
    }
}