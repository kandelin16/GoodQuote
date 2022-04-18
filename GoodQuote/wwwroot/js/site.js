// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function expandQuote(id) {
    var id = "#hiddenQuote" + id
    //document.getElementById("hiddenQuote" + id).hidden = false;
    $(id).fadeIn()
}
function collapseQuote(id) {
    var id = "#hiddenQuote" + id
    //document.getElementById("hiddenQuote" + id).hidden = false;
    $(id).fadeOut()
}
function revealAddForm() {
    $("#flexformHolder").fadeIn();
    $("#addButton").fadeOut()
}
function hideAddForm() {
    $("#flexformHolder").fadeOut();
    $("#addButton").fadeIn()
}
function enableEdit(id) {
    document.getElementById("saveButton" + id).hidden = false
    document.getElementById("editButton" + id).hidden =true
    var elements = document.getElementsByClassName("enabler" + id)
    for (var i = 0; i < elements.length; i++) {
        elements[i].disabled = false
    }
}
function deleteQuote(id) {
    if (confirm("Are you sure you would like to delete this quote?")) {
        document.getElementById("deleteFormQuoteID").value = id
        document.getElementById("deleteQuoteForm").submit()
    }
}

$(document).ready(function () {
    if (document.getElementById("showTheModal").value == "true") {
        $("#exampleModalCenter").modal('show');
    }
});