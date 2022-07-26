﻿let editorPostDetail = document.querySelector('#PostDetailName');
let editorClass = document.querySelector('main .toolbar-container');
let $postDetail = $('input[name=PostDetailsDescription]');

let getEditor = {
    startIndex: 1,
    maxText: 4000,
    convertObjToArrayNode: function (control, iDParent) {
        let arrayChild = [];
        if (control == null) return arrayChild;
        if (control.outerHTML.length > this.maxText) {
            let controlHTML = this.getHTMLByControl(control);
            controlHTML.ID = this.startIndex++;
            controlHTML.Description = "";
            controlHTML.IDParent = iDParent;
            arrayChild.push(controlHTML);

            for (let index = 0; index < control.children.length; index++) {
                let childArray = this.convertObjToArrayNode(control.children[index], controlHTML.ID);
                arrayChild.push(...childArray);
            }
        }
        else {
            arrayChild.push({ "ID": this.startIndex++, "Description": control.outerHTML, "IDParent": iDParent });
        }
        return arrayChild;
    },
    getHTMLByControl: function (control) {
        let tagName = control.localName;
        let attrHTML = ''
        for (var index = 0; index < control.attributes.length; index++) {
            attrHTML += ` ${control.attributes[index].localName}="${control.getAttribute(control.attributes[index].localName)}"`;
        }
        return { "TagName": tagName, "IsTagClose": this.isTagClose(control), "TagAttribute": attrHTML };
    },
    isTagClose: function (control) {
        return control.outerHTML.indexOf(`</${control.localName}>`) >= 0;
    },
};

$(document).ready(function () {
    editorPostDetail.addEventListener('blur', function () {
        let array = [];
        let childRoot = this.children;
        for (let index = 0; index < childRoot.length; index++) {
            let arrChildren = getEditor.convertObjToArrayNode(childRoot[index], 0);
            array.push(...arrChildren);
        }
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