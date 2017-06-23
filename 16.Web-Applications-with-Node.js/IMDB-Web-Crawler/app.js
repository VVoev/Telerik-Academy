require('./polyfills');

const baseUrl = 'http://www.imdb.com/title/tt0114709/?ref_=nv_sr_1';

const getMovieData = (url) => {
    return fetch(url)
        .then((response) => {
            return response.text();
        })
        .then((html) => {
            return require('./dom-parser')(html);
        })
        .then(($)=>{
            const title = $('title').html();
            console.log(title);
        })
}

getMovieData(baseUrl);