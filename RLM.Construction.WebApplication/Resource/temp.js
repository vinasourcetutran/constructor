var d1 = d2 = d3 = d4 = d5 = d6 = d7 = d8 = d9 = d10 = [];

function randomData(d, x1, x2) {
    for (var i = x1; i < x2; i += (x2 - x1) / 100)
        d.push([i, Math.sin(i * Math.sin(i))]);

    return { label: "sin(x sin(x))", data: d };	
}

function linearData(d, x) {
	x = x || 10;
    for (var i = 0; i < x; i++)
        d.push([i, i*2]);

    return [
        { label: "sin(x sin(x))", data: d }
    ];	
}
var d1 = [[1,45]];
for (var i = 0; i < 14; i += 0.5)
    d1.push([i, 5+Math.sin(i)]);

var d2 = [[1,45]]; //[[2, 3], [4, 8], [8, 5], [9, 13]];

var d3 = [];
for (var i = 0; i < 14; i += 0.5)
    d3.push([i, 3+Math.cos(i)]);

var d4 = [];
for (var i = 0; i < 14; i += 0.5)
    d4.push([i, Math.random() * 10]);

var d5 = [];
for (var i = 0; i < 14; i += 0.5)
    d5.push([i, Math.random() * i]);

var d6 = [];
for(var i = 0; i < 14; i++)
	{
		var r = Math.floor(Math.random() * 14);
		d6.push([i, i*r]);
	}

var d7 = [];
for(var i = 0; i < 14; i++)
	{
		var r = Math.floor(Math.random() * 100);
		d7.push([i, r]);
}

var d1 = [[0, 180]];
var d2 = [[1, 45]];
var d3 = [[0, 45]];
var d4 = [[0, 45]];
var d5 = [[0, 45]];
var d6 = [[0, 45]];
var d7= [[0, 45]];