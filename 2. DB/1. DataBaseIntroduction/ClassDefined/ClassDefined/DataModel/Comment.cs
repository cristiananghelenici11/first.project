using System;

namespace ClassDefined.DataModel
{
    public class Comment
    {
        public User Author
        {
            get => new User();
            set
            {
            }
        }

        public DateTimeOffset Date
        {
            get => DateTimeOffset.Now;
            set
            {
            }
        }

        public int? Likes
        {
            get => default(int);
            set
            {
            }
        }

        public string Text
        {
            get => default(string);
            set
            {
            }
        }

        public CommentType Type
        {
            get => default(int);
            set
            {
            }
        }

    }
}