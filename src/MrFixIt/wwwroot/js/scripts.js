//var test = "it works";

//write AJAX call to claim job
$(document).ready(function () {
    $(".claim-job").click(function () {
        var selectedId = $(this).attr("value");
        $.ajax({
            type: "POST",
            url: '@Url.Action("Claim")',
            dataType: "json",
            data: { id: selectedId },
            success: function (result) {
               var resultString = $(this).hide();
                $("#job-" + selectedId).text("This Job is claimed by " + result.worker.firstName + " " + result.worker.lastName + ".");
                $("#job-" + selectedId).append("<button value=\"" + selectedId + "\" class=\"working btn btn-primary\">Still working!</button>");
                $('')
                console.log(result);
                if (!result.worker.available) {
                    $(".claim-job").hide();
                }
            }
        });
    });
});