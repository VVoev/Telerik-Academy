let sum = require("../sumArray").sum;
let expect = require("chai").expect;

describe ("Test sum arr with numbers",function () {
    it("should return 3 for [1,2]",function () {
        let expectedSum = 3;
        let actualSum = sum([1,2]);
        expect(actualSum).to.be.equal(expectedSum)
    })

    it("should return -6 for [-1,-2,-3]",function () {
        let expectedSum = -6;
        let actualSum = sum([-1,-2,-3]);
        expect(actualSum).to.be.equal(expectedSum)
    })

    it("should return 0 for []",function () {
        let expectedSum = 0;
        let actualSum = sum([]);
        expect(actualSum).to.be.equal(expectedSum)
    })


})
describe ("Test sum arr with NAN",function () {
    it("should return NAN for ['Pesho']", function () {
            let expectedSum = NaN;
            let actualSum = sum(['Pesho']);
            expect(actualSum).to.be.NaN;
    })
})



