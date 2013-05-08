using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{    
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (firstName == null || firstName == string.Empty)
        {
            throw new ArgumentNullException("Student's first name cannot be null or an empty string");
        }

        if (lastName == null || lastName == string.Empty)
        {
            throw new ArgumentNullException("Student's last name cannot be null or an empty string");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IList<Exam> Exams { get; set; }

    // The fact that a student has no exams doesn't mean that the program should stop working
    // That's why exception handling is made
    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(string.Format("Exams check cannot be performed while the given student's ({0} {1}) exam list is null",
                this.FirstName, this.LastName));
        }

        try
        {
            if (this.Exams.Count == 0)
            {
                throw new ArgumentException();
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Student {0} {1} has no exams", this.FirstName, this.LastName);
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(string.Format("Cannot calculate average on missing exam's list for the student {0} {1}", this.FirstName, this.LastName));
        }

        // I had my doubts whether to throw an exception here or not.
        if (this.Exams.Count == 0)
        {
            // No exams => average is 0;
            return 0;
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
