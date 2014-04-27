/// <reference path="jquery-1.5.2.js" />
/// <reference path="jquery.effects.core.js" />
/// <reference path="jquery.effects.bounce.js" />
/// <reference path="jquery.effects.shake.js" />
/// <reference path="jquery.flip.js" />

$("document").ready(function () {
    $("#cart1").live("click", function () {
        if ($("#session_custid").val() > 1) {
            $.getJSON("/Home/AddBook/" + $(this).attr("data-isbn"), function (data) {
                
                $("#cart_count").text("");
                $("#cart_count").append(data.ccount + " items in");
                $("#shopping_cart").flip({
                    direction: 'tb',
                    color: '#E6E3DD' 
                });
            })
            .error(function (obj, msg) {
                alert("error: " + msg);
            });
        }
        else {
            alert("Please sign in to add books to the shopping cart.")
        }
    });

    $("#ship_cb").bind("click", function () {
        if (this.checked) {
            var $inputs = $("#billing_address :input");
            $inputs.each(function () {
                $("#ship_" + this.name).val($(this).val());
            });
            $("#shipping_address").effect("bounce", { times: 5 }, 300);
        }
        else {
            var $inputs = $("#shipping_address :input");
            $inputs.each(function () {
                $(this).val("");
            });
            $("#shipping_address").effect("bounce", { times: 5 }, 300);
        }
    });

    $("#findbook").bind("click", function () {
        if ($("#isbn").val() == "") {
            alert("Please enter an ISBN number.");
        } else {
            $.getJSON("/Home/FindBook/" + $("#isbn").val(), function (data) {
                $.each(data, function (key, value) {
                    $("#" + key).val(value);
                });
            });
        }
    });

    $("#qoh_order").bind("click", function () {
        if ($("#newqoh").val() == "" || $("#isbn").val() == "") {
            alert("Please enter the ISBN number and number of books you want to order.");
        } else {
            var count = parseInt($("#newqoh").val()) + parseInt($("#qoh").val());
            $.getJSON("/Home/UpdateBook/" + $("#isbn").val() + "?count=" + count, function (data) {
                $("#findbook").click();
                $("#status").text("");
                $("#status").append("<h1>Inventory updated!</h1>");
                $("#bookorder").effect("bounce", { times: 5 }, 300);
            })
            .error(function (obj, msg) {
                alert("error: " + msg);
            });
        }
    });

    $(".quant_upd").bind("click", function () {
        if ($(this).siblings(".quantity").val() < 0) {
            alert("Enter a positive value for quantity.");
        } else {
            $.post("/Home/UpdateCart/" + $(this).siblings(".quantity").attr("data-isbn") + "?count=" + $(this).siblings(".quantity").val(), function () {
                $("#cart_preview").effect("bounce", { times: 5 }, 300);
            })
            .error(function (obj, msg) {
                alert("error: " + msg);
            });

            var total = 0.0;
            $(".cart_item :input.item_cost").each(function () {
                total += $(this).val() * $(this).siblings(".quantity").val();
            });

            $("#total").text("Total price: $" + total);
        }
    });

    $("#upd_profile").bind("click", function () {
        $("#cust_profile").effect("bounce", { times: 5 }, 300);
    });
});