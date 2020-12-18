const express = require("express");
const app = express();
var colors = require('colors');
const db = require("./db");

function getRoot(req, res){
	var acts = db.GetUser();
	console.log("---");
	console.log(acts);
	res.send(acts);
	res.end();
}
function postDownload(req, res){
	console.log(req.body);
	db.AddClass();
	res.sendStatus(200);
	res.end();
}
app.use(express.json());
app.get("/", db.GetUser);
app.post("/download", postDownload);

app.listen(4545, "localhost", function(){console.log("Started".green)});
