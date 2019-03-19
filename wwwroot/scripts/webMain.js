(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/project",
        success: function (data) {
            console.log(data[0]);
        }
    });
})();
//# sourceMappingURL=webMain.js.map