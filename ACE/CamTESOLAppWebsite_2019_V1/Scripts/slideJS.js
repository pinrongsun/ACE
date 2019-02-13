function hideMenu(e) {
    var box = $(".menu-wrap");
        
    if ($("body").hasClass("show-menu")) {

        var boxPos = box.offset();

        var mouseX, mouseY, boxX1, boxX2, boxY1, boxY2, boxPadLeftRight, boxPadTopBottom, isOutside = true;
        mouseX = e.pageX;
        mouseY = e.pageY;
        boxPadLeftRight = parseInt(box.css("padding-left")) + parseInt(box.css("padding-right"));
        boxPadTopBottom = parseInt(box.css("padding-top")) + parseInt(box.css("padding-bottom"));
        boxX1 = boxPos.left;
        boxX2 = boxPos.left + box.width() + boxPadLeftRight - 1;
        boxY1 = boxPos.top;
        boxY2 = boxPos.top + box.height() + boxPadTopBottom - 1;

        if (mouseX >= boxX1 && mouseX <= boxX2) {
            if (mouseY >= boxY1 && mouseY <= boxY2) {
                isOutside = false;
            }
        }
        if (isOutside) {
            $("#openButton").click();
        }
    }
};