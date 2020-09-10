"use strict"

const UserControler = require('../controlers/UserControler')
const PRE_API = "/api/user/"
const AppHelper = require('../common/AppHelper')

module.exports = function(server){
    
    server.post(PRE_API + 'register', UserControler.register)

    server.post(PRE_API + 'login', UserControler.login)

    server.get(PRE_API + 'get-list', AppHelper.authen, UserControler.getList)

    server.get(PRE_API + 'get-user-by-id/:id', AppHelper.authen, UserControler.getUserById)

    server.put(PRE_API + 'update', AppHelper.authen, UserControler.updateUser)

    server.del(PRE_API + 'delete', AppHelper.authen, UserControler.deleteUser)
}