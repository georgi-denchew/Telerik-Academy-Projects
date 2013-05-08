using System;

public class SimpleMathExam : Exam
{  
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("Solved problems cannot be smaller than 0 and larger than 10");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: one problem solved.");
        }
        
        // Changed if statement --> it makes no sence to have 10 problems, but solving more than two results in exception???
        // Solving more than two problems should also result in excellent result
        else
        {
            return new ExamResult(6, 2, 6, "Excellent result: two problems solved.");
        }

        // The "Invalid problems solved" is removed --> we check for validation in the constructor
    }
}
