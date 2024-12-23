namespace BP215API.Exceptions
{
    public interface IBaseException
    {
        int StatusCode { get; set; }
        string ErrorMessage { get; set; }
    }
}
