using System;
using System.Configuration;
using System.Web.Mvc;

namespace Capitu.Infra
{
    public static class MvcExtensions
    {
        public static string CDNContent(this UrlHelper helper, string contentPath)
        {
            //return Content(helper, contentPath, SecureConfigurationManager.Web_EnderecoCDN);
            var url = ConfigurationManager.AppSettings["Web_EnderecoCDN"];

            contentPath = contentPath ?? string.Empty;
            contentPath = contentPath.Replace("~/", "/");

            return String.Concat(url.TrimEnd('/'), "/", contentPath.TrimStart('/'));
        }
        
        private static string Content(UrlHelper helper, string contentPath, string url, bool sobrescreverHttps = true)
        {
            var request = helper.RequestContext.HttpContext.Request;

            var urlFrom = request.Url;

            if (urlFrom != null && !urlFrom.AbsoluteUri.Contains("www."))
            {
                url = url.Replace("www.", string.Empty);
            }

            if (request.IsSecureConnection && sobrescreverHttps)
            {
                url = url.Replace("http://", "https://");
            }

            if (String.IsNullOrEmpty(url))
            {
                throw new ConfigurationErrorsException();
            }

            contentPath = contentPath ?? string.Empty;
            contentPath = contentPath.Replace("~/", "/");

            return String.Concat(url.TrimEnd('/'), "/", contentPath.TrimStart('/'));
        }
    }
}
