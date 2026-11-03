namespace TheWorld.GameMechanics;

public record AreaBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private IReadOnlyList<string> _items = [];

    private AreaBuilder() { }

    /// <summary>
    /// Start with a FROM method.  An area starts from the name of its archetype.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static AreaBuilder FromName(string name) => new() { _name = ValidateName(name) };

    /// <summary>
    /// Start with a FROM method.  An area starts from the parts of an existing area, which can then be changed.
    /// </summary>
    public static AreaBuilder FromArea(Area area) => new() { _name = area.Name, _description = area.Description, _items = area.Items };


    /// <summary>
    /// TODO: Start with a FROM method.  An area starts from a JSON string, which is parsed and modified.
    /// </summary>
    public static AreaBuilder FromJson(string json) =>
        throw new NotImplementedException("FromJson is not implemented yet.  It will be implemented in a future lesson.");

    /// <summary>
    /// Adds a description to the area being built.  This is optional, but recommended.
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public AreaBuilder WithDescription(string description) =>
        this with { _description = ValidateDescription(description) };

    /// <summary>
    /// TODO: We need to revisit CreatureBuilder so that they are added into the GameData!
    /// </summary>
    /// <param name="creature"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public AreaBuilder WithCreature(string creature) =>
        throw new NotImplementedException("WithCreature is not implemented yet.");

    public AreaBuilder WithItem(string item) => this with { _items = [.. _items, item] };

    /// <summary>
    /// Builds the area and adds it to the game data.
    /// </summary>
    /// <param name="gameData"></param>
    /// <returns>The new area's name, or null if it couldn't be added.</returns>
    public string? Build(GameData gameData)
    {
        var area = new Area(_name) { Description = _description, Items = _items };
        if (gameData.TryAdd(area))
            return area.Name;

        return null;
    }


    /// <summary>
    /// TODO:  Validate the name.  For now, just make sure it's not null or whitespace.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static string ValidateName(string name) =>
        name switch
        {
            var n when string.IsNullOrWhiteSpace(n) => "The Void",
            _ => name.Trim()
        };

    /// <summary>
    /// TODO:  Validate the description.  For now, just make sure it's not null or whitespace.
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    private static string ValidateDescription(string description) =>
        description switch
        {
            var d when string.IsNullOrWhiteSpace(d) => "A place of nothingness.",
            _ => description.Trim()
        };
}
