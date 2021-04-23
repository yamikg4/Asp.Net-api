﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Data.Entity.Infrastructure;
using System.Net.Http;

namespace Student_info_API.Filters
{
    public class CustomException:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            if(actionExecutedContext.Exception is DbUpdateException)
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("You Have Wrong Choos TO Perform This Operation");
                actionExecutedContext.Response = response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("Data can not be send Null");
                actionExecutedContext.Response = response;
            }
        }
    }
}