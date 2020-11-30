using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.CommonModel
{
    public class PayloadResponse
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PayloadResponse()
        {
            _httpContextAccessor = new HttpContextAccessor();
            this.RequestURL = _httpContextAccessor.HttpContext != null ? $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}{_httpContextAccessor.HttpContext.Request.Path}" : "";
        }
        public bool Success { get; set; }
        public string RequestTime { get; set; }
        public string ResponseTime { get; set; }
        public string RequestURL { get; set; }
        public List<string> Message { get; set; }
        public dynamic Payload { get; set; }
        public string PayloadType { get; set; }
    }
}
