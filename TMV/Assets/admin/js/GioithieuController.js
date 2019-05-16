var config = {
    page: 1,
    filter: ''
};
var GioithieuController = {
    init: function () {
        GioithieuController.registerEvent();
    },
    registerEvent: function () {
        //change status
        $('.btn-status').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');
            var text = btn.text() === "Kích hoạt" ? "khóa" : "kích hoạt";
            if (confirm("Bạn muốn " + text + " giới thiệu này?")) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Gioithieu/ChangeStatus',
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

            if (confirm("Bạn thực sự muốn xóa giới thiệu này?")) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Gioithieu/Delete',
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
GioithieuController.init();