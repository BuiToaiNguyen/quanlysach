
$("#bookmanage").click(function() {
    $("#catemanage").removeClass("active")
    $("#bookmanage").addClass("active")
});
$("#catemanage").click(function () {
    $("#bookmanage").removeClass("active")
    $("#catemanage").addClass("active")
})
$("#linkimg").change(function () {
    var linkimgAdd = $("#linkimg").val();
    $("#srcImgAdd").attr("src", linkimgAdd);
});
