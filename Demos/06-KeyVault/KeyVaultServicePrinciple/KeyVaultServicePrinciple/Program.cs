﻿using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationContext = Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext;

namespace KeyVaultServicePrinciple
{
    class Program
    {
        static string appId = "868a1ddd-efec-4ae7-b258-e88cd88aff0f";
        static string appSecret = "eF98Q~cUAB2DZokQHX4VOd7NUd-hOY0UvS5dibHQ";
        static string tenantId = "0ec02b79-d89f-48c4-9870-da4a7498d887";

        static void Main(string[] args)
        {
            var kv = new KeyVaultClient(GetAccessToken);
            var secret = kv.GetSecretAsync("https://demoor01-kv.vault.azure.net/", "password")
                .GetAwaiter().GetResult();

            Console.WriteLine("The secret value is : " + secret.Value);

            Console.ReadLine();
        }

        public static async Task<string> GetAccessToken(string azureTenantId, string clientId, string redirectUri)
        {
            var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
            var credential = new ClientCredential(appId, appSecret);
            var tokenResult = await context.AcquireTokenAsync("https://vault.azure.net", credential);
            return tokenResult.AccessToken;
        }
    }
}
