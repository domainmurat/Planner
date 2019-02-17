using Planner.DataAccess.PlannerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.MvcUI.Helper
{
    public class DropDownHelper
    {
        public static List<SelectListItem> ToSelectListItem(IList<Subject> list)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Value = "", Text = "Select" });

            foreach (var item in list)
            {
                selectListItems.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }

            return selectListItems;
        }
    }
}