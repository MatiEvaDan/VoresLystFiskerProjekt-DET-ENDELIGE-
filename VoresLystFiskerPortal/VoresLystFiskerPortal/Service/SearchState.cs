namespace VoresLystFiskerPortal.Service
{
    public class SearchState
    {
        public string Query { get; private set; } = "";

        public event Action OnChange;

        public void SetQuery(string q)
        {
            Query = q;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void ClearQuery()
        {
            Query = "";
            NotifyStateChanged();
        }
    }
}
