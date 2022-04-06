using System;
using Microsoft.AspNetCore.Http;

namespace CarsLandIntex.Infastructure
{
    public static class UrlExtensions
    {
        //this gets the url so that a shopper can click continue shopping and go back to where they were
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();

    }
}
