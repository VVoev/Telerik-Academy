/* globals console */

let maxParams = "items";
let maxBody = `
let maxItem = items[0];
for (let item of items) {
	maxItem = Math.max(item, maxItem);
}
return maxItem;
`;

let maxFunc = new Function(maxParams, maxBody);
console.log(maxFunc([100, 2, 3, 4,32]));/**
 * Created by Vlado on 1/24/2017.
 */
