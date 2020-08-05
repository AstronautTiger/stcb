namespace Stcb
{
    public class AccountsCacheEntry
    {
        public string Name { get; set; }
        public string PreferredUsername { get; set; }
        public string TenantId { get; set; }
        public string LocalAccountId { get; set; }
        public string RawClientInfo { get; set; }

        public static AccountsCacheEntry ToCacheEntry(object obj)
        {
            return new AccountsCacheEntry
            {
                Name = obj.Get<string>("Name"),
                PreferredUsername = obj.Get<string>("PreferredUsername"),
                TenantId = obj.Get<string>("TenantId"),
                RawClientInfo = obj.Get<string>("RawClientInfo"),
                LocalAccountId = obj.Get<string>("LocalAccountId")
            };
        }
    }
    
}