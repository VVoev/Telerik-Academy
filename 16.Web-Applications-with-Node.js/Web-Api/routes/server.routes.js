const {Router} = require('express');

const items = [{
    id: 1,
    name: "Jane"
    },
    {
        id: 2,
        name: "Jorge"
    }];

const attach = (app) => {
    const router = new Router();

    router
        .get('/', (req, res) => {
            res.render('home');
        })
        .get('/all', (req, res) => {
            res
                .status(200)
                .render('all', {
                    model: items
                });
        })
        .get('/:id', (req, res) => {
            const id = +req.params.id;
            const item = items.find((i) => i.id === id);
            return res.render('details', {
                model: item
            })
        })

    app.use('/', router);
}

module.exports = attach;
