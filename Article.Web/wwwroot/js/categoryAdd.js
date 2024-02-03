

$(document).ready(function () {
    $("#btnSave").click(function (event) {
        event.preventDefault();  // sayfanin yeniden yuklenmesi engellenir

        var addUrl = app.Urls.categoryAddUrl;
        var redirectUrl = app.Urls.articleAddUrl;

        var categoryAddDto = {
            Name: $("input[id=categoryName]").val()  // id'si categoryName olan input'un degerini al
        }

        var jsonData = JSON.stringify(categoryAddDto); // JSON.stringify fonksiyonu kullanilarak bu nesne JSON formatinde bir dizeye cevrilir.
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;  // islem basariliysa redirectUrl degiskeninde tanimlandigi gibi article sayfasina donecek
                },1500);  // 1.5 sn sonra sayfa yenilenecek
            },
            error: function () {
                toast.error("Bir hata oluştu", "Hata");
            }
        });
    });
});