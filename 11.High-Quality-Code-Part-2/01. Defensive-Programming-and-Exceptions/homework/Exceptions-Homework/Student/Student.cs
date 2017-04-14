using System;
using System.Linq;
using System.Collections.Generic;
using Exceptions_Homework.Validator;

public class Student
{
    private string firstName;
    private string lastname;
    private IList<Exam> exams;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            Validator.IsStringNullOrEmptry(value, "Firstname");
            this.firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return this.lastname;
        }

        set
        {
            Validator.IsStringNullOrEmptry(value, "LastName");
            this.lastname = value;
        }
    }
    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }
        set
        {
            Validator.IsArrayNullOrEmpty(exams);
            this.exams = value;
        }
    }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
