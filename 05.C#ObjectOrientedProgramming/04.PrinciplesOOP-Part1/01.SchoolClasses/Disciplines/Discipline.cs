namespace _01.SchoolClasses.Disciplines
{
    public class Discipline
    {
        // Fields in class Discipline.
        private DisciplineEnum nameOfDiscipline;
        private int numberOfLessons;
        private int numberOfExercises;

        // Properties in class Discipline.
        public DisciplineEnum DisciplineName
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
        public Discipline(DisciplineEnum name, int lessons, int exercises)
        {
            this.DisciplineName = name;
            this.LessonsNumber = lessons;
            this.ExerciseNumber = exercises;
        }

        public override string ToString()
        {
            return string.Format("{0} (Lessons: {1}, Exercises: {2})",this.DisciplineName, this.LessonsNumber, this.ExerciseNumber);
        }
    }
}