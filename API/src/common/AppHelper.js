"use strict"
const jwt = require('jsonwebtoken')
const contants = require('../constants')

function validateToken(token, keyToken){
    return new Promise((resolve, reject)=>{
        jwt.verify(token, keyToken, function(error, decoded){
            if(error){
                console.log(error)
                reject(error)
            }else{
                resolve(decoded)
            }
        })
    })
}

// Middleware authen
function authen(req, res, next){
    let token = req.body.access_token||req.query.access_token||req.headers['access_token']
    validateToken(token, contants.KEY_TOKEN)
    .then((decoded)=>{
        req.decoded = decoded
        next()
    })
    .catch((error)=>{
        res.send(500, 'Unauthen')
        return next(error)
    })
}

module.exports = {
    authen : authen
}
