using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {        
        // GET: /Calculator/
        [HttpGet]
        public ActionResult Index()
        {
            CalculatorModel calculator = CalculatorModel.Create();            

            return View(calculator);
        }

        [HttpPost]
        public ActionResult Calculate(CalculateData model)
        {
            CalculatorModel calculator = CalculatorModel.Create();
            calculator.Quantity = model.Quantity;

            calculator.Types["bit - b"] = calculator.Types["bit - b"] * model.Quantity / (BigInteger)model.Type;
            calculator.Types["Byte - B"] = calculator.Types["Byte - B"] * model.Quantity / (BigInteger)model.Type;
            calculator.Types["kilobit - Kb"] = calculator.Types["kilobit - Kb"] * model.Quantity / (BigInteger)model.Type;
            calculator.Types["Kilobyte - KB"] = calculator.Types["Kilobyte - KB"] * model.Quantity / (BigInteger)model.Type;
            calculator.Types["Megabit - Mb"] = calculator.Types["Megabit - Mb"] * model.Quantity / (BigInteger)model.Type;
            calculator.Types["Megabyte - MB"] = calculator.Types["Megabyte - MB"] * model.Quantity / (BigInteger)model.Type;
            calculator.Types["Gigabit - Gb"] = calculator.Types["Gigabit - Gb"] * model.Quantity / (BigInteger)model.Type;
            //calculator.Types["Gigabyte - GB"] = calculator.Types["Gigabyte - GB"] * model.Quantity / (decimal)model.Type;
            //calculator.Types["Terabit - Tb"] = calculator.Types["Terabit - Tb"] * model.Quantity / (decimal)model.Type;
            //calculator.Types["Terabyte - TB"] = calculator.Types["Terabyte - TB"] * model.Quantity / (decimal)model.Type;
            //calculator.Types["Petabit - Pb"] = calculator.Types["Petabit - Pb"] * model.Quantity / (decimal)model.Type;
            //calculator.Types["Petabyte - PB"] = calculator.Types["Petabyte - PB"] * model.Quantity / (decimal)model.Type;

            return View("_Calculate", calculator);
        }
	}
}