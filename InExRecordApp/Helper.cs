using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InExRecordApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InExRecordApp
{
    public static class Helper
    {
        public static List<SelectListItem> GetMonths()
        {
            List<SelectListItem> months = new List<SelectListItem>()
            {
                new SelectListItem("January", "January"),
                new SelectListItem("February", "February"),
                new SelectListItem("March", "March"),
                new SelectListItem("April", "April"),
                new SelectListItem("May", "May"),
                new SelectListItem("June", "June"),
                new SelectListItem("July", "July"),
                new SelectListItem("August", "August"),
                new SelectListItem("September", "September"),
                new SelectListItem("October", "October"),
                new SelectListItem("November", "November"),
                new SelectListItem("December", "December")
            };
            return months;
        }
        public static List<SelectListItem> GetYears()
        {
            List<SelectListItem> months = new List<SelectListItem>()
            {
                new SelectListItem("2001", "2001"),
                new SelectListItem("2002", "2002"),
                new SelectListItem("2003", "2003"),
                new SelectListItem("2004", "2004"),
                new SelectListItem("2005", "2005"),
                new SelectListItem("2006", "2006"),
                new SelectListItem("2007", "2007"),
                new SelectListItem("2008", "2008"),
                new SelectListItem("2009", "2009"),
                new SelectListItem("2010", "2010"),
                new SelectListItem("2011", "2011"),
                new SelectListItem("2012", "2012"),
                new SelectListItem("2013", "2013"),
                new SelectListItem("2014", "2014"),
                new SelectListItem("2015", "2015"),
                new SelectListItem("2016", "2016"),
                new SelectListItem("2017", "2017"),
                new SelectListItem("2018", "2018"),
                new SelectListItem("2019", "2019"),
                new SelectListItem("2020", "2020"),
                new SelectListItem("2021", "2021"),
                new SelectListItem("2022", "2022"),
                new SelectListItem("2023", "2023"),
                new SelectListItem("2024", "2024"),
                new SelectListItem("2025", "2025")
            };
            return months;
        }
    }
}
