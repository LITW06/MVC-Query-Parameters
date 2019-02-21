$(() => {
    $(".btn-danger").on('click', function() {
        const id = $(this).data('order-id');
        $(`#order-row-${id}`).css('background', 'red');
    })
})