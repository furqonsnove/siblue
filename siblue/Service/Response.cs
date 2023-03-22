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
}