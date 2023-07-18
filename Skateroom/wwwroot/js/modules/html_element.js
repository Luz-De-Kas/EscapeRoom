
////////////////////////////
////////// IMPORTS /////////
///////////////////////////


///////////////////////////
////////// MAIN ///////////
///////////////////////////


let addClass = (elementReference, nameClass) => elementReference.classList.add(nameClass);
let removeClass = (elementReference, nameClass) => elementReference.classList.remove(nameClass);
let getWindowDimensions = () => {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    }
}
let getRect = (elementReference) => {
    var rect = elementReference.getBoundingClientRect();
    return {
        left: rect.left,
        top: rect.top
    }
}

//let scroll_bottom = (elementReference) => {
//    debugger;
//    elementReference.scrollTop = elementReference.scrollHeight;
//}

////////////////////////////
////////// EXPORTS /////////
///////////////////////////

export let html_element =
{
    addClass,
    removeClass,
    getWindowDimensions,
    scroll_bottom,
    getRect,

}