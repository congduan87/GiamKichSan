$(document).ready(function () {
    $('td a').click(function (event) {
        event.preventDefault();
        let href = this.getAttribute('href');
        if (href && href.trim() != '') {
            window.open(href, '_blank');
        }
    });
});