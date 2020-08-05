using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;

namespace Stcb
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SharedTokenCache Browser v0.0.1");
            Console.WriteLine("Shareware");
            Console.WriteLine();

            var credentials = new SharedTokenCacheCredential();

            var accounts = credentials
                .Get<object>("_client")
                .Get<object>("_client")
                .Get<object>("UserTokenCache")
                .Get<object>("_accessor") // This object contains some interesting stuff
                .Get<IDictionary>("_accountCacheDictionary"); // Like an account dictionary
                

            try
            {
                // Need to access credentials for it to create the InMemoryTokenCache object
                credentials.GetToken(new TokenRequestContext());
            } catch {} // It will cause an Exception if there is more than one in cache

            Console.WriteLine($"Found {accounts.Count} accounts in cache");
            WriteDictionary(accounts.ToDictionary(x => x.Key.ToString(), x => AccountsCacheEntry.ToCacheEntry(x.Value)));
        }

        private static void WriteDictionary(Dictionary<string, AccountsCacheEntry> accounts)
        {
            if (accounts.Count == 0) return;
            foreach (var entry in accounts)
            {
                Console.WriteLine($"[{entry.Key}]: ");
                Console.WriteLine($"\tName: {entry.Value.Name}");
                Console.WriteLine($"\tPreferredUserName: {entry.Value.PreferredUsername}");
                Console.WriteLine($"\tTenantId: {entry.Value.TenantId}");
                Console.WriteLine($"\tLocalAccountId: {entry.Value.LocalAccountId}");
                Console.WriteLine($"\tRawClientInfo: {entry.Value.RawClientInfo}");
                Console.WriteLine(); 
                Console.WriteLine();
            }
        }
    }
}
