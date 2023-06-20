using Microsoft.AspNetCore.Http;

namespace SmellIt.Application.Helpers;

public class Session
{
    public static string GetSession(HttpContext httpContext)
    {
        if (httpContext.Session.GetString("SessionId") == null)
        {
            if (!string.IsNullOrEmpty(httpContext.User.Identity?.Name))
            {
                SetSessionWhenUserIsLogged(httpContext, httpContext.User.Identity.Name);
            }
            else
            {
                Guid tempSessionId = Guid.NewGuid();
                httpContext.Session.SetString("SessionId", tempSessionId.ToString());
            }
        }
        return httpContext.Session.GetString("SessionId")!;
    }

    public static void SetSessionWhenUserIsLogged(HttpContext httpContext, string sessionId)
    {
        httpContext.Session.SetString("SessionId", sessionId);
    }
}