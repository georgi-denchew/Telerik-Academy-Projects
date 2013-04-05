function TrianglePossible() {
    var point1 = new Point(0, 0);
    var point2 = new Point(2, 3);
    var point3 = new Point(4, 1);

    var segment3 = new Segment(point1, point2);
    var segment2 = new Segment(point1, point3);
    var segment1 = new Segment(point2, point1);
    jsConsole.writeLine(CanFormTriangle(segment1, segment2, segment3)? "It's possible" : "It's not possible");
}
function Point(x, y) {
    this.x = x;
    this.y = y;
    this.CalculateDistance = function (point) {
        return Math.sqrt((this.x - point.x) * (this.x - point.x) + (this.y - point.y) * (this.y - point.y));
    };
}

function Segment(point1, point2) {
    this.start = point1;
    this.end = point2;
    this.length = function () {
        return this.start.CalculateDistance(this.end);
    };
}

function CanFormTriangle(s1, s2, s3) {
    var first = s1.length();
    var second = s2.length();
    var third = s3.length();

    return first + second > third && second + third > first && first + third > second;
}
