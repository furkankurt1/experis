namespace Core.Utilities;

public static class Messages
{
    public const string TotalWinePriceExceedsLimit = "The total price of all wines cannot exceed 1000.";
    public const string LotteryNameInvalid = "Lottery name must be between 5 and 100 characters and cannot be empty.";
    public const string WineNameInvalid = "Wine name must be between 5 and 100 characters and cannot be empty.";
    public const string WinePriceInvalid = "Wine price must be between 1 and 1000.";
    public const string WineNamesMustBeUnique = "Wine names must be unique.";
    public const string AtLeastOneWineMustHaveHigherPrice = "At least one wine must have a price higher than all others.";
    public const string LotteryIsAlreadyExists = "A lottery with this name already exists.";

}