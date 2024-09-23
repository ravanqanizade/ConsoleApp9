public class BaseEntity
{
    public int Id { get; set; }
    public DateTime InsertionDate { get; set; }
    public DateTime UpdateionDate { get; set;}
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}