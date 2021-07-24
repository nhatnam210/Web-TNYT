$(document).ready(function() {


    function ktramail() {
        var reg = /^[A-Za-z0-9]{1,}(\@)((gmail)|(hotmail)|(yahoo))(\.com){1}$/;
        var mail = $("#email").val();
        if ($("#email").val() == '') {
            return false;
        }
        if (reg.test(mail)) {
            $("#errmail").html("");
            return true;
        } else {
            return false;

        }
    }
    // $("#continue").click(function() {
    //     if (ktramail() == false) {
    //         $("#errmail").html("Please enter your username or email address");
    //     } else {
    //         $(".access").css("display", "none");
    //         $(".inp-pass").css("display", " ");
    //         $(".agree").css("display", "block");
    //         $(".button-box").css("display", "none");

    //         $(".button-box-agree").css("display", "block");
    //         $(".text-sign").css("display", "block");
    //         $("footer").css("margin-top", "120px");
    //         $("#edit").css("display", "block")

    //     }

    // })


})