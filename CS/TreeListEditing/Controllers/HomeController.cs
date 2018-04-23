using System;
using System.Web.Mvc;
using TreeListEditing.Models;

namespace TreeListEditing.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(EmployeesDataProvider.GetData());
        }
        public ActionResult TreeListPartial() {
            return TreeListPartialCore();
        }
        public ActionResult TreeListPartialCustom(string selectedNodesIDs) {
            if(!string.IsNullOrEmpty(selectedNodesIDs))
                ViewData["SelectedNodesIDs"] = selectedNodesIDs;
            return TreeListPartialCore();
        }
        public ActionResult TreeListPartialCore() {
            return PartialView("TreeListPartial", EmployeesDataProvider.GetData());
        }
    }
}