using DataManager;

namespace TestData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the first DEs example sheet
            Sheet differentialEquations1 = new Sheet([
                new Question(1, false, Progress.Finished, TriState.Yes),
                new Question(2, false, Progress.Finished, TriState.Yes),
                new Question(3, false, Progress.Finished, TriState.Yes),
                new Question(4, false, Progress.Finished, TriState.Yes),
                new Question(5, false, Progress.Finished, TriState.Yes),
                new Question(6, false, Progress.Finished, TriState.Yes),
                new Question(7, false, Progress.Finished, TriState.Yes),
                new Question(8, true, Progress.NotStarted, TriState.Maybe),
                new Question(9, true, Progress.NotStarted, TriState.No),
                new Question(10, false, Progress.Finished, TriState.Yes),
                new Question(11, false, Progress.InProgress, TriState.Yes),
                new Question(12, false, Progress.ThoughtAbout, TriState.Maybe),
                new Question(13, false, Progress.NotStarted, TriState.Yes),
                new Question(14, false, Progress.NotStarted, TriState.Yes),
            ], new DateOnly(2024, 10, 10), new DateOnly(2024, 10, 31), 1);
            Course differentialEquations = new Course("Differential Equations", [differentialEquations1]);
            Term IAMichaelmas = new Term(TermName.Michaelmas, [differentialEquations]);
            Part IA = new Part(PartName.IA, [IAMichaelmas]);
            Serialiser serialiser = new Serialiser("Data.xml");
            serialiser.Serialise([IA, new Part(PartName.IB, new List<Term>())]);

            Part[]? returnedData = serialiser.Deserialise();
        }
    }
}
