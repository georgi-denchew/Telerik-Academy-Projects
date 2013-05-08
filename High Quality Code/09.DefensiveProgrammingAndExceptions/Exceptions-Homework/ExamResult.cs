using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade value should be larger than 0");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimal grade value should be larger than 0");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade value should be larger than minimal grade value");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("Comments cannot be null or an empty string");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
