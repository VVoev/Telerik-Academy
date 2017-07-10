const {Router} = require('express');

const items = [{
    id: 1,
    name: "vlado",
}];

const attach = (app) => {

    const router = new Router();

    router
    //q
        .get('/', (req, res) => {
            let q = req.query.q;
            let page;
            let size;
            let result = items;
            page = +page || 1;
            size = +size || 10;
            if (q) {
                q = q.toLowerCase();

                result = result.filter((item) => {
                    return item.name.includes(q);
                });
            }

            //not working for some reason
            // result = result.slice((page - 1) * size, page * size);
            //paging
            console.log(result)
            res.send(result);
        })
        .get('/:id', (req, res) => {
            const id = +req.params.id;
            const item = items.find((i) => i.id === id);


            if (!item) {

                return res
                    .status(404)
                    .send({
                        error: 'Not Found'
                    })
            }

            return res.send(item);
        })

        .post('/', (req, res) => {
            const item = req.body;
            item.id = items.length + 1;
            items.push(item);
            res.status(200)
                .send(true);
        });

    app.use('/api/items', router);

}
module.exports = attach;