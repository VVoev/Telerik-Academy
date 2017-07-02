const port = 3001
const express = require('express');

const app = express();
const bodyParser = require('body-parser');

app.use(bodyParser.json());


//domain.com Home
require('./routes/server.routes')(app);
require('./routes/api.routes')(app);


app.listen(port, () => {
    console.log(`Server started on ${port}...`)
});

