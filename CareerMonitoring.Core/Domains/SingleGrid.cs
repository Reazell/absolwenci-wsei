namespace CareerMonitoring.Core.Domains {
    public class SingleGrid {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public bool[, ] Table { get; private set; }
        public SingleGrid (string title, int rows, int cols) {
            Title = title;
            Rows = rows;
            Cols = cols;
            Table = new bool[Rows, Cols];
        }
    }
}