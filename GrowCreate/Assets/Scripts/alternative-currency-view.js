$(function () {

    $(".price__alternative-currencies").on("change", ".alternative-currencies__list", function () {
        var val = $(this).val();
        var container = $(this).closest(".price__alternative-currencies");
        container.children(".currency__value").html(val);
    });

});