using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using backend.Models;

namespace backend.Repository
{
    public class FileBlogPostStorage : IBlogPostStorage
    {
        private const string PostId = "PostId:";
        private const string Category = "Category:";
        private const string Title = "Title:";
        private const string ImageURL = "ImageURL:";
        private const string Date = "Date:";
        private const string Summary = "Summary:";
        private const string Body = "Body:";

        private readonly string _directoryPath;

        public FileBlogPostStorage(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public IEnumerable<BlogPostOverview> GetAll()
        {
            var posts = new List<BlogPostOverview>();
            foreach (var file in Directory.EnumerateFiles(_directoryPath))
            {
                var fileStream = new FileStream(file, FileMode.Open);
                using (var reader = new StreamReader(fileStream))
                {
                    var post = new BlogPostOverview();
                    post.Id = int.Parse(reader.ReadLine().Substring(PostId.Length));
                    post.Category = reader.ReadLine().Substring(Category.Length);
                    post.Title = reader.ReadLine().Substring(Title.Length);
                    post.ImageURL = reader.ReadLine().Substring(ImageURL.Length);
                    post.Date = (reader.ReadLine().Substring(Date.Length));
                    post.Summary = reader.ReadLine().Substring(Summary.Length);
                    posts.Add(post);
                }
            }
            return posts;
        }


        public BlogPost Get(int Id)
        {
            BlogPost post = new BlogPost();

            var fileStream = new FileStream(_directoryPath + Id + ".pst", FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            {
                post.Id = int.Parse(reader.ReadLine().Substring(PostId.Length));
                post.Category = reader.ReadLine().Substring(Category.Length);
                post.Title = reader.ReadLine().Substring(Title.Length);
                post.ImageURL = reader.ReadLine().Substring(ImageURL.Length);
                post.Date = (reader.ReadLine().Substring(Date.Length));
                post.Summary = reader.ReadLine().Substring(Summary.Length);
                post.Body = reader.ReadToEnd().Substring(Body.Length);
                return post;
            }
        }

    }
}