var config = {
    page: 1,
    filter: ''
};
var DichvuController = {
    init: function () {
        DichvuController.registerEvent();
    },
    registerEvent: function () {
        //change status
        $('.btn-status').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var id = btn.data('id');
            var text = btn.text() === "Kích hoạt" ? "khóa" : "kích hoạt";
            if (confirm("Bạn muốn " + text + " dịch vụ này?")) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Dichvu/ChangeStatus',
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

            if (confirm("Bạn thực sự muốn xóa dịch vụ này?")) {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Dichvu/Delete',
                    data: { id: id },
                    dataType: 'json',
                    success: function (response) {
                        window.location.replace("/Admin/Dichvu/");
                    },
                    error: function (response) {
                        alert(response.message);
                    }
                });
            };
        });
    },
};
DichvuController.init();