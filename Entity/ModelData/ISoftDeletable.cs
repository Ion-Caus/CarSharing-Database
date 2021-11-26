namespace Entity.ModelData
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}