using Microsoft.Extensions.Logging;

namespace Tegu.Net.Shared.Helper.Extensions;

public static class LoggerExtensions
{
    public static void LogError(this ILogger logger, Exception e)
    {
        logger.LogError(e.Message, e);
    }

    public static void LogError<T>(this ILogger<T> logger, Exception e)
    {
        logger.LogError(e.Message, e);
    }
    public static void LogCritical<T>(this ILogger<T> logger, Exception e)
    {
        logger.LogCritical(e.Message, e);
    }
}
