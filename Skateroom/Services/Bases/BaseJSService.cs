using Microsoft.JSInterop;
using System.Runtime;

namespace Skateroom.Services.Bases;

public abstract class BaseJSService : IAsyncDisposable
{

    protected readonly IJSRuntime _jsRunTime;
    protected IJSObjectReference? _module;

    public BaseJSService(IJSRuntime jsRunTime)
    {
        _jsRunTime = jsRunTime;
    }
    protected abstract string GetPath();
    protected abstract string GetCompletedNameFile();
    protected abstract string GetModuleName();
    protected virtual double GetTimeForCancellationTokenSource() => JSSettings.TIME_IN_SECONDS_FOR_CANCELATION_TOKEN;

    protected string JSMethod(string nameMethod) => $"{this.GetModuleName()}.{nameMethod}";
    protected CancellationToken GetCancelationToken => (new CancellationTokenSource(TimeSpan.FromSeconds(GetTimeForCancellationTokenSource()))).Token;
    protected async ValueTask ImportModuleAsync()
    {
        try
        {
            _module ??= await _jsRunTime.InvokeAsync<IJSObjectReference>("import", this.GetCancelationToken, $"{this.GetPath()}/{this.GetCompletedNameFile()}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error en la importación de los ficheros correspondientes al diagrama: {ex.Message}");
        }
    }
    protected async ValueTask ModuleInvokeVoidAsync(string jsMethod, params object[] parameters)
    {
        try
        {
            if (_module is null)
            {
                await this.ImportModuleAsync();
            }
            if (parameters is null || !parameters.Any())
            {
                await _module!.InvokeVoidAsync(JSMethod(jsMethod), GetCancelationToken);
            }
            else
            {
                await _module!.InvokeVoidAsync(JSMethod(jsMethod), GetCancelationToken, parameters);
            }
        }
        catch (Exception ex)
        {
            ManageExceptions(new Exception($"{ex.Message}. Error method: {jsMethod}"));
        }
    }
    protected async ValueTask<TResult> ModuleInvokeAsync<TResult>(string jsMethod, params object[] parameters)
    {
        var result = default(TResult);
        try
        {
            if (_module is null)
            {
                await this.ImportModuleAsync();
            }
            if (parameters is null || !parameters.Any())
            {
                result = await _module!.InvokeAsync<TResult>(JSMethod(jsMethod), GetCancelationToken);
            }
            else
            {
                result = await _module!.InvokeAsync<TResult>(JSMethod(jsMethod), GetCancelationToken, parameters);
            }
        }
        catch (Exception ex)
        {
            ManageExceptions(new Exception($"{ex.Message}. Error method: {jsMethod}"));
        }
        return result;
    }
    protected async ValueTask<TResult[]> ModuleInvokeParamsAsync<TResult>(string jsMethod, params object[] parameters)
    {
        var result = default(TResult[]);
        try
        {
            if (_module is null)
            {
                await this.ImportModuleAsync();
            }
            if (parameters is null || !parameters.Any())
            {
                result = await _module!.InvokeAsync<TResult[]>(JSMethod(jsMethod), GetCancelationToken);
            }
            else
            {
                result = await _module!.InvokeAsync<TResult[]>(JSMethod(jsMethod), GetCancelationToken, parameters);
            }
        }
        catch (Exception ex)
        {
            ManageExceptions(new Exception($"{ex.Message}. Error method: {jsMethod}"));
        }
        return result;
    }

    public void ManageExceptions(Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
        throw ex;
    }
    public ValueTask DisposeAsync()
    {
        if (_module != null)
        {
            return _module.DisposeAsync();
        }
        return new ValueTask(Task.CompletedTask);
    }
}


public static partial class JSSettings
{
    public const int TIME_IN_SECONDS_FOR_CANCELATION_TOKEN = 4;
}

public static partial class JSSettings
{
    public static class HTMLElement
    {
        public const string FILE_NAME = "html_element.js";
        public const string MODULE_NAME = "html_element";
        public const string PATH = "./js/modules";

        public static class Method
        {
            public const string addClass = "addClass";
            public const string removeClass = "removeClass";
            public const string getWindowDimensions = "getWindowDimensions";
            public const string getRect = "getRect";
        }
    }
    public static class Audio
    {
        public const string FILE_NAME = "audio.js";
        public const string MODULE_NAME = "audio";
        public const string PATH = "./js/modules";
        public static class Method
        {
            public const string play = "play";
            public const string play_during = "play_during";
        }
        public static class NameFile 
        {
            public const string YMCA = "01 - YMCA (Remix).mp3";
            public const string THIRTY_MINUTES = "AUDIO LAURA 30 MINUTOS SALIDA.mp3";
            public const string FIVE_MINUTES = "AUDIO LAURA 5 MINUTOS SALIDA.mp3";
            public const string HOUSTON_PROBLEM = "AUDIO LAURA HOUSTON TENEMOS UN PROBLEMA.mp3";
            public const string CORRECT_ANSWER = "FX ACIERTO.mp3";
            public const string FAIL_ANSWER = "FX ERROR 1.mp3";
            public const string TRY_POWER_ON = "TRATA DE ARRANCARLO.mp3";

        }
        public const string DIRECTION_FILE = "audios/";
        public const int TIME_ALARM = 3000;
    }
}
