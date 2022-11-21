namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OpertaionClaimId { get; set; }
    }
}
