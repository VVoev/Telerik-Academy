const express = require('express');
const app = express();
require('./config/app.config')(app);




//domain.com Home
require('./routes')(app);
module.exports = app;
