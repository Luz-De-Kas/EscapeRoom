using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Skateroom.Services.Bases;

namespace Skateroom.Services;

public class JSElementHTMLService : BaseJSService
{
    public JSElementHTMLService(IJSRuntime jsRunTime) : base(jsRunTime)
    {
    }

    protected override string GetCompletedNameFile() => JSSettings.HTMLElement.FILE_NAME;
    protected override string GetModuleName() => JSSettings.HTMLElement.MODULE_NAME;
    protected override string GetPath() => JSSettings.HTMLElement.PATH;
    public async ValueTask AddClassAsync(ElementReference element, string nameClass) => await this.ModuleInvokeVoidAsync(JSSettings.HTMLElement.Method.addClass, element, nameClass);
    public async ValueTask RemoveClassAsync(ElementReference element, string nameClass) => await this.ModuleInvokeVoidAsync(JSSettings.HTMLElement.Method.removeClass, element, nameClass);
    public async ValueTask<RectangleDimension> GetWindowDimensionsAsync() => await this.ModuleInvokeAsync<RectangleDimension>(JSSettings.HTMLElement.Method.getWindowDimensions);
    public async ValueTask<BoundingClientRect> GetBoundingClientRectAsync(ElementReference element) => await this.ModuleInvokeAsync<BoundingClientRect>(JSSettings.HTMLElement.Method.getRect, element);
    //public async ValueTask ScrollBottomAsync(ElementReference element) => await this.ModuleInvokeVoidAsync(JSSettings.HTMLElement.Method.scrollBottom, element);
}