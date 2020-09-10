"use strict"

const constants = require('../constants')
const config = require('../config')
const bcrypt = require('bcryptjs')
const UserService = require('../services/UserService')
const jwt = require('jsonwebtoken')
const rand = require('rand-token')
const listRefreshToken = {}
const nodemailer = require('nodemailer')

function register(req, res, next) {
    let data = req.body || {}
    // check user exist or email exist
    UserService.getUserByEmail(data.email)
    .then((result)=>{
        if(result.name){
            res.send(500, "email is registerd")
            return next()
        }
    })
    .catch((err)=>{
        console.log(err)
        res.send(500, error)
        return next(error)
    })
    .done()

    let password = bcrypt.hash(data.password, constants.SALT_ROUNDS, function (err, result) {
        if (err) {
            console.log(err)
            return next(err)
        } else {

            data.password = result
            UserService.insertUser(data)
                .then(function (user) {
                    jwt.sign(user.toJSON(), constants.KEY_TOKEN, { expiresIn: 60 * 60 }, function (err, result) {
                        if (err) {
                            console.log(err)
                            res.send(500, error)
                            return next(error)
                        } else {

                            // send mail
                            let transporter = nodemailer.createTransport(config.config_gmail)
                            transporter.verify(function (error, result) {
                                if (error) {
                                    console.log(error)
                                    res.send(500, err)
                                    return next(error)
                                } else {
                                    const mail = {
                                        from: config.config_gmail.auth.user,
                                        to: 'buinhungoc97@gmail.com',
                                        subject: 'Register ticket solution',
                                        text: `Register account of ${data.name}  successfull`,
                                        html: '<h1/>Thank for register my system <h1>'
                                    }

                                    transporter.sendMail(mail, function (err, result) {
                                        if (err) {
                                            console.log(error)
                                            res.send(500, err)
                                            return next(error)
                                        } else {
                                            let access_token = result
                                            let refresh_token = rand.uid(256)
                                            user.access_token = access_token
                                            user.refresh_token = refresh_token
                                            listRefreshToken[refresh_token] = user
                                            res.send(201, user)
                                            next()
                                        }
                                    })

                                }
                            })

                        }
                    })

                })
                .catch(function (error) {
                    res.send(500, error)
                    return next(error)
                })
                .done()
        }
    })
}

function login(req, res, next) {
    let name = req.body.name
    let password = req.body.password
    UserService.getUserByName(name)
        .then((user) => {
            bcrypt.compare(password, user.password, (err, result) => {
                if (err) {
                    console.log(err)
                    res.send(500, err)
                    return next(err)
                } else {
                    jwt.sign(user.toJSON(), constants.KEY_TOKEN, { expiresIn: 60 * 60 }, function (err, result) {
                        if (err) {
                            console.log(err)
                            res.send(500, error)
                            return next(error)
                        } else {
                            let access_token = result
                            let refresh_token = rand.uid(256)
                            user.access_token = access_token
                            user.refresh_token = refresh_token
                            user = {...user._doc, access_token, refresh_token}
                            listRefreshToken[refresh_token] = user
                            res.send(200, user)
                            next()
                        }
                    })
                }
            })
        })
        .catch((err) => {
            console.log(err)
            res.send(500, err)
            return next(err)
        })
        .done()
}

function getList(req, res, next) {
    UserService.getList()
        .then((result) => {
            res.send(200, result)
            next()
        })
        .catch((err) => {
            console.log(err)
            res.send(500, err)
            return next(err)
        })
        .done()
}

function getUserById(req, res, next) {
    let id = req.params.id
    UserService.getUserById(id)
        .then((result) => {
            res.send(200, result)
            next()
        })
        .catch((err) => {
            console.log(err)
            res.send(500, err)
            return next(err)
        })
        .done()
}

function updateUser(req, res, next) {
    let data = req.body || {}
    UserService.updateUser(data)
        .then((result) => {
            res.send(200, result)
            next()
        })
        .catch((err) => {
            console.log(err)
            res.send(500, err)
            return next(err)
        })
        .done()
}

function deleteUser(req, res, next) {
    let id = req.body.id
    UserService.deleteUser(id)
        .then((result) => {
            res.send(200, result)
            next()
        })
        .catch((err) => {
            console.log(err)
            res.send(500, err)
            return next(err)
        })
        .done()
}

function getTokenByUser(user) {
    jwt.sign(user.toJSON(), constants.KEY_TOKEN, { expiresIn: 60 * 60 }, function (err, result) {
        if (err) {
            console.log(err)
            res.send(500, error)
            return next(error)
        } else {
            let access_token = result
            let refresh_token = rand(256)
            user.access_token = access_token
            user.refresh_token = refresh_token
            return { access_token, refresh_token }
        }
    })
}

// get token by refresh token
async function getToken(req, res, next) {
    let refresh_token = req.body.refresh_token || {}
    if (refresh_token && refresh_token in listRefreshToken) {
        const user = listRefreshToken[refresh_token]

        let token = await getTokenByUser(user)
        if (token) {
            res.send(200, token)
        } else {
            res.rend(403, 'Forbbiden')
        }

    } else {
        res.send(401, "unauthorize")
        return next()
    }
}

module.exports = {
    register: register,
    login: login,
    getList: getList,
    getUserById: getUserById,
    updateUser: updateUser,
    deleteUser: deleteUser
}