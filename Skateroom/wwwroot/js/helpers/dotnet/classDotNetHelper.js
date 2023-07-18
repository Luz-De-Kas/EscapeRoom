
////////////////////////////
////////// IMPORTS /////////
///////////////////////////

import { settings } from '../../settings/settings.js';

///////////////////////////////////////////////
/////////////class DotNet Helper //////////////
//////////////////////////////////////////////

class DotNetHelper {

    static CallDotNet1Parameters = async (methodInvoked) => await DotNet.invokeMethodAsync(settings.PROYECT_NAME, methodInvoked);

    static CallDotNet2Parameters = async (methodInvoked, itemParameter) => await DotNet.invokeMethodAsync(settings.PROYECT_NAME, methodInvoked, itemParameter);

    static CallDotNet3Parameters = async (methodInvoked, itemParameter1, itemParameter2) => await DotNet.invokeMethodAsync(settings.PROYECT_NAME, methodInvoked, itemParameter1, itemParameter2);
    static CallDotNet4Parameters = async (methodInvoked, itemParameter1, itemParameter2, itemParameter3) => await DotNet.invokeMethodAsync(settings.PROYECT_NAME, methodInvoked, itemParameter1, itemParameter2, itemParameter3);
    static CallDotNet5Parameters = async (methodInvoked, itemParameter1, itemParameter2, itemParameter3, itemParameter4) => await DotNet.invokeMethodAsync(settings.PROYECT_NAME, methodInvoked, itemParameter1, itemParameter2, itemParameter3, itemParameter4);
}

////////////////////////////
////////// EXPORTS /////////
///////////////////////////

let CallDotNet1Parameters = async (methodInvoked) => await DotNetHelper.CallDotNet1Parameters(methodInvoked);
let CallDotNet2Parameters = async (methodInvoked, param1) => await DotNetHelper.CallDotNet2Parameters(methodInvoked, param1);
let CallDotNet3Parameters = async (methodInvoked, param1, param2) => await DotNetHelper.CallDotNet3Parameters(methodInvoked, param1, param2);
let CallDotNet4Parameters = async (methodInvoked, param1, param2, param3) => await DotNetHelper.CallDotNet4Parameters(methodInvoked, param1, param2, param3);
let CallDotNet5Parameters = async (methodInvoked, param1, param2, param3, param4) => await DotNetHelper.CallDotNet5Parameters(methodInvoked, param1, param2, param3, param4);

export {
    DotNetHelper,
    CallDotNet1Parameters,
    CallDotNet2Parameters,
    CallDotNet3Parameters,
    CallDotNet4Parameters,
    CallDotNet5Parameters,

}