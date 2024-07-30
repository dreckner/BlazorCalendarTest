using Microsoft.AspNetCore.Components;

namespace BlazorCalendarTest.Blazor
{
 
public class RenderModeProvider(Csla.AspNetCore.Blazor.ActiveCircuitState activeCiruitState)
{
    public string GetRenderMode(ComponentBase page)
    {
        string result;
        var isBrowser = OperatingSystem.IsBrowser();
        if (isBrowser)
        {
            result = "wasm-interactive";
        }
        else if (activeCiruitState.CircuitExists)
        {
            result = "server-interactive";
        }
        else if (page.GetType().GetCustomAttributes(typeof(StreamRenderingAttribute), true).Length > 0)
        {
            result = "server-static (streaming)";
        }
        else 
        {
            result = "server-static";
        }
        return result;
    }
}
}