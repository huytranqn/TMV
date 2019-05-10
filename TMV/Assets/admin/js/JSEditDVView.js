var DV = "/Dichvu";
var TDV = DV +"/GetAllDV";
var LDV = DV +"/GetAllLoai";
var NDV = DV +"/GetAllNhomDV";
$(document).ready(function () {
    _getNhomDV();


    function genderChanged(obj) {
        var value = obj.value;
        if (id != undefined && id != '') {
            _getLoaiDV(id);
        }
    }

    $("#MA_NHOMDV").on('change', function () {
        var id = $("#MA_NHOMDV").val();
        if (id != undefined && id != '') {
            _getLoaiDV(id);
        }
    });
    $("#MA_LOAIDV").on('change', function () {
        var id = $("#MA_LOAIDV").val();
        if (id != undefined && id != '') {
            _getDV(id);
        }
    }); 

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
                html += '<option value=' + item.MA_DICHVU + '>' + item.TEN_DICHVU + '</option>'
            });
            $("#MA_LOAIDV").html(html);
        }
    });
}