namespace OBiddable.Library.Bidding;

public class Entity
{
    public int? Id { get; private set; }
    public Entity(int? id)
    {
        Id = id;
    }

    public bool IsNew()
        => Id.HasValue == false;

    public bool IsOld()
        => Id.HasValue;
}
