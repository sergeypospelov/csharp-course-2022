using System;

namespace ValueTypeInheritance
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var post = new Post("Hello, world!");
            post.AddComment("Vanya", "very nice");
            post.AddComment("Vasya", "very bad");
            
            Console.Out.WriteLine($"{post.Render()}");
            
            var likeablePost = new LikeablePost(post);
            
            likeablePost.Like();
            likeablePost.AddComment("Petya", "normal");

            Console.Out.WriteLine($"{likeablePost.Render()}\n\t{likeablePost.LikesCount()} likes");

            Console.Out.WriteLine($"{post.Render()}");
        }
    }
}