
namespace DomainModel.Model
{
    public class TotpRestoreAccess
    {
        public int UserId { get; set; }
        public string SecretKey { get; set; }
        public byte[] SecretKeyByte { get; set; }
        public User User { get; set; }
    }
}
