System.register(["./Car"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Car_1;
    var Point, p, dist, car, fn;
    return {
        setters:[
            function (Car_1_1) {
                Car_1 = Car_1_1;
            }],
        execute: function() {
            // Class
            Point = (function () {
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
            exports_1("Point", Point);
            // Local variables
            p = new Point(3, 4);
            dist = p.getDist();
            console.log("dist", dist);
            car = new Car_1.Car("engine");
            console.log("car", car);
            car.start();
        }
    }
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibWFpbi5qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzIjpbIi4uLy4uL3NjcmlwdHMvbWFpbi50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O2VBcUJJLENBQUMsRUFDRCxJQUFJLEVBTUosR0FBRyxFQUtILEVBQUU7Ozs7Ozs7WUE1Qk4sUUFBUTtZQUNSO2dCQUNJLGNBQWM7Z0JBQ2QsZUFBbUIsQ0FBUyxFQUFTLENBQVM7b0JBQTNCLE1BQUMsR0FBRCxDQUFDLENBQVE7b0JBQVMsTUFBQyxHQUFELENBQUMsQ0FBUTtnQkFBSSxDQUFDO2dCQUVuRCxrQkFBa0I7Z0JBQ2xCLHVCQUFPLEdBQVA7b0JBQ0ksTUFBTSxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsSUFBSSxDQUFDLENBQUMsR0FBRyxJQUFJLENBQUMsQ0FBQyxHQUFHLElBQUksQ0FBQyxDQUFDLEdBQUcsSUFBSSxDQUFDLENBQUMsQ0FBQyxDQUFDO2dCQUN4RCxDQUFDO2dCQUVELGdCQUFnQjtnQkFDVCxZQUFNLEdBQUcsSUFBSSxLQUFLLENBQUMsQ0FBQyxFQUFFLENBQUMsQ0FBQyxDQUFDO2dCQUNwQyxZQUFDO1lBQUQsQ0FBQyxBQVhELElBV0M7WUFYRCx5QkFXQyxDQUFBO1lBR0Qsa0JBQWtCO1lBQ2QsQ0FBQyxHQUFXLElBQUksS0FBSyxDQUFDLENBQUMsRUFBRSxDQUFDLENBQUMsQ0FBQztZQUM1QixJQUFJLEdBQUcsQ0FBQyxDQUFDLE9BQU8sRUFBRSxDQUFDO1lBRXZCLE9BQU8sQ0FBQyxHQUFHLENBQUMsTUFBTSxFQUFFLElBQUksQ0FBQyxDQUFDO1lBSXRCLEdBQUcsR0FBRyxJQUFJLFNBQUcsQ0FBQyxRQUFRLENBQUMsQ0FBQztZQUM1QixPQUFPLENBQUMsR0FBRyxDQUFDLEtBQUssRUFBRSxHQUFHLENBQUMsQ0FBQztZQUN4QixHQUFHLENBQUMsS0FBSyxFQUFFLENBQUM7WUFHb0IiLCJzb3VyY2VzQ29udGVudCI6WyIvLyBJbnRlcmZhY2VcclxuZXhwb3J0IGludGVyZmFjZSBJUG9pbnQge1xyXG4gICAgZ2V0RGlzdCgpOiBudW1iZXI7XHJcbn1cclxuXHJcbi8vIENsYXNzXHJcbmV4cG9ydCBjbGFzcyBQb2ludCBpbXBsZW1lbnRzIElQb2ludCB7XHJcbiAgICAvLyBDb25zdHJ1Y3RvclxyXG4gICAgY29uc3RydWN0b3IocHVibGljIHg6IG51bWJlciwgcHVibGljIHk6IG51bWJlcikgeyB9XHJcblxyXG4gICAgLy8gSW5zdGFuY2UgbWVtYmVyXHJcbiAgICBnZXREaXN0KCkge1xyXG4gICAgICAgIHJldHVybiBNYXRoLnNxcnQodGhpcy54ICogdGhpcy54ICsgdGhpcy55ICogdGhpcy55KTtcclxuICAgIH1cclxuXHJcbiAgICAvLyBTdGF0aWMgbWVtYmVyXHJcbiAgICBzdGF0aWMgb3JpZ2luID0gbmV3IFBvaW50KDAsIDApO1xyXG59XHJcblxyXG5cclxuLy8gTG9jYWwgdmFyaWFibGVzXHJcbnZhciBwOiBJUG9pbnQgPSBuZXcgUG9pbnQoMywgNCk7XHJcbnZhciBkaXN0ID0gcC5nZXREaXN0KCk7XHJcblxyXG5jb25zb2xlLmxvZyhcImRpc3RcIiwgZGlzdCk7XHJcblxyXG5pbXBvcnQgeyBDYXIgfSBmcm9tIFwiLi9DYXJcIjtcclxuXHJcbnZhciBjYXIgPSBuZXcgQ2FyKFwiZW5naW5lXCIpO1xyXG5jb25zb2xlLmxvZyhcImNhclwiLCBjYXIpO1xyXG5jYXIuc3RhcnQoKTtcclxuXHJcblxyXG52YXIgZm46IChuYW1lPzogc3RyaW5nKSA9PiB2b2lkO1xyXG4iXX0=