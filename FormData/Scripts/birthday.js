$(function () {
    // make balloon draggable
    $(".ball").draggable({ appendTo: "body" });

    // attach datepicker to textbox
    $('#birthday').datepicker({ dateFormat: "mm-dd" });

    // call attention to Happy Birthday! message
    var animations = new Array("bounce", "flash", "pulse", "rubberBand", "shake", "swing", "tada", "wobble");
    var idx = Math.floor((Math.random() * animations.length));
    $('h1').addClass('animated ' + animations[idx]);
    //$('h1').addClass('animated flash');

    // hide/show balloons based on checkboxes
    $('.bx').each(function (idx) {
        $(this).is(':checked') ?
            $('#' + $(this).attr('id') + 'Img').css('visibility', 'visible') :
            $('#' + $(this).attr('id') + 'Img').css('visibility', 'hidden')
    });

    // attach event listener to checkboxes
    $('.bx').change(function (e) {
        // make the image visible
        $('#' + $(this).attr('id') + 'Img').css('visibility', 'visible');
        // animate balloon In/Out based on checkbox
        $(this).is(':checked') ?
            $('#' + $(this).attr('id') + 'Img').removeClass().addClass('animated bounceInDown') :
            $('#' + $(this).attr('id') + 'Img').addClass('animated bounceOutUp');
    });
});