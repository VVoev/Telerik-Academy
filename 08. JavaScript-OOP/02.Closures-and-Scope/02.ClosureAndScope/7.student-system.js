var database = function () {
    var records,
        lastId,
        self;

    function findRecordByID(id){
        if(lastId<id){
            throw "there is no such user in the database"
        }
        for(let i of records){
            if(i.id==id){
                return i;
            }
        }
        return null;

    }

    function saveRecord(record) {
        if(!lastId){
            lastId = 0;
        }

        if(!records){
            records=[];
        }

        record.id = ++lastId;
        records.push(record);
        return self;
    }

    function getAllRecords() {
        var cloned = [];
        cloned[records.length-1]==undefined;
        for(let i of records){
           cloned.push(i);
        }
        return cloned;
    }

    self= {
        save:saveRecord,
        findById:findRecordByID,
        getAll:getAllRecords
    };

    return self;
}();
arr = ["Ivan","Petar","Kiril","Tania","Qna"];
for(let i = 0;i<25;i+=1){
    names = arr[i%arr.length];
    database.save({
        name:names,
        age:12+i
    })
}
console.log("--------------------------------");
console.log(database.getAll());
