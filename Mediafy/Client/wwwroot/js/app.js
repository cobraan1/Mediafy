window.handleModal = () => {
    $('#templateModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var title = button.data('modal-title')
        var content = button.data('modal-desc')

        var modal = $('#templateModal')
        modal.find('.modal-title').text(title)
        modal.find('.modal-body p').text(content)
    })
}
