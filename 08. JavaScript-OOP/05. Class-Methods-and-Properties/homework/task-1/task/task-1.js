/*
 Implementation of linked list data structure in javascript
 */
function LinkedList() {}
LinkedList.prototype = {
    length: 0,
    first: null,
    last: null
};
LinkedList.prototype.append = function(node) {
    if (this.first === null) {

        node.prev = node;
        node.next = node;
        this.first = node;
        this.last = node;
    } else {

        node.prev = this.last;
        node.next = this.first;
        this.first.prev = node;
        this.last.next = node;
        this.last = node;
    }
    this.length++;
    return this;
};
LinkedList.prototype.insertAfter = function(node, nextNode) {
    nextNode.prev = node;
    nextNode.next = node.next;
    node.next.prev = nextNode;
    node.next = nextNode;
    if (nextNode.prev == this.last) { this.last = nextNode; }
    this.length++;
};
LinkedList.prototype.remove = function(node) {
    if (this.length > 1) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
        if (node == this.first) { this.first = node.next; }
        if (node == this.last) { this.last = node.prev; }
    } else {
        this.first = null;
        this.last = null;
    }
    node.prev = null;
    node.next = null;
    this.length--;
};
LinkedList.Node = function(data) {
    this.prev = null; this.next = null;
    this.data = data;
};
var list = new LinkedList();
list.append(1).append(1,2,3)
list.append(23);
list.append(102).append(15);
for(let i in list){
    console.log(i)
}
console.log(list)