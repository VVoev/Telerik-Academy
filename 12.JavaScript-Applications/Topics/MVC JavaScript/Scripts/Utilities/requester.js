function makeRequest(method, url, headers, data) {
    return $.ajax({
        method: method,
        url: url,
        authorization:"Basic a2lybzpraXJv",
        contentType:headers.contentType,
        data: JSON.stringify(data)
    });
}


class Requester {

    constructor() {

    }

    get(url,headers) {
        return makeRequest("GET", url, headers);
    }

    post() {
        return makeRequest("POST", url, headers, data);
    }

    put() {

    }

    delete() {

    }

}

