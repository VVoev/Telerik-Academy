namespace SchoolSystem.CLI.Models.Contracts
{
    using SchoolSystemCli.Models.Enums;

    /// <summary>
    /// Represent the Mark students get from teachers on a current subject and also the Mark value
    /// </summary>
    public interface IMark
    {   
         float MarkExam { get;  }

         Subject Subject { get; }
    }
}
