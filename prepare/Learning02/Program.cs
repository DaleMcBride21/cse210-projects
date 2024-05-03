
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Job instances
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // Display job details
        job1.Display();
        job2.Display();

        // Create Resume instance
        Resume myResume = new Resume("Dale McBride");

        // Add jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display resume
        myResume.Display();
    }
}
