using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Skateroom.Services.Bases;

namespace Skateroom.Services;

public class JSAudioService : BaseJSService
{
    public JSAudioService(IJSRuntime jsRunTime) : base(jsRunTime)
    {
    }

    protected override string GetCompletedNameFile() => JSSettings.Audio.FILE_NAME;
    protected override string GetModuleName() => JSSettings.Audio.MODULE_NAME;
    protected override string GetPath() => JSSettings.Audio.PATH;
    public async Task PlayAsync(string audioFile) => await base.ModuleInvokeVoidAsync(JSSettings.Audio.Method.play, audioFile);
    public async Task PlayDuringAsync(string audioFile, int timeInMiliSeconds) => await base.ModuleInvokeVoidAsync(JSSettings.Audio.Method.play_during, audioFile, timeInMiliSeconds);
    public async Task PlayThirtyMinutesAsync() => await this.PlayAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.THIRTY_MINUTES}");
    public async Task PlayFiveMinutesAsync() => await this.PlayAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.FIVE_MINUTES}");
    public async Task PlayHoustonProblemAsync() => await this.PlayAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.HOUSTON_PROBLEM}");
    public async Task PlayCorrectAnswerAsync() => await this.PlayAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.CORRECT_ANSWER}");
    public async Task PlayFailAnswerAsync() => await this.PlayAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.FAIL_ANSWER}");
    public async Task PlayTryPowerOnAsync() => await this.PlayAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.TRY_POWER_ON}");
    public async Task PlayAlarmAsync() => await this.PlayDuringAsync($"{JSSettings.Audio.DIRECTION_FILE}{JSSettings.Audio.NameFile.THIRTY_MINUTES}", JSSettings.Audio.TIME_ALARM);

}