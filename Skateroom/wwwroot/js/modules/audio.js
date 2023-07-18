
////////////////////////////
////////// IMPORTS /////////
///////////////////////////


import { DotNetHelper, CallDotNet1Parameters, CallDotNet2Parameters, CallDotNet3Parameters, CallDotNet4Parameters, CallDotNet5Parameters } from '../helpers/dotnet/classDotNetHelper.js'


////////////////////////////
/////// INTERNAL CODE //////
///////////////////////////




///////////////////////////
////////// MAIN ///////////
///////////////////////////

let play = (audio_file) =>
{
    let audio_player = new Audio(audio_file);
    audio_player.play();
}

let play_during = (audio_file, time_in_mili_seconds) =>
{
    let audio_player = new Audio(audio_file);
    audio_player.play();

    // Espera hasta que el archivo de audio comienza a reproducirse
    audio_player.onplaying = function () {
        // Detén la reproducción después de 3 segundos
        setTimeout(function () {
            audio_player.pause();
            audio_player.currentTime = 0; // Reinicia el audio al comienzo
        }, time_in_mili_seconds);
    };
}

////////////////////////////
////////// EXPORTS /////////
///////////////////////////

export let audio =
{
    play,
    play_during,

}