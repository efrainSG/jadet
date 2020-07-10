$(document).ready(function () {
    jQuery.noConflict();
    $('[id^="btneditar"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            console.log($($componentes)[0].text());
            console.log($($componentes)[2].text());
            console.log($($componentes)[3].text());
            console.log($($componentes)[4].text());
            console.log($($componentes)[5].text());
            console.log($($componentes)[6].text());
            $("#myModal").modal("show");
        });
});