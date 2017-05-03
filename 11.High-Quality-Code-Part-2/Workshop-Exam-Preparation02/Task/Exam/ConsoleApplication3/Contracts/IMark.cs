using SchoolSystem.Enums;

namespace SchoolSystem.Contracts
{
    public interface IMark
    {
        float CurrentMark { get; set; }

        Subject Subject { get; set; }
    }
}