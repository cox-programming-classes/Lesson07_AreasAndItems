namespace TheWorld.GameMechanics;

public record ItemBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string? _id;

    private ItemBuilder() { }

    /// <summary>
    /// Start with a FROM method.  An item starts from the name of its archetype.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static ItemBuilder FromName(string name) => new() { _name = name };

    /// <summary>
    /// Start with a FROM method.  An item starts from the parts of an existing item, which can then be changed.
    /// </summary>
    public static ItemBuilder FromItem(Item item) => new() { _name = item.Name, _description = item.Description };

    /// <summary>
    /// Gives the item its own key, so that two items can share a name.
    /// </summary>
    public ItemBuilder WithId(string id) => this with { _id = id };

    /// <summary>
    /// Adds a description to the item being built.  This is optional, but recommended.
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public ItemBuilder WithDescription(string description) => this with { _description = description };

    /// <summary>
    /// Builds the item and adds it to the game data.
    /// </summary>
    /// <param name="gameData"></param>
    /// <returns>The new item's Id, or null if it couldn't be added.</returns>
    public string? Build(GameData gameData)
    {
        var item = new Item(_name, _description) { Id = _id ?? _name };
        if (gameData.TryAdd(item))
            return item.Id;

        return null;
    }
}
