System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Car;
    return {
        setters:[],
        execute: function() {
            Car = (function () {
                function Car(engine) {
                    this.engine = engine;
                }
                Car.prototype.start = function () {
                    console.log("engine started!");
                };
                Car.prototype.stop = function () {
                };
                return Car;
            }());
            exports_1("Car", Car);
        }
    }
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiQ2FyLmpzIiwic291cmNlUm9vdCI6IiIsInNvdXJjZXMiOlsiLi4vLi4vc2NyaXB0cy9DYXIudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7OztZQUFBO2dCQUVJLGFBQVksTUFBYztvQkFDdEIsSUFBSSxDQUFDLE1BQU0sR0FBRyxNQUFNLENBQUM7Z0JBQ3pCLENBQUM7Z0JBRUQsbUJBQUssR0FBTDtvQkFDSSxPQUFPLENBQUMsR0FBRyxDQUFDLGlCQUFpQixDQUFDLENBQUM7Z0JBQ25DLENBQUM7Z0JBRUQsa0JBQUksR0FBSjtnQkFDQSxDQUFDO2dCQUNMLFVBQUM7WUFBRCxDQUFDLEFBWkQsSUFZQztZQVpELHFCQVlDLENBQUEiLCJzb3VyY2VzQ29udGVudCI6WyJleHBvcnQgY2xhc3MgQ2FyIHtcclxuICAgIGVuZ2luZTogc3RyaW5nO1xyXG4gICAgY29uc3RydWN0b3IoZW5naW5lOiBzdHJpbmcpIHtcclxuICAgICAgICB0aGlzLmVuZ2luZSA9IGVuZ2luZTtcclxuICAgIH1cclxuXHJcbiAgICBzdGFydCgpIHtcclxuICAgICAgICBjb25zb2xlLmxvZyhcImVuZ2luZSBzdGFydGVkIVwiKTtcclxuICAgIH1cclxuXHJcbiAgICBzdG9wKCkge1xyXG4gICAgfVxyXG59Il19