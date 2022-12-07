using static CommonLib.CommonLib;

const int MAX_FOLDER_SIZE = 100000;

IEnumerable<string> input = ReadFileColumn<string>(args[0]).Skip(1); //TODO: switch to read file matrix, then dont need to do line splitting

FolderNode rootNode = new(null, "/");
FolderNode currentNode = rootNode;

// Build directory tree
foreach (string line in input)
{
    string[] splitLine = line.Split(' ');

    if (splitLine[0] == "$") // Is a command
    {
        if (splitLine[1] == "cd")
        {
            currentNode =  splitLine[2] == ".." ? currentNode.Parent! : (FolderNode) currentNode.Children.Find(node => node.Name == splitLine[2])!;
        }
    }
    else // Is output (from ls)
    {
        currentNode.Children.Add(int.TryParse(splitLine[0], out int size) ? 
                                     new FileNode(currentNode, size, splitLine[1]) :
                                     new FolderNode(currentNode, splitLine[1]));
    }
}

currentNode = rootNode;

var sizeTotal = 0;
var nodes = currentNode.Children.Where(node => node is FolderNode).Cast<FolderNode>().ToList();
var nodesToProcess = new List<FolderNode>();
while (nodes.Count > 0)
{
    foreach (var node in nodes)
    {
        if (node.Size <= MAX_FOLDER_SIZE) sizeTotal += node.Size;
        nodesToProcess.AddRange(node.Children.Where(n => n is FolderNode).Cast<FolderNode>().ToList());
    }

    nodes.Clear();
    nodes = nodesToProcess.Select(x => x).ToList();
    nodesToProcess.Clear();
}

Console.WriteLine(sizeTotal);
















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

    public void AddSize(int size)
    {
        Size += size;
        Parent?.AddSize(size);
    }
}

internal class FileNode : Node
{
    public FileNode(FolderNode? parent, int size, string name) : base(parent, size, name)
    {
    }
}

internal class FolderNode : Node
{
    public List<Node> Children { get; }

    public FolderNode(FolderNode? parent, string name) : base(parent, 0, name)
    {
        Children = new List<Node>();
    }
}