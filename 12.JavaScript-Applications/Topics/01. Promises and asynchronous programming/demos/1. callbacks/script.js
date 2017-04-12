(function () {
    let counter = 0;

    function pause(delay) {
        setTimeout(function () {
            console.log(`pauses for ${delay}ms`)
        }, delay)
    }

    console.log("Start")
    let delay = 200;
    setTimeout(() => {
        console.log(`paused for ${delay}ms`)
        console.log(++counter);
        setTimeout(() => {
            console.log(`paused for ${delay}ms`)
            console.log(++counter);
            setTimeout(() => {
                console.log(`paused for ${delay}ms`)
                console.log(++counter);
                setTimeout(() => {
                    console.log(`paused for ${delay}ms`)
                    console.log(++counter);
                    setTimeout(() => {
                        console.log(`paused for ${delay}ms`)
                        console.log(++counter);
                        setTimeout(() => {
                            console.log(`paused for ${delay}ms`)
                            console.log(++counter);
                            setTimeout(() => {
                                console.log(`paused for ${delay}ms`)
                                console.log(++counter);
                                setTimeout(() => {
                                    console.log(`paused for ${delay}ms`)
                                    console.log(++counter);
                                    setTimeout(() => {
                                        console.log(`paused for ${delay}ms`)
                                        console.log(++counter);
                                        setTimeout(() => {
                                            console.log(`paused for ${delay}ms`)
                                            console.log(++counter);
                                            setTimeout(() => {
                                                console.log(`paused for ${delay}ms`)
                                                console.log(++counter);
                                                console.log("End")
                                            }, delay)
                                        }, delay)
                                    }, delay)
                                }, delay)
                            }, delay)
                        }, delay)
                    }, delay)
                }, delay)
            }, delay)
        }, delay)
    }, delay)
})()