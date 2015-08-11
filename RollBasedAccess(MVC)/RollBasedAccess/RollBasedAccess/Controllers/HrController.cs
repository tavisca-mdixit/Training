using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RollBasedAccess.Models;
using PagedList;
using PagedList.Mvc;

namespace RollBasedAccess.Controllers
{
    [Authorize]
    public class HrController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("HR") == true)
                return RedirectToAction("AddRemark", "Hr");
            else
                return RedirectToAction("ShowRemarks", "Hr");

        }

        [AllowAnonymous]
        public ActionResult AddEmployee(Employee model)
        {
            if (HttpContext.User.IsInRole("HR") == true)
                return RedirectToAction("ShowRemarks", "Hr");
            else
                return View("AddEmployee");
        }

        [AllowAnonymous]
        public ActionResult SaveEmployee(Employee model)
        {
            model.JoiningDate = DateTime.UtcNow;
            var response = model.createEmployee();
            if (response.ResponseStatus.Code != "200")
            {

                ModelState.AddModelError("", "Employee could not be added");
            }
            else
            {
                // ModelState.("", "Employee could not be added");
            }
            return View("AddEmployee");
        }

        [AllowAnonymous]
        public ActionResult HrView(Employee model)
        {
            if (HttpContext.User.IsInRole("HR") == true)
                return RedirectToAction("ShowRemarks", "Hr");
            else
                return View("AddRemark");

        }

        [AllowAnonymous]
        public ActionResult AddRemark()
        {
            GetAllEmployeeResponse response = GetAllEmployeeResponse.getEmpList();
            if (response.ResponseStatus.Code != "200")
            {
                ModelState.AddModelError("", "Remark could not be added");
            }
            else
            {

                List<SelectListItem> empList = new List<SelectListItem>();
                foreach (var employee in response.EmpList)
                {
                    empList.Add(new SelectListItem { Value = employee.Id, Text = employee.FirstName + "  " + employee.LastName });
                }
                ViewBag.EmpList = empList;

            }
            return View("AddRemark");
        }

        [AllowAnonymous]
        public ActionResult SaveRemark(Remark model)
        {
            GetAllEmployeeResponse response = GetAllEmployeeResponse.getEmpList();
            if (response.ResponseStatus.Code != "200")
            {
                ModelState.AddModelError("", "Unable to process request ");
            }
            else
            {

                List<SelectListItem> empList = new List<SelectListItem>();
                foreach (var employee in response.EmpList)
                {
                    empList.Add(new SelectListItem { Value = employee.Id, Text = employee.FirstName + "  " + employee.LastName });
                }
                ViewBag.EmpList = empList;
            }
            string empId = Request["Employee"];
            model.createRemark(empId, model);
            return View("AddRemark");

        }

        [AllowAnonymous]
        public ActionResult ShowRemarks(int page = 1)
        {
            if (HttpContext.User.IsInRole("HR") == true)
                return RedirectToAction("ShowRemarks", "Hr");

            var responseCount = GetRemarkCountResponse.getCount((string)TempData["EmpId"]).Count;
            ViewBag.RowSize = (Convert.ToInt32(responseCount));
            ViewBag.PageSize = 3;
            var response = GetRemarkResponse.getRemark((string)TempData["EmpId"], page);
            if (response.ResponseStatus.Code != "200")
            {
                ModelState.AddModelError("", "Unable to process request ");
            }
            return View(response.RequestedRemark);
        }

    }
}
