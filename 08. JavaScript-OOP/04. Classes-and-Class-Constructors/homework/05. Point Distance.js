class Point{
    constructor(first,second){
        this.first=first;
        this.second=second;
    }
    static distance(x,y){
        const dx = x.first-y.first;
        const dy = x.second-y.second;
        return Math.sqrt(dx*dx + dy*dy);
    }
}





let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
