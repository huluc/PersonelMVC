$(function () {
    $("#tblDepartmants").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
            });
    $("#tblDepartmants").on("click", ".btnDelDep", function () {
        var id = $(this).data("id");
        var btn = $(this);
     
        //bootbox.confirm("Silmek istediğinize emin misiniz?", function (result) {
        //    if (result) {
        //        $.ajax({
        //            type: "GET",
        //            url: "/Departmant/Delete/" + id,
        //            success: function () {
        //                btn.parent().parent().remove();
        //            }
        //        })
        //    }
        //})
        if(confirm("Silmek istediğinize emin misiniz?"))           
                $.ajax({
                    type: "GET",
                    url: "/Departmant/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                })
    })
})
function CheckDateTypeIsValid(dateelement)
{
    var value = $(dateelement).val();
    if (value == '')
        $(dateelement).valid(false); 
    else
        $(dateelement).valid();
}