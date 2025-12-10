// -----------------CManager - Inlämningsuppgift C#-------------------
using CManager.Presentation.ConsoleApp.Controllers;
using CManager.Presentation.ConsoleApp.Interfaces;
using CManager.Presentation.ConsoleApp.Validators;

//create menu controller instance
var menuController = new MenuController();

//run menu
menuController.PrintMenu();