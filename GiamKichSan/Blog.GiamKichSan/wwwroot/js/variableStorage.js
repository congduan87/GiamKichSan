let variableStorage = {
    cstVariable: {
        userID: 'UserID',
        token: 'Token',
    },
    isStorage: function () {
        return typeof (Storage) !== 'undefined';
    },
    setUserID: function (userID) {
        if (this.isStorage) {
            localStorage.setItem(this.cstVariable.userID, userID);
        }
    },
    getUserID: function () {
        if (this.isStorage) {
            return localStorage[this.cstVariable.userID];
        }
        return null;
    },
    setToken: function (token) {
        if (this.isStorage) {
            localStorage.setItem(this.cstVariable.token, token);
        }
    },
    getToken: function () {
        if (this.isStorage) {
           return localStorage[this.cstVariable.token];
        }
        return null;
    }
}