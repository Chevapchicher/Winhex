var Sequelize = require("sequelize");
var context = new Sequelize("UserLogs", "lzlzlfybk", "vbjy73ert", {
	dialect: "mssql",
	host: "UserLogs.mssql.somee.com",
	define: {
		timestamps: false,
		freezeTableName: true
	}
});

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
module.exports.AddClass = function(){
	UserLog.create({
		CompName: "TEST",
		CustomNote: "test"
	}).then(res=>{
		console.log(res);
	}).catch(err=>console.log(err));
}
