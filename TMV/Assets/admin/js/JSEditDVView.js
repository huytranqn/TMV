var DV = "/Dichvu";
var TDV = DV +"/GetAllDV";
var LDV = DV +"/GetAllLoai";
var NDV = DV + "/GetAllNhomDV";
var DVU = DV + "/GetDV";
$(document).ready(function () {
    _getNhomDV();



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
    $("#MA_DICHVU").on('change', function () {
        var id = $("#MA_DICHVU").val();
        if (id != undefined && id != '') {
            _getAllDV(id);
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
    $.get(LDV + "/?NhomDV=" + id, function (data) {
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
    $.get(TDV + "/?LoaiDV=" + id, function (data) {
        
        if (data != null && data != undefined && data.length) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<option value="' + item.MA_DICHVU + '">' + item.TEN_DICHVU + '</option>'
            });  
            $("#MA_DICHVU").html(html);
        }
    });
}

function _getAllDV(id) {
    $.get(DVU + "/?maDV=" + id, function (data) {

        if (data != null && data != undefined && data.length) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<input name="__RequestVerificationToken" type="hidden" value="5MCjmaw0mKvEyHuOd1LVWjh8vXPz_uQ8l7LfntVy6EcqJxnRawOr4T5bf0pyon8NexBLd4sL1UZt4mTWwllxOiWX0I20GOvjytxYnVE6pno1">';
                html += '<input data-val="true" id="' + item.MA_DICHVU + '" name="' + item.MA_DICHVU + '" type="hidden" value="' + item.MA_DICHVU + '" /> '
                html += '<input data-val="true" id="' + item.TEN_DICHVU + '" name="' + item.TEN_DICHVU + '" type="hidden" value="' + item.TEN_DICHVU + '" />'
                html += '<input data-val="true" id="' + item.MA_LOAIDV + '" name="' + item.MA_LOAIDV + '" type="hidden" value="' + item.MA_LOAIDV + '" />'
                html += '<input data-val="true" id="' + item.GIA_DICHVU + '" name="' + item.GIA_DICHVU + '" type="hidden" value="' + item.GIA_DICHVU + '" />'
                html += '<input data-val="true" id="' + item.GIA_KHUYENMAI + '" name="' + item.GIA_KHUYENMAI + '" type="hidden" value="' + item.GIA_KHUYENMAI + '" />'
                html += '<input data-val="true" id="' + item.THOIGIAN_LAMVIEC + '" name="' + item.THOIGIAN_LAMVIEC + '" type="hidden" value="' + item.THOIGIAN_LAMVIEC + '" />'
                html += '<input data-val="true" id="' + item.THU_TU + '" name="' + item.THU_TU + '" type="hidden" value="' + item.THU_TU + '" />'
                html += '<input data-val="true" id="' + item.NGUNG_KINHDOANH + '" name="' + item.NGUNG_KINHDOANH + '" type="hidden" value="' + item.NGUNG_KINHDOANH + '" />  '
                html += '<input data-val="true" id="' + item.MODIFIED + '" name="' + item.MODIFIED + '" type="hidden" value="' + item.MODIFIED + '" />'
            });
            $("#hidden").append(html);
        }
    });
}