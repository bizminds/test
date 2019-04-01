$(document).ready(function () {
    $(document).ajaxError(function (e, jqxhr, settings, exception) {
        e.stopPropagation();
        var message = 'Oops! somthing went wrong on the server';
        if (jqxhr != null && jqxhr.responseJSON != null && jqxhr.responseJSON.Message) {
            message = 'Oops! ' + jqxhr.responseJSON.Message;
        }

        $('#errorMessage').html(message).fadeIn().delay(5000).fadeOut();
    });
    $('input[type=datetime]').datepicker({
        dateFormat: "dd/M/yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-200:+0",
        maxDate: 0
    });  
    $('#btnAge').click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var _form = _this.closest("form");
        var isvalid = _form.valid();  // Tells whether the form is valid
        $(".result").hide();
        
        if (isvalid) {
            $(".spinner-border").show();
            _this.hide();
            $.post('/calculator/age', _form.serialize(), function (data) {
                $(".result").show();
                
                var resultDiv = $('.result').find('div');
                resultDiv.html(data.Result);
            }).always(function () {
                _this.show();
                $(".spinner-border").hide();
            })
        }
    })
})