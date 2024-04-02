using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZipLink.Core;
using ZipLink.Core.Commons;
using ZipLink.Core.Entities;
using ZipLink.Infrastructure.Implementation;

namespace ZipLink.Infrastructure.Interfaces
{
    public class UrlServiceRepo : IUrlServiceRepo
    {
        private ApplicationDBContext _context;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlServiceRepo(ApplicationDBContext context, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateURL(string url)
        {
            string shortUrl;
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/" + "{0}";

            do shortUrl = string.Format(baseUrl, Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8));
            while (IsExist(shortUrl));

            _context.Urls.Add(new Url
            {
                LongURL = url,
                ShortURL = shortUrl,
            });

            _context.SaveChanges();

            return shortUrl;
        }

        public async Task<string?> GetURL(string id)
        {
            var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/{id}";
            var query = _context.Urls.AsNoTracking().FirstOrDefault(_ => _.ShortURL == url && !_.IsDeleted && _.ExpiryDateTime > DateTime.Now);

            if (query != null)
            {
                query.Numberofclicks += 1;
                _context.Urls.Update(query);
                await _context.SaveChangesAsync();
            }

            return query.LongURL ?? CustomMessages.URL_NOT_FOUND;
        }

        // Private Methods
        private bool IsExist(string url) =>
            _context.Urls.AsNoTracking().Any(_ => _.ShortURL == url);
    }
}
