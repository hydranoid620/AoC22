namespace D7;

internal class Node
{
    public FolderNode? Parent { get; }
    public int Size { get; private set; }
    public string Name { get; }

    internal Node(FolderNode? parent, int size, string name)
    {
        Parent = parent;
        AddSize(size);
        Name = name;
    }

    private void AddSize(int size)
    {
        Size += size;
        Parent?.AddSize(size);
    }
}