using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        Video video1 = new Video("Hunting Whitetail Deer", "John Hunter", 3600);
        Video video2 = new Video("Advanced Bow Hunting Techniques", "Jane Archer", 5400);
        Video video3 = new Video("Tracking and Stalking Game", "Emily Tracker", 4200);

       
        video1.AddComment(new Comment("Alice", "Great tips for beginners!"));
        video1.AddComment(new Comment("Bob", "Very informative and well presented."));
        video1.AddComment(new Comment("Charlie", "I bagged my first deer thanks to this!"));

        video2.AddComment(new Comment("Dave", "Excellent coverage of advanced techniques."));
        video2.AddComment(new Comment("Eve", "Could use more in-depth bow setup details."));
        video2.AddComment(new Comment("Frank", "Learned a lot about bow tuning!"));

        video3.AddComment(new Comment("Grace", "Tracking tips are spot on."));
        video3.AddComment(new Comment("Heidi", "Good content but a bit fast-paced."));
        video3.AddComment(new Comment("Ivan", "Loved the stalking strategies!"));

        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine(comment);
            }

            Console.WriteLine();
        }
    }
}