namespace YVN.Services.Mesages
{
    public static class Constant_ExceptionMessages
    {

        public const string GENERAL_ERROR = "Something messed up. Please try again later!";


        public const string USER_NULL = "There is no such a User!";
        public const string FRIENDSLIST_NULL = "There is no friends in friendslist!";

        public const string POST_NULL = "There is no such a Post!";
        public const string COMMENT_NULL = "There is no such a Comment!";


        public const string PHOTO_NULL = "There is no such a Photo!";
        public const string PostNull = "Post cannot be empty.";
        public const string CommentNull = "Comment cannot be empty.";

        public const string COMMENT_TOO_LONG = "Comment cannot be longer than 4000 symbols!";
        public const string COMMENT_TOO_SHORT = "Comment cannot be shorter than 2 symbols!";

        public const string FRIEND_REQUEST_DOESNT_EXISTS = "";
        public const string FRIEND_REQUEST_ALREADY_EXISTS = "Friend request already exists.";
        public const string USER_ALREADY_IN_FRIENDLIST = "This user is already in your friendlist!";
    }
}
