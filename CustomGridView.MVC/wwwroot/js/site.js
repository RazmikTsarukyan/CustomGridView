// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".edit-icon").on("click", function () {

    $(".btn-save").hide();
    $(".btn-edit").show();

    let playerId = $(this).attr("data-playerId");
    $(".btn-edit").attr("data-player-id", playerId);

    $(".image-" + playerId).empty();

    let firstName = $.trim($(".first-name-" + playerId).text());
    $(".first-name-" + playerId).empty();

    let lastName = $.trim($(".last-name-" + playerId).text());
    $(".last-name-" + playerId).empty();

    let age = $.trim($(".age-" + playerId).text());
    $(".age-" + playerId).empty();

    let status = $.trim($(".status-" + playerId).text());
    $(".status-" + playerId).empty();

    let imageInput = document.createElement("input");
    imageInput.classList.add("image-input-" + playerId);
    imageInput.textContent = "browse"
    imageInput.type = "file";

    let firstNameInput = document.createElement("input");
    firstNameInput.classList.add("first-name-input-" + playerId);
    firstNameInput.value = firstName;
    firstNameInput.type = "text";

    let lastNameInput = document.createElement("input");
    lastNameInput.classList.add("last-name-input-" + playerId);
    lastNameInput.value = lastName;
    lastNameInput.type = "text";

    let ageInput = document.createElement("input");
    ageInput.classList.add("age-input-" + playerId);
    ageInput.value = age;
    ageInput.type = "text";

    let statusInput = document.createElement("select");
    statusInput.classList.add("status-input-" + playerId);
    statusInput.classList.add("select-status");

    $(".image-" + playerId).append(imageInput);
    $(".first-name-" + playerId).append(firstNameInput);
    $(".last-name-" + playerId).append(lastNameInput);
    $(".age-" + playerId).append(ageInput);
    $(".status-" + playerId).append(statusInput);

    $(".status-input-" + playerId).append($("<option>").val("1").text("New"));
    $(".status-input-" + playerId).append($("<option>").val("2").text("Active"));
    $(".status-input-" + playerId).append($("<option>").val("3").text("Inactive"));
    $(".status-input-" + playerId).val(getStatusId(status));
})

$(".btn-add").on("click", function () {

    $(".btn-save").show();
    $(".btn-edit").hide();

    let imageDiv = document.createElement("div")
    imageDiv.classList.add("image-0");
    imageDiv.classList.add("new-item");

    let imageBtn = document.createElement("input");
    imageBtn.classList.add("image-btn-0");
    imageBtn.textContent = "browse"
    imageBtn.type = "file";
    imageDiv.append(imageBtn);

    let firstNameDiv = document.createElement("div")
    firstNameDiv.classList.add("first-name-0");
    firstNameDiv.classList.add("new-item");

    let firstNameInput = document.createElement("input");
    firstNameInput.classList.add("first-name-input-0");
    firstNameInput.type = "text";
    firstNameDiv.append(firstNameInput)

    let lastNameDiv = document.createElement("div")
    lastNameDiv.classList.add("last-name-0");
    lastNameDiv.classList.add("new-item");

    let lastNameInput = document.createElement("input");
    lastNameInput.classList.add("last-name-input-0");
    lastNameInput.type = "text";
    lastNameDiv.append(lastNameInput)

    let ageDiv = document.createElement("div")
    ageDiv.classList.add("age-0");
    ageDiv.classList.add("new-item");

    let ageInput = document.createElement("input");
    ageInput.classList.add("age-input-0");
    ageInput.type = "text";
    ageDiv.append(ageInput)

    let statusDiv = document.createElement("div")
    statusDiv.classList.add("last-name-0");
    statusDiv.classList.add("new-item");

    let statusInput = document.createElement("select");
    statusInput.classList.add("status-input-0");
    statusInput.classList.add("select-status");

    statusDiv.append(statusInput);

    var tr = $('<tr />');
    tr.append($('<td />').append(imageDiv))
    tr.append($('<td />').append(firstNameDiv))
    tr.append($('<td />').append(lastNameDiv))
    tr.append($('<td />').append(ageDiv))
    tr.append($('<td />').append(statusDiv))
    tr.append($('<td />'))

    $(".custom-table tbody").prepend(tr)

    $(".status-input-0").append($("<option>").val("1").text("New"));
    $(".status-input-0").append($("<option>").val("2").text("Active"));
    $(".status-input-0").append($("<option>").val("3").text("Inactive"));

})

$(".btn-save").on("click", function () {
    let formData = new FormData();
    formData.append("FirstName", $(".first-name-input-0").val());
    formData.append("LastName", $(".last-name-input-0").val());
    formData.append("Age", parseInt($(".age-input-0").val()));
    formData.append("StatusId", parseInt($(".status-input-0").val()));
    formData.append("Image", $(".image-btn-0")[0].files[0]);

    $.ajax("/home/addPlayer", {
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.success)
                location.reload();
        },
        error: function (err) {
            console.log(err)
        }
    });
})

$(".delete-icon").on("click", function () {
    let playerId = $(this).attr("data-playerId");
    $.ajax("/home/DeletePlayer", {
        type: 'POST',
        data: {
            id: playerId
        },
        success: function (response) {
            if (response.success)
                location.reload()
        },
        error: function (err) {
            console.log(err)
        }
    });
})

$(".btn-edit").on("click", function () {

    let playerId = $(this).attr("data-player-id");

    let formData = new FormData();
    formData.append("Id", playerId);
    formData.append("FirstName", $(".first-name-input-" + playerId).val());
    formData.append("LastName", $(".last-name-input-" + playerId).val());
    formData.append("Age", parseInt($(".age-input-" + playerId).val()));
    formData.append("StatusId", parseInt($(".status-input-" + playerId).val()));
    formData.append("Image", $(".image-input-" + playerId)[0].files[0]);

    $.ajax("/home/updatePlayer", {
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.success)
                location.reload();
        },
        error: function (err) {
            console.log(err)
        }
    });
})

$(".btn-cancel").on("click", function () {
    window.location.href = "/Home/Index";
})

$(".pagination-arrow-left").on("click", function () {
    let pageinationInputVal = $(".pagination-input").val();
    let pageIndex = 0;
    if (pageinationInputVal) {
        pageIndex = parseInt(pageinationInputVal);
    }

    pageIndex = --pageIndex;

    if (pageIndex < 1)
        pageIndex = 1;

    $(".pagination-input").val(pageIndex);

    let pageSize = $(".pagination-page-size").val();

    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();
    let orderCulumn = getOrderCulumn();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=" + orderCulumn;

})

$(".pagination-arrow-right").on("click", function () {
    let pageinationInputVal = $(".pagination-input").val();
    let pageIndex = 0;
    if (pageinationInputVal) {
        pageIndex = parseInt(pageinationInputVal);
    }

    let maxPageIndex = parseInt($.trim($(".pages-count").text()));

    pageIndex = ++pageIndex;

    if (pageIndex > maxPageIndex)
        pageIndex = maxPageIndex;

    $(".pagination-input").val(pageIndex);

    let pageSize = $(".pagination-page-size").val();

    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();
    let orderCulumn = getOrderCulumn();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=" + orderCulumn;
})

$(document).ready(function () {
    let pageSize = $(".pagination-page-size").attr("data-pagination-page-size");
    $(".pagination-page-size").val(pageSize);

    $(".filter-status").val($(".filter-status").attr("data-filter-value"));
});

$(".pagination-page-size").on("change", function() {
    let pageSize = $(this).val();
    let pageIndex = $(".pagination-input").val();

    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();
    let orderCulumn = getOrderCulumn();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=" + orderCulumn;
})

$('.pagination-input').on('keypress', function (e) {
    if (e.which === 13) {
        let pageSize = $(".pagination-page-size").val();
        let pageIndex = $(".pagination-input").val();

        let firstname = $(".filter-firstname").val();
        let lastname = $(".filter-lastname").val();
        let age = $(".filter-age").val();
        let statusId = $(".filter-status").val();
        let orderCulumn = getOrderCulumn();

        window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=" + orderCulumn;
    }
});

$('.btn-filter').on('click', function () {
    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();

    let pageSize = $(".pagination-page-size").val();
    let pageIndex = $(".pagination-input").val();
    let orderCulumn = getOrderCulumn();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=" + orderCulumn;
})

$(".first-name-desc").on("click", function () {
    $(".first-name-desc").addClass("active")
    $(".last-name-desc").removeClass("active");
    $(".age-desc").removeClass("active");

    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();

    let pageSize = $(".pagination-page-size").val();
    let pageIndex = $(".pagination-input").val();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=firstname";
})

$(".last-name-desc").on("click", function () {
    $(".last-name-desc").addClass("active")
    $(".first-name-desc").removeClass("active");
    $(".age-desc").removeClass("active");

    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();

    let pageSize = $(".pagination-page-size").val();
    let pageIndex = $(".pagination-input").val();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=lastname";
})

$(".age-desc").on("click", function () {
    $(".age-desc").addClass("active")
    $(".last-name-desc").removeClass("active");
    $(".first-name-desc").removeClass("active");

    let firstname = $(".filter-firstname").val();
    let lastname = $(".filter-lastname").val();
    let age = $(".filter-age").val();
    let statusId = $(".filter-status").val();

    let pageSize = $(".pagination-page-size").val();
    let pageIndex = $(".pagination-input").val();

    window.location.href = '/Home/GetPlayers?pageIndex=' + pageIndex + "&pageSize=" + pageSize + "&firstname=" + firstname + "&lastname=" + lastname + "&age=" + age + "&statusId=" + statusId + "&orderColumn=age";
})

function getStatusId(status)
{
    switch (status) {
        case "New":
            return 1;
        case "Active":
            return 2;
        case "Inactive":
            return 3;
        default:
            return 1;
    }
}
 
function getOrderCulumn() {
    if ($(".first-name-desc").hasClass("active")) {
        return "firstname";
    }

    if ($(".last-name-desc").hasClass("active")) {
        return "lastname";
    }

    if ($(".age-desc").hasClass("active")) {
        return "age";
    }

    return "";
}