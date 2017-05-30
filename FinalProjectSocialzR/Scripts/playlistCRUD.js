var $modal = $('#editor-modal'),
    $editor = $('#editor'),
    $editorTitle = $('#editor-title'),
    ft = FooTable.init('#editing-example', {
        editing: {
            enabled: true,
            addRow: function () {
                $modal.removeData('row');
                $editor[0].reset();
                $editorTitle.text('Add a new row');
                $modal.modal('show');
            },
            editRow: function (row) {
                var values = row.val();
                $editor.find('#id').val(values.id);
                $editor.find('#playlistName').val(values.firstName);

                $modal.data('row', row);
                $editorTitle.text('Edit row #' + values.id);
                $modal.modal('show');
            },
            deleteRow: function (row) {
                if (confirm('Are you sure you want to delete the row?')) {
                    row.delete();
                }
            }
        }
    }),
    uid = 10;

$editor.on('submit', function (e) {
    if (this.checkValidity && !this.checkValidity()) return;
    e.preventDefault();
    var row = $modal.data('row'),
        values = {
            id: $editor.find('#id').val(),
            playlistName: $editor.find('#firstName').val(),
        };

    if (row instanceof FooTable.Row) {
        row.val(values);
    } else {
        values.id = uid++;
        ft.rows.add(values);
    }
    $modal.modal('hide');
});