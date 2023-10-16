namespace qr_signing_service_api.Models
{
    public class Token
    {
        public Token()
        {
                
        }
        public DateTime DateTime        { get; set; }
        public int      workspace_id    { get; set; }   
        public string   file_uuid       { get; set; }
    }
}
