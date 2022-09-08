let editorPostDetail = document.querySelector('#PostDetailName');
let editorClass = document.querySelector('main .toolbar-container');
let $postDetail = $('input[name=PostDetailsDescription]');



$(document).ready(function () {
    editorPostDetail.addEventListener('blur', function () {
        let array = [];
        editorPostDetail.childNodes.forEach(function (item) {
            array.push(item.innerHTML);
        });
        $postDetail[0].value = JSON.stringify(array);
    });
    DecoupledEditor
        .create(editorPostDetail, {
            // toolbar: [ 'heading', '|', 'bold', 'italic', 'link' ]
        })
        .then(editor => {
            editorClass.prepend(editor.ui.view.toolbar.element);
            window.editor = editor;
            editorPostDetail.focus();
        })
        .catch(err => {
            console.log(err.stack);
        });
});