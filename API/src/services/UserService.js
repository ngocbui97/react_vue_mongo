"use strict"

const UserModel = require('../models/UserModel')
const Q = require('q')
const errors = require('restify-errors')


function insertUser(data){
    const defer = Q.defer()
    const user = new UserModel(data)
    user.save(function(error,result){
    if(error){
        console.log(error)
        defer.reject(new errors.InvalidContentError(error.message))
    }else{
        defer.resolve(result)
    }
    })
    return defer.promise
}

function getList(){
    const defer = Q.defer()
    UserModel.find({}).exec((err,result)=>{
        if(err){
            console.log(err)
            defer.reject(new errors.InvalidContentError(err.message))
        }else{
            defer.resolve(result)
        }
    })
    return defer.promise
}

function getUserById(id){
    const defer = Q.defer()
    UserModel.find({_id:id})
    .exec((err,result)=>{
        if(err){
            console.log(err)
            defer.reject(new errors.InvalidContentError(err.message))
        }else{
            defer.resolve(result)
        }
    })

    return defer.promise
}

function updateUser(data){
    const defer = Q.defer()
    UserModel.updateOne({_id:data.id},data, (err,result)=>{
        if(err){
            console.log(err)
            defer.reject(new errors.InvalidContentError(err.message))
        }else{
            defer.resolve(result)
        }
    })
    return defer.promise
}

function deleteUser(id){
    const defer = Q.defer()
    UserModel.deleteOne({_id:id},(err, result)=>{
        if(err){
            console.log(err)
            defer.reject(new errors.InvalidContentError(err.message))
        }else{
            defer.resolve(result)
        }
    })
    return defer.promise
}

function getUserByName(name){
    const defer = Q.defer()
    UserModel.findOne({name:name},(err,user)=>{
        if(err){
            console.log(err)
            defer.reject(new errors.InvalidContentError(err.message))
        }else{
            defer.resolve(user)
        }
    })
    return defer.promise
}

function getUserByEmail(email){
    const defer = Q.defer()
    UserModel.findOne({email:email}, (err, user)=>{
        if(err){
            console.log(err)
            defer.reject(new errors.InvalidContentError(err.message))
        }else{
            defer.resolve(user)
        }
    })
    return defer.promise
}

module.exports = {
    insertUser : insertUser,
    getList: getList,
    getUserById: getUserById,
    getUserByName: getUserByName,
    updateUser: updateUser,
    deleteUser: deleteUser,
    getUserByEmail: getUserByEmail
}