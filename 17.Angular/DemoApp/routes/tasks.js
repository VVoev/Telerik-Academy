let express = require('express');
let router = express.Router();
let mongojs = require('mongojs');
let db = mongojs('mongodb://brad:brad@ds041563.mlab.com:41563/taskslist', ['tasks']);

//Get all Tasks
router.get('/tasks', function (req, res, next) {
    db.tasks.find((function (err, tasks) {
        if (err) {
            console.log(err)
        }
        res.json(tasks);
    }))
});

//Get Single Task
router.get('/task/:id', function (req, res, next) {
    db.tasks.findOne({_id: mongojs.ObjectID(req.params.id)}, (function (err, task) {
        if (err) {
            console.log(err)
        }
        res.json(task);
    }))
});

//Save Task
router.post('/task', function (req, res, next) {
    let task = req.body;
    if (!task.title || task.isDone) {
        res.status(400);
        res.json({
            "error": "bad data"
        });
    } else {
        db.tasks.save(task, function (err, task) {
            if (err) {
                res.send(err);
            } else {
                res.json(task);
            }
        });
    }
})

//Delete Task
router.delete('/task/:id', function (req, res, next) {
    db.tasks.remove({_id: mongojs.ObjectID(req.params.id)}, (function (err, task) {
        if (err) {
            console.log(err)
        }
        res.json(task);
    }))
});

//Update Task
router.put('/task/:id', function (req, res, next) {
    let task = req.body;
    let updTask = {};
    if (task.isDone) {
        updTask.IsDone = task.isDone;
    }

    if (task.title) {
        updTask.title = task.title;
    }

    if (!updTask) {
        res.status(400);
        res.json({
            "error": "bad data"
        });
    } else {
        db.tasks.update({_id: mongojs.ObjectID(req.params.id)}, updTask,{}, (function (err, task) {
            if (err) {
                console.log(err)
            }
            res.json(task);
        }))
    }
});


module.exports = router;
