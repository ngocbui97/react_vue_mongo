"use strict"

const restify = require('restify')
const mongoose = require('mongoose')
const UserRouter = require('./src/routers/UserRouter')

const server = restify.createServer()
const port = process.env.PORT||3000

server.use(restify.plugins.bodyParser())
server.use(restify.plugins.acceptParser(server.acceptable))
server.use(restify.plugins.queryParser({mapParams:true}))
server.use(restify.plugins.fullResponse())

server.listen(port, function(){
    mongoose.Promise = global.Promise
    mongoose.connect('mongodb://localhost:27017/TicketSolution',{useNewUrlParser: true,  useUnifiedTopology: true})
    const db = mongoose.connection
    
    db.on('error', function(error){
        process.exit(1)
    })

    db.once('open', function(){
        UserRouter(server)
    })

    console.log('server %s starting on %s', server.name, server.url)
})