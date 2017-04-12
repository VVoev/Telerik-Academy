(function () {
    let counter = 0;
    function pause(delay) {
        setTimeout(function () {
            console.log(`pauses for ${delay}ms`)
        },delay)
    }
    console.log("start")
    let delay = 200;
    setTimeout(()=>{
        console.log(`paused for ${delay}ms`)
        console.log(++counter);
        setTimeout(()=>{
            console.log(`paused for ${delay}ms`)
            console.log(++counter);
            setTimeout(()=>{
                console.log(`paused for ${delay}ms`)
                console.log(++counter);
                setTimeout(()=>{
                    console.log(`paused for ${delay}ms`)
                    console.log(++counter);
                    setTimeout(()=>{
                        console.log(`paused for ${delay}ms`)
                        console.log(++counter);
                        setTimeout(()=>{
                            console.log(`paused for ${delay}ms`)
                            console.log(++counter);
                            setTimeout(()=>{
                                console.log(`paused for ${delay}ms`)
                                console.log(++counter);
                                setTimeout(()=>{
                                    console.log(`paused for ${delay}ms`)
                                    console.log(++counter);
                                    setTimeout(()=>{
                                        console.log(`paused for ${delay}ms`)
                                        console.log(++counter);
                                        setTimeout(()=>{
                                            console.log(`paused for ${delay}ms`)
                                            console.log(++counter);
                                            setTimeout(()=>{
                                                console.log(`paused for ${delay}ms`)
                                                console.log(++counter);
                                            },delay)
                                        },delay)
                                    },delay)
                                },delay)
                            },delay)
                        },delay)
                    },delay)
                },delay)
            },delay)
        },delay)
    },delay)
})()