namespace RefactoringSourceProject
{
    /// <summary>
    /// A separate class, which can store the different player scores
    /// </summary>
    public class Score
    {
        private string nickname;
        private int points;

        public Score() 
        {
        }

        public Score(string nickname, int points)
        {
            this.nickname = nickname;
            this.points = points;
        }

        public string Nickname
        {
            get
            {
                return this.nickname;
            }

            private set
            {
                this.nickname = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                this.points = value;
            }
        }
    }
}
