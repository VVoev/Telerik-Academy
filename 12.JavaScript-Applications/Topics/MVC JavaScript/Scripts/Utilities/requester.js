function makeRequest(method, url, headers, data) {
    return $.ajax({
        method: method,
        url: url,
        headers: headers,
        data: JSON.stringify(data)
    });
}


class Requester {

    constructor() {

    }

    get() {
        return makeRequest("GET", url, headers, {});
    }

    // post() {
    //     return makeRequest("POST", url, headers, data);
    // }

    put() {

    }

    delete() {

    }

}

