﻿using ESKOBSite.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login() 
        {
            return View();
        }

        
        }