var Sequelize = require("sequelize");
var context = new Sequelize("UserLogs", "lzlzlfybk", "vbjy73ert", {
	dialect: "mssql",
	host: "UserLogs.mssql.somee.com",
	define: {
		timestamps: false,
		freezeTableName: true
	}
});
// модель UserLog
const UserLog = context.define("UserLog", {
	Id: {
		type: Sequelize.INTEGER,
		autoIncrement: true,
		primaryKey: true,
		allowNull: false
	},
	CompName: {
		type: Sequelize.STRING
	},
	CustomNote: {
		type: Sequelize.STRING
	}
});

// модель UserAction
const UserAction = context.define("UserAction", {
	Id: {
		type: Sequelize.INTEGER,
		autoIncrement: true,
		primaryKey: true,
		allowNull: false
	},
	ActionDateTime: {
		type: Sequelize.STRING
	},
	AppTitle: {
		type: Sequelize.STRING
	},
	TextLog: {
		type: Sequelize.STRING
	},
	LogId: {
		type: Sequelize.INTEGER
	}
});
module.exports.AddClass = function(){
	UserLog.create({
		CompName: "TEST",
		CustomNote: "test"
	}).then(res=>{
		console.log(res);
	}).catch(err=>console.log(err));
}

module.exports.GetUser = function(req, res){
	UserAction.findAll({where:{LogId: 1}, raw: true })
	.then(users=>{
		//console.log(users);
		console.log(users);
		res.send(users);
		res.end();
	}).catch(err=>console.log(err));
	
}
