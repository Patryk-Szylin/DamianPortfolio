(() => {
    $.ajax({
        type: "GET",
        url: "https://localhost:44393/api/project",
        success(data) {
            console.log(data[0]);
        }
    });
})();