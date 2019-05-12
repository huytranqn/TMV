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
    reurn["Lê trường Thi",
        "Đào Thị Bích Hương",
        "CÂN",
        "Đào Thị Bích Chung ",
        "HỒNG NGA",
        "Nguyễn Thị Thu Hà",
        "Dương Thị Hồng Ly",
        "Mai Thị Hồng Quy",
        "Hồ thị Kim Oanh",
        "Phan Thị Kim Lập",
        "Phạm Thị Kim Ngân",
        "KHÁNH THY",
        "Từ Thị Lành",
        "Nguyễn Đặng La Ni",
        "Phan Thị Minh Kiều",
        " Hồ Thị Mơ",
        "Đoàn Thị Mỹ Hoa",
        "Nguyễn Thị Thủy",
        "NGUYỄN THỊ NHỊ",
        "Huỳnh Thị Phượng",
        "QUYÊN",
        "Nguyễn Thị Thanh Hòa",
        "Võ Thị Thu Hoài",
        "Trần Thị Thu Trâm",
        "Nguyễn Thị Thu Uyên",
        "NGÔ TOÀN",
        "NGUYỄN VĂN TỨC",
        "Trần Tuyết Nhi",
        "TRƯỜNG THI",
        "Võ Kim Ngân",
        "Trần Thị Yến Nhi"];
}

