namespace _05.School
{
    public class Discipline
    {
        // Fields in class Discipline.
        private string nameOfDiscipline;
        private int numberOfLessons;
        private int numberOfExercises;

        // Properties in class Discipline.
        public string DisciplineName
        {
            get {return this.nameOfDiscipline ; }
            set { this.nameOfDiscipline = value; }
        }
        public int LessonsNumber
        {
            get { return this.numberOfLessons; }
            set { this.numberOfLessons = value; }
        }
        public int ExerciseNumber
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
        }

        // Constructor in class Discipline.
        public Discipline(string name, int lessons, int exercises)
        {
            this.DisciplineName = name;
            this.LessonsNumber = lessons;
            this.ExerciseNumber = exercises;
        }
    }
}