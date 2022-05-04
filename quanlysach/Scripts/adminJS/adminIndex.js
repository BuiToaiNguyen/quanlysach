
$('#pagination-demo').twbsPagination({
    totalPages: 35,
    visiblePages: 7,
    onPageClick: function (event, page) {
        $('#page-content').text('Page ' + page);
    }
});

isEdit = false;

function DeleteBook(id, name) {
    if (confirm("bạn có muốn xóa quyển " + name + " không") == true) {
        var form = new FormData();
        form.append("id", id);
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/AdminHome/DeleteBook", true);


        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var content = xhr.responseText
                var json_ct = JSON.parse(content);
                if (json_ct.Data.status == "OK") {
                    var bookdelete = $(`#id-${id}`);
                    console.log("oke");
                    bookdelete.remove();
                } else {
                    console.log("fail");

                }
            }
        }
        xhr.send(form);
    }


}

function AddBook() {
    isEdit = false;



}

function EditBook(id) {
    var id = $(`#btnclick-${id}`).data("id")
    $("#id").val(id)
    var name = $(`#btnclick-${id}`).data("name")

    $("#namebook").val(name)
    var nameauthor = $(`#btnclick-${id}`).data("nameauthor")

    $("#nameauthor").val(nameauthor)
    var idctg = $(`#btnclick-${id}`).data("idctg")
    $("#idctg").val(idctg)
    var price = $(`#btnclick-${id}`).data("price")
    $("#price").val(price);
    var linkimg = $(`#btnclick-${id}`).data("linkimg")
    $("#linkimg").val(linkimg);
    //$("#nameauthor") = $(`#btnclick-${id}`).data("nameauthor")
    // $("#idctg") = $(`#btnclick-${id}`).data("nameauthor")

    isEdit = true
}

function SaveClick() {
    if (!isEdit) {


        var name = $("#namebook").val();
        var nameauthor = $("#nameauthor").val();
        var idctg = $("#idctg").val();
        var price = $("#price").val();
        var linkimg = $("#linkimg").val();
        var messAdd = $("#messAdd");
        if (name == "" || nameauthor == "" || price == "") {
            messAdd.html("vui lòng nhập đầy đủ")
        } else {
            var form = new FormData();
            form.append("name", name);
            form.append("nameauthor", nameauthor);
            form.append("idctg", idctg);
            form.append("price", price);
            form.append("linkimg", linkimg);

            var xhr = new XMLHttpRequest();
            xhr.open("POST", "/AdminHome/AddBook", true);


            xhr.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var content = xhr.responseText
                    var json_ct = JSON.parse(content);
                    if (json_ct.Data.status == "OK") {
                        window.location = "/Admin/AdminHome/Index";


                    }
                }
            }
            xhr.send(form);


        }
    } else {
        var id = $("#id").val();
        var name = $("#namebook").val();
        var nameauthor = $("#nameauthor").val();
        var idctg = $("#idctg").val();
        var price = $("#price").val();
        var linkimg = $("#linkimg").val();
        var messAdd = $("#messAdd");
        if (name == "" || nameauthor == "" || price == "") {
            messAdd.html("vui lòng nhập đầy đủ")
        } else {



            var form = new FormData();
            form.append("id", id)
            form.append("name", name);
            form.append("nameauthor", nameauthor);
            form.append("idctg", idctg);
            form.append("price", price)
            form.append("linkimg", linkimg)
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "/AdminHome/EditBook", true);
            xhr.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var content = xhr.responseText
                    var json_ct = JSON.parse(content);
                    if (json_ct.Data.status == "OK") {
                        window.location = "/Admin/AdminHome/Index";



                    }
                }

            }
            xhr.send(form)
        }
    }
}
