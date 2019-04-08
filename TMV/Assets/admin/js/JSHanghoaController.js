var config = {
    page: 1,
    filter: ''
};
var HanghoaController = {
    init: function () {
        HanghoaController.registerEvent();
    },
    registerEvent: function () {
        //change status
        $('.btn-status').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');
            var text = btn.text() === "Kích hoạt" ? "khóa" : "kích hoạt";
            if (confirm("Bạn muốn " + text + " hàng hóa này?")) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Hanghoa/ChangeStatus',
                    data: { id: id },
                    dataType: 'json',
                    success: function (response) {
                        if (response) {
                            btn.attr('class', 'label label-success');
                            btn.text('Kích hoạt');
                        } else {
                            btn.attr('class', 'label label-danger');
                            btn.text('Khóa');
                        }
                    },
                    error: function (response) {
                        alert(response.message);
                    }
                });
            }


        });

        //delete
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');

            if (confirm("Bạn thực sự muốn xóa hàng hóa này?")) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Hanghoa/Delete',
                    data: { id: id },
                    dataType: 'json',
                    success: function (response) {
                        if (response) {
                            $('#row_' + id).remove();
                        }
                    },
                    error: function (response) {
                        alert(response.message);
                    }
                });
            };
        });
    },
};
HanghoaController.init();