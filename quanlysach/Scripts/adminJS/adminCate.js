var isEdit = false;

function SaveClick() {

    if (!isEdit) {
        var nameCate = $("#nameCate").val();
        var description = $("#description").val();
        var messAdd = $("#messAdd");
        if (nameCate == "" || description == "") {
            messAdd.html("vui lòng nhập đầy đủ")
        } else {
            var form = new FormData();
            form.append("nameCate", nameCate);
            form.append("description", description);


            var xhr = new XMLHttpRequest();
            xhr.open("POST", "/AdminCate/AddCate", true);

            xhr.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var content = xhr.responseText
                    var json_ct = JSON.parse(content);
                    if (json_ct.Data.status == "OK") {
                        window.location = "/Admin/AdminCate/Index";


                    }
                }
            }
            xhr.send(form);


        }
    } else {
        var nameCate = $("#nameCate").val();
        var idCate = $("#idcate").val();

        var description = $("#description").val();
        var messAdd = $("#messAdd");
        if (nameCate == "" || description == "") {
            messAdd.html("vui lòng nhập đầy đủ")
        } else {
            var form = new FormData();
            form.append("nameCate", nameCate);
            form.append("description", description);
            form.append("idcate", idCate);


            var xhr = new XMLHttpRequest();
            xhr.open("POST", "/AdminCate/EditCate", true);
            xhr.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var content = xhr.responseText
                    var json_ct = JSON.parse(content);
                    if (json_ct.Data.status == "OK") {
                        window.location = "/Admin/AdminCate/Index";


                    }
                }
            }
            xhr.send(form);


        }


    }
}
function AddBook() {
    isEdit = false
}
function EditCate(id) {
    isEdit = true;
    var id = $(`#btn_click-${id}`).data("id");
    $("#idcate").val(id)
    var name = $(`#btn_click-${id}`).data("namecate");
    $("#nameCate").val(name)
    var description = $(`#btn_click-${id}`).data("description");
    $("#description").val(description)
}
function DeleteCate(id, name) {

    alert("Việc xóa này sẽ dẫn đến mất hết các sách nằm trong danh mục này")
    if (confirm("bạn có muốn xóa danh mục " + name + " không")) {

        var form = new FormData();
        form.append("id", id);
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/AdminCate/DeleteCate", true);
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var content = xhr.responseText
                var json_ct = JSON.parse(content);
                if (json_ct.Data.status == "OK") {
                    var idbookdelete = $(`#id-${id}`)
                    idbookdelete.remove()

                }
            }
        }
        xhr.send(form);

    }
}
