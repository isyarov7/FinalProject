using System.ComponentModel;

namespace YVN.Models.Enums
{
    public enum Visability
    {
        [Description("Permission to be visible only to you")]
        Private = 0,

        [Description("Permission to be visible only for your friends.")]
        FriendsOnly = 1,

        [Description("Permission to be visible for all.")]
        Public = 2,
    }
}
