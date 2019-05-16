var base = "/TuvanDV";
var khachhang = base +"/getNV"
$(document).ready(function () {
    selectnv();
});
function selectnv() {
    var combo = new STComboBox();
    combo.Init('nhanvien');
    var data = [];
    var nv = Getnv();
    for (var i = 0; i < nv.lenght; i++) {
        data.push({ id: i, text: nv[i] });
    }
    combo.populateList(data);
}
function Getnv() {
    //$.get(khachhang, function (data) {
    //    if (data != null && data != undefined && data.length) {
    //        return data;
    //    }
    //});
    return ["Tran Huy",
            "Van Lan "];
}

