$(function () {

    $("#toolbar-gz").popover({
        trigger: 'hover', //how popover is triggered - click | hover | focus | manual
        placement: 'left', //placement of the popover. also can use  top | bottom | left | right | auto.
        //title: '<div style="text-align:center; color:red; text-decoration:underline; font-size:14px;"> Muah ha ha</div>', //this is the top title bar of the popover. add some basic css
        html: 'true', //needed to show html of course
        content: '<div id="popOverBox" style="margin:-10px -10px 0px -10px"><img src="../Content/Images/qrcode.png" width="150" height="150" /><div class="text-center" style="color:black">官方微信</div></div>' //this is the content of the html box. add the image here or anything you want really.
        //content: '<div id="popOverBox" style=""><dl><dt><img src="image/qrcode.png"></dt><dd>官方微信</dd></dl></div>' //this is the content of the html box. add the image here or anything you want really.
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() != 0) {
            $("#toolbar-rtop").show();
        } else {
            $("#toolbar-rtop").hide();
        }
    });


})