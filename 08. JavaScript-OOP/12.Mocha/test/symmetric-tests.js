let sum    = require("../symmetric").isSymmetric;
let expect = require("chai").expect;

describe ("[Test function is Symmetric] ",function () {
    it("should true for [1,2,3,3,2,1]", function () {
        let expectedSum = true;
        let actualSum = sum([1,2,3,3,2,1]);
        expect(actualSum).to.be.equal(expectedSum)
    })
})