using System;

public class SimpleMathExam : Exam
{
    private int problemSolved;

    public int ProblemsSolved
    {
        get
        {
            return this.problemSolved;
        }
        set
        {
            if(value<0 || value > 10)
            {
                throw new ArgumentOutOfRangeException("Number should be in range between 1-10");
            }
            this.problemSolved = value;
        }
    }

    public SimpleMathExam(int problemsSolved)
    {

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved <= 2)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved>2 && ProblemsSolved<6)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved >9)
        {
            return new ExamResult(6, 2, 6, "Your skills overwhelm stackOVerflow");
        }

        return new ExamResult(0, 0, 0, "You sukzzzs");
    }
}
