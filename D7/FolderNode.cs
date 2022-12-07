namespace D7;

internal class FolderNode : Node
{
    public List<Node> Children { get; }

    public FolderNode(FolderNode? parent, string name) : base(parent, 0, name)
    {
        Children = new List<Node>();
    }
}