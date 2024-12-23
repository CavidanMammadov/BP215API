namespace BP215API.Exceptions.Languages
{
    public class LanguageExistException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status409Conflict;
        public string ErrorMessage { get; }
        int IBaseException.StatusCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IBaseException.ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public LanguageExistException()
        {
            ErrorMessage = "Dil movcuddur";
        }
        public LanguageExistException(string? message):base(message)
        {
            ErrorMessage = message;
        }
    }
}
