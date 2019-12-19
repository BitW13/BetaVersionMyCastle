namespace Common.Entity.ProfileService
{
    public static class ProfileServiceDefaultValues
    {
        public static class AccountDefaultValues
        {
            public static Account Account
            {
                get
                {
                    return new Account
                    {
                        Id = 0,
                        UserId = "",
                        UserName = "",
                        Icon = null
                    };
                }
            }

            public static Account IsValidForCreating(Account item)
            {
                if(item.Id != 0)
                {
                    item.Id = Account.Id;
                }

                if(string.IsNullOrEmpty(item.UserId))
                {
                    return null;
                }

                if(string.IsNullOrEmpty(item.UserName))
                {
                    return null;
                }

                if(item.Icon == null)
                {
                    return null;
                }

                return item;
            }

            public static Account IsValidForEdit(Account item)
            {
                if (item.Id <= 0) { return null; }

                if (string.IsNullOrEmpty(item.UserId)) { return null; }

                if (string.IsNullOrEmpty(item.UserName)) { return null; }

                if (item.Icon == null) { return null; }

                return item;
            }
        }
    }
}
