$(document).ready(function () {
    $('#btnPalindrome').click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var _form = _this.closest("form");
        var isvalid = _form.valid();  // Tells whether the form is valid
        $(".result").hide();
        
        if (isvalid) {
            $(".spinner-border").show();
            _this.hide();
            $.post('/palindrome/check', _form.serialize(), function (data) {
                $(".result").show();
                $(".result").html('');
                
                var resultDiv = $('<div></div>')
                $(".result").append(resultDiv);
                if (data.IsValid) {
                    resultDiv.html("Entered string is a palindrome").addClass("text-success");
                }
                else {
                    resultDiv.html("Entered string is not a palindrome").addClass("text-danger");
                }
            }).always(function () {
                _this.show();
                $(".spinner-border").hide();
            })
        }
    })
})