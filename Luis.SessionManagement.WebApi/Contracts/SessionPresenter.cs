namespace Luis.SessionManagement.WebApi.Contracts
{
    public class SessionPresenter
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int PresenterId { get; set; }
        public int Sequence { get; set; }
        public string SpeakerName { get; set; }
    }
}