let signalR = {
    initConnection: function (url, hub) {
        return new signalR.HubConnectionBuilder().withUrl(`${url}/${hub}`).build();
    },
    start: function (connection) {
        connection.start().then(function () {
            alert('cap nhat thanh cong');
        }).catch(function (err) {
            return console.error(err.toString());
        });
    },
    received: function (connection, methodReceiveName, fnCalback) {
        connection.on(methodReceiveName, fnCalback);
    },
    sendData: function (connection, methodReceiveName, data, fnCalback) {
        connection.invoke(methodReceiveName, data)
            .then(fnCalback)
            .catch(function (err) {
                return console.error(err.toString());
            });
    }
}