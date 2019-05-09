var DV = "/Dichvu";
var TDV = DV +"/GetAllDV";
var LDV = DV +"/GetAllLoai";
var NDV = DV +"/GetAllNhomDV";
$(document).ready(function () {
    _getNhomDV();

});
function _getNhomDV() {
    $.get(NDV, function (data) {
        if (data != null && data != undefined && data.length) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<option value=' + item.MA_NHOMDV + '>' + item.TEN_NHOMDV + '</option>'
            });
            $("#MA_NHOMDV").html(html);
        }
    });
}
function _getLoaiDV(id) {
    $.get(LDV + "/" + id, function (data) {
        if (data != null && data != undefined && data.length) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<option value=' + item.MA_LOAIDV+'>' + item.TEN_LOAIDV + '</option>'
            });
            $("#MA_LOAIDV").html(html);
        }
    });
}

function _getDV(id) {
    $.get(TDV + "/" + id, function (data) {
        if (data != null && data != undefined && data.length) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<option value=' + item.MA_LOAIDV + '>' + item.TEN_LOAIDV + '</option>'
            });
            $("#MA_LOAIDV").html(html);
        }
    });
}