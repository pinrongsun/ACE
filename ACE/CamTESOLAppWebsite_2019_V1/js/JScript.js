
// Trap Backspace(8) and Enter(13) - 
// Except bksp on text/textareas, enter on textarea/submit

if (typeof window.event != 'undefined') // IE
  document.onkeydown = function() // IE
    {
    var t=event.srcElement.type;
    var kc=event.keyCode;
    return ((kc != 8 && kc != 13 && kc !=116) || ( t == 'text' &&  kc != 13 && kc !=116 && kc !=65 ) ||
             (t == 'textarea') || ( t == 'submit' &&  kc == 13 && kc !=116 && kc !=65))
    }
else
  document.onkeypress = function(e)  // FireFox/Others 
    {
    var t=e.target.type;
    var kc=e.keyCode;
    if ((kc != 8 && kc != 13 && kc != 116) || (t == 'text' && kc != 13 && kc != 116 &&  kc != 17) ||
        (t == 'textarea') || ( t == 'submit' &&  kc == 13 && kc !=116 && kc !=17))
        return true
//        else if ((kc == 116 || (window.event.ctrlKey && keycode == 67))
//          window.event.returnValue = false;
//                window.event.keyCode = 0;
//                window.status = "Refresh is disabled";
    else {
        alert('Sorry Backspace/Enter is not allowed here'); // Demo code
        return false
    }
}


//    //this code handles the F5/Ctrl+F5/Ctrl+R
//    document.onkeydown = checkKeycode
//    function checkKeycode(e) {
//        var keycode;
//        if (window.event)
//            keycode = window.event.keyCode;
//        else if (e)
//            keycode = e.which;

//        // Mozilla firefox
//        if ($.browser.mozilla) {
//            if (keycode == 116 ||(e.ctrlKey && keycode == 67)) {
//                if (e.preventDefault)
//                {
//                    e.preventDefault();
//                    e.stopPropagation();
//                }
//            }
//        } 
//        // IE
//        else if ($.browser.msie) {
//            if (keycode == 116 || (window.event.ctrlKey && keycode == 67)) {
//                window.event.returnValue = false;
//                window.event.keyCode = 0;
//                window.status = "Refresh is disabled";
//            }
//        }
//    }

