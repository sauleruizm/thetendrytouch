var CategoryCreate = function () {
	var self = this;
	
	//Modelo
	self.Name = ko.observable();
	self.ID = ko.observable();

	self.Edit = function () {

	};

	self.Save = function () { };

};


$(function () {
	ko.applyBinding(new CategoryCreate());
});