using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypeInheritance
{
    interface IRenderable
    {
        string Render();
    }

    interface ICommentable
    {
        void AddComment(String user, String comment);
    }

    interface ILikeable
    {
        void Like();
        void Dislike();
        int LikesCount();
    }
    
    public readonly struct Post : IRenderable, ICommentable
    {
        private readonly string _text;
        private readonly List<KeyValuePair<String, String>> _comments;

        public Post(string text)
        {
            _text = text;
            _comments = new List<KeyValuePair<string, string>>();
        }
        
        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_text);
            sb.AppendLine("\tComments:");
            foreach (var pr in _comments)
            {
                sb.AppendLine($"\t\t{pr.Key}: {pr.Value}");
            }

            return sb.ToString();
        }

        public void AddComment(string user, string comment)
        {
            _comments.Add(new KeyValuePair<string, string>(user, comment));
        }
    }


    public struct LikeablePost : IRenderable, ICommentable, ILikeable
    {
        private readonly Post _basePost;
        private int _likes;

        public LikeablePost(Post basePost)
        {
            _basePost = basePost;
            _likes = 0;
        }
        
        public string Render()
        {
            return _basePost.Render();
        }
        
        public void AddComment(string user, string comment)
        {
            _basePost.AddComment(user, comment);
        }

        public void Like()
        {
            _likes++;
        }

        public void Dislike()
        {
            _likes--;
        }

        public int LikesCount()
        {
            return _likes;
        } 
    }
}