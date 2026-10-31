namespace TheWorld.GameMechanics;

/// <summary>
/// All the data in the game!
/// This is the one place where all the Areas, Items, and Creatures are stored, each one under its key.
/// An item's key is its Id.  Areas and creatures still use their names, for now.
/// It is injected into every builder, so that they can add their new creations to the game data.
///
/// TODO: we need to add Players here too, so that we can save and load the game state eventually.
/// </summary>
public record GameData
{
    /// <summary>
    /// All the Area's in the game!
    /// </summary>
    private Dictionary<string, Area> Areas { get; init; } = [];

    /// <summary>
    /// All the Item's in the game!
    /// </summary>
    private Dictionary<string, Item> Items { get; init; } = [];

    /// <summary>
    /// All the Creature's in the game!
    /// </summary>
    private Dictionary<string, Creature> Creatures { get; init; } = [];

    //--------------------------------------------------------------
    //  Methods for adding and retrieving Areas, Items, and Creatures.
    // TODO:  This is a very simple implementation.  It does not handle duplicates, and it does not handle errors.  It is just a starting point.
    //--------------------------------------------------------------

    // Three methods named TryAdd.  They're Overloads:  C# picks one by the type you hand it.
    public bool TryAdd(Area area) => Areas.TryAdd(area.Name, area);
    public bool TryAdd(Item item) => Items.TryAdd(item.Id, item);
    public bool TryAdd(Creature creature) => Creatures.TryAdd(creature.Name, creature);

    //--------------------------------------------------------------
    //  Methods for retrieving Areas, Items, and Creatures by their key.
    // TODO:  This is a very simple implementation.  It does not handle errors.  It is just a starting point.
    //--------------------------------------------------------------
    public Area? GetArea(string name) => Areas.GetValueOrDefault(name);
    public Item? GetItem(string id) => Items.GetValueOrDefault(id);
    public Creature? GetCreature(string name) => Creatures.GetValueOrDefault(name);
}
