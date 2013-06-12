namespace _14.LabyrinthFill
{
    class Example
    {
        static void Main(string[] args)
        {
            
            Labyrinth labyrinth = Labyrinth.Initialize();

            labyrinth.PrintInitialLabyrinth();
            labyrinth.FillLabyrinth();
            labyrinth.PrintCalculatedLabyrint();
        }
    }
}
