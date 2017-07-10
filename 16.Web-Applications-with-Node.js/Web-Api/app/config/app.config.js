const path = require('path');
const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const morgan = require('morgan');

const configApp = (app) =>{
    app.set('view engine', 'pug');
    app.use(morgan('combined'));
    app.use(bodyParser.json());

    let start;
    app.use((req,res,done)=>{
        start = new Date();
        req.on('end',()=>{
            const end = new Date();
            console.log(`execution time ${end - start}`)
        })
        done();
    });

    app.use('/static',
        express.static(
            path.join(__dirname, '../static'))
    );

    app.use('/libs',
        express.static(
            path.join(__dirname, '../node_modules'))
    );
};

module.exports = {configApp};
