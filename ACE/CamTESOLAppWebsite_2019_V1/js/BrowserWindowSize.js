window.onresize = function (event) {
    //SetWidthHeight();
    LoadMenu();
}

function LoadMenu() {
    var width = $(window).width();
    if (width <= 500) {

        var allTags = document.getElementById('main').getElementsByTagName("div");
        //alert(allTags.length);
        var i, e;
       for (i = 0; i < allTags.length; ++i) {
           e = allTags[i];
            e.style.display = 'none';
        }        
        document.getElementById("menu").style.display = 'inline';


    } else {
        var allTags = document.getElementById('main').getElementsByTagName("div");
        //alert(allTags.length);
        var i, e;
        for (i = 0; i < allTags.length; ++i) {
            e = allTags[i];
            e.style.display = 'inline';
        }
        document.getElementById("menu").style.display = 'none';
    }
}

function SetWidthHeight() {
    var height = $(window).height();
    var width = $(window).width();
    $.ajax({
        url: "windowSize.ashx",
        data: {
            'Height': height,
            'Width': width
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (data) {
        if (data.isFirst) {
            window.location.reload();
        };
    }).fail(function (xhr) {
        alert("Problem to retrieve browser size.");
    });

}
$(function () {
    SetWidthHeight();
});