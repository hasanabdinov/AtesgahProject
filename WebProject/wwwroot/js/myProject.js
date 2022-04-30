
let toggleShowInvoiceListCreating = $('.tableLoanLists');
let allCustomCreationInputs = $('.customHandlingForInputEnabled');
let btnCancelInvoiceUpdating = $('#btnCancelInvoicesAccepting');
let btnCancelModal = $('#btnCancelModal');
let btnCreateInvoice = $('#calculateInvoice');
let btnCancelCreatingMainFirst = $('#btnCancelCreatingMainFirst');
let tableRow = $(".clickedRow");
let closeProjectBtn = $("#exitProjectButton");


function ClearContents() {
    for (let k = 0; k < $('#listClientAdded').children().length; k++) {
        $('#listClientAdded').children()[k].removeAttribute('selected');
    }
    $('#listClientAdded').children()[0].setAttribute('selected', '');

    for (let z = 0; z < $('#loanPeriodInput').children().length; z++) {
        $('#loanPeriodInput').children()[z].removeAttribute('selected');
    }
    $('#loanPeriodInput').children()[0].setAttribute('selected', '');

    $("#phoneSelectedInput").val('');
    $("#payoutDateInput").val('');
    $("#loanInterestRate").val('');
    $("#loanAmountRange").val('');
}
btnCreateInvoice.click(function (e) {
    console.log("btncreate button")

    let clientID = $("#listClientAdded").find(":selected").data("clientid");
    let loanAmount = $("#loanAmountRange").val();
    let interestRate = $("#loanInterestRate").val();
    let period = $("#loanPeriodInput").find(":selected").val();
    let payoutDate = $("#payoutDateInput").val();
    let phone = $("#phoneSelectedInput").val();

    let dataModel = {
        ClientID: clientID,
        LoanAmount: loanAmount,
        InterestRate: interestRate,
        LoanPeriod: period,
        PayoutDate: payoutDate,
        TelephoneNr: phone
    }

    if (dataModel.ClientID < 1 ||
        parseInt(dataModel.LoanAmount) < 100 ||
        parseInt(dataModel.LoanAmount) > 5000 ||
        dataModel.TelephoneNr.length < 7 ||
        payoutDate.length < 10) {

        alert("Js Validation: Fill in The Inputs");
        return;
    }

    $.ajax({
        url: "/Invoice/CalculatedInvoice",
        method: "POST",
        data: { calculateDto: dataModel },
    }).done(function (d) {
        $("#tableLoanLists").html("");
        $("#tableLoanLists").html(d);
        $("#tableLoanLists").removeAttr("class");
        $("#tableLoanLists").attr("class", "tableLoanLists");
    }).fail(function () {
        alert("Something Gets Wrong!")
    });
});

btnCancelCreatingMainFirst.click(function () {
    ClearContents();
    $("#tableLoanLists").addClass("d-none");
})

closeProjectBtn.click(function (e) {
    $("body").html('');
});

btnCancelModal.click(function () {
    ClearContents();
    $("#tableLoanLists").addClass("d-none");
})

tableRow.click(function (e) {
    let row = $(e.target.parentElement);
    let loanId = row.data('id');
    console.log(loanId);

    var ownerDetails = e.target.parentElement.children[1].textContent;
    $("#selectedClientInformation").text(ownerDetails);

    $.ajax({
        url: "/Invoice/GetInvoiceByLoanId/" + loanId,
        method: "GET"
    }).done(function (d) {
        $("#invoicesContainer").html(d);
    }).fail(function () {
        alert("Something Get Wrong");
    });
});



function updateLoanList() {

    $.ajax({
        url: "/Loan/UpdateLoans",
        method: "POST"
    }).done(function (d) {
        $("#loanListTableBodyTag").empty();
        $("#loanListTableBodyTag").html(d);
    }).fail(function () {
        alert("Loans Did not Uploaded");
    });
}