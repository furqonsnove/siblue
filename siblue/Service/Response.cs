using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace siblue.Service;

public class Response
{
    public  object Send(string message, object data, int status)
    {
        return new ObjectResult(new
        {
            message,
            data
        }) { StatusCode = status };
    }

    public object SendMessage(string message, int status)
    {
        return new ObjectResult(new
        {
            message
        })
        { StatusCode = status };
    }

    public object SendError(string message, int status)
    {
        return new ObjectResult(new
        {
            message
        })
        { StatusCode = status };
    }
}