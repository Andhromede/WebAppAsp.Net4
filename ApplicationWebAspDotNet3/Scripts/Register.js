$(document).ready(function () {
    var isValidLogin = false;
    var isValidEmail = false;
    var isValidPassword = false;

    function checkFormValidity() {
        var allValid = isValidLogin && isValidEmail && isValidPassword;
        $('#RegisterButton').prop('disabled', !allValid);
    }

    function checkAvailability(inputElement, outputElement) {
        var identifier = $(inputElement).val();
        var output = $(outputElement);
        var inputId = $(inputElement).attr('id');

        $.ajax({
            url: 'Register.aspx',
            type: 'GET',
            data: { 'identifier': identifier },
            success: function (data) {
                var isAvailable = data.trim() === "NotTaken";
                if (inputId === 'Login') {
                    isValidLogin = isAvailable;
                } else if (inputId === 'Email') {
                    isValidEmail = isAvailable;
                }

                output.text(isAvailable ? '' : inputId + ' non disponible.').css('color', isAvailable ? 'green' : 'red');
                checkFormValidity();
            },
            error: function (xhr, status, error) {
/*                console.error(xhr.status + ': ' + error);*/
                output.text('Erreur lors de la vérification.').css('color', 'red');
            }
        });
    }

    $('#Login, #Email').on('keyup blur', function () {
        checkAvailability(this, '#' + $(this).attr('id') + 'Match');
    });

    $('#Password, #ConfirmPassword').on('keyup blur', function () {
        var password = $('#Password').val();
        var confirmPassword = $('#ConfirmPassword').val();
        isValidPassword = password === confirmPassword && password;

        $('#passwordMatch').text(isValidPassword ? '' : 'Les mots de passe ne correspondent pas.').css('color', isValidPassword ? 'green' : 'red');
        checkFormValidity();
    });
});
