namespace TLbankInfra.ExceptionsCustomize;

public class HttpResponseException:Exception
{
    public HttpResponseException(int statusCode, object? value = null, string? message = "") : base(message)
    {
        StatusCode = statusCode;
        Value = value;
    }
    public int StatusCode { get; }
    public object? Value { get; }
}