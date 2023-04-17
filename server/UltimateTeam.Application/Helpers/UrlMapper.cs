using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;

namespace UltimateTeam.Application.Helpers
{
    public static class UrlMapper
    {
        public static List<Url> Map(string urls, Guid id)
        {
            var urlList = new List<Url>();

            if (string.IsNullOrEmpty(urls))
            {
                return urlList;
            }

            var urlArray = urls.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var url in urlArray)
            {
                urlList.Add(new Url
                {
                    CredentialId = id,
                    Address = url
                });
            }

            return urlList;
        }

        public static List<string> Map(List<Url> urls)
        {
            var urlList = new List<string>();

            foreach (var url in urls)
            {
                urlList.Add(url.Address);
            }

            return urlList;
        }
    }
}