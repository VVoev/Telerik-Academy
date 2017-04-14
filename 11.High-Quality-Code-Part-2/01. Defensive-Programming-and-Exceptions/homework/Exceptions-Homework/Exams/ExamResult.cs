using Exceptions_Homework.Validator;
using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            Validator.IsNumberNegative(value);
            this.grade = value;
        }
    }
    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            Validator.IsNumberNegative(value);
            this.minGrade = value;
        }
    }
    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            Validator.IsNumberNegative(value);
            this.maxGrade = value;
        }
    }
    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            Validator.IsStringNullOrEmptry(value, "Comments");
            this.comments = value;
        }
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
