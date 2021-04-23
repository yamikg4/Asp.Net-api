using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleInterest.Controller
{
    public class SipmleInterestController : ApiController
    {
        public double Calcluate(int p, int r, int n)
        {
            if (p >=0)
            {
                return p * r * n / 100;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, "INVALID PRINCIPAL AMOUNT"));
            }
        }
    }
}
