namespace _03.CableTVCompany
{
    using System;
    using System.Linq;

    public class Connection : IComparable
    {
        public Connection(int startHouse, int endHouse, int cost)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.Cost = cost;
        }

        public int StartHouse { get; set; }

        public int EndHouse { get; set; }

        public int Cost { get; set; }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            int costDifference = this.Cost.CompareTo((obj as Connection).Cost);

            if (costDifference == 0)
            {
                return this.StartHouse.CompareTo((obj as Connection).StartHouse);
            }

            return costDifference;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("start-house: {0} end-house: {1} cost: {2}", this.StartHouse, this.EndHouse, this.Cost);
        }
    }
}
