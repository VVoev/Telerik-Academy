const {Router} = require('express');

const attach = (app) => {
    const router = new Router();

    router
        .get('/', (req, res) => {
            res.send(`<h1>home</h1>'
                <ul>
                    <li><a href="#item1">Go to Item1</a></li>
                    <li><a href="#item2">Go to Item2</a></li>
                    <li><a href="#item3">Go to Item3</a></li>
                </ul>`);
        })
        .get('/all', (req, res) => {
            res
                .status(404)
                .send('<h1>all</h1>');
        });

    app.use('/',router);
}

module.exports = attach;
