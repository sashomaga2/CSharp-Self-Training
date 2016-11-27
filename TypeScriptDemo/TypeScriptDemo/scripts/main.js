// Class
var Point = (function () {
    // Constructor
    function Point(x, y) {
        this.x = x;
        this.y = y;
    }
    // Instance member
    Point.prototype.getDist = function () {
        return Math.sqrt(this.x * this.x + this.y * this.y);
    };
    // Static member
    Point.origin = new Point(0, 0);
    return Point;
}());
// Local variables
var p = new Point(3, 4);
var dist = p.getDist();
console.log("dist", dist);
var fn;
//# sourceMappingURL=main.js.map