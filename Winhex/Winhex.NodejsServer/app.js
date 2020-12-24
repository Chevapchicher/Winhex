const express = require("express");
const app = express();
var colors = require('colors');
const db = require("./db");

function postUpload(req, res){
	console.log(req.body);
	db.AddUserLog(req.body);
	res.end();
}
app.use(express.json());
app.get("/", db.GetUsers);
app.get("/download", db.GetUser);
app.post("/upload", postUpload);

app.listen(4545, "localhost", function(){console.log("Started".green)});
