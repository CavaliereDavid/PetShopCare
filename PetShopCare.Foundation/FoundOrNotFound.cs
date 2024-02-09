namespace PetShopCare.Foundation;

public abstract record FoundOrNotFound<T>();

public record Found<T>(T Item) : FoundOrNotFound<T>;

public record NotFound<T>() : FoundOrNotFound<T>;