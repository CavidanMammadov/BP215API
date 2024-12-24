namespace BP215API.Exceptions
{
    public interface IBaseException
    {
        int StatusCode { get;  }
        string ErrorMessage { get; }
    }
}
