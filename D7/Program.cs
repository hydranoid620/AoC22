using D7;
using static CommonLib.CommonLib;

const int MAX_FOLDER_SIZE = 100000;
const int TOTAL_DISK_SPACE = 70000000;
const int REQUIRED_DISK_SPACE = 30000000;

var input = ReadFileMatrix<string>(args[0], ' ').Skip(1).Select(x => x.ToArray());

FolderNode rootNode = new(null, "/");
FolderNode currentNode = rootNode;

// Build directory tree
foreach (var line in input)
{
    if (line[0] == "$" && line[1] == "cd") // Is a command
    {
        currentNode = line[2] == ".." ? currentNode.Parent! : (FolderNode) currentNode.Children.Find(node => node.Name == line[2])!;
    }
    else // Is output (from ls)
    {
        currentNode.Children.Add(int.TryParse(line[0], out int size) ? 
                                     new FileNode(currentNode, size, line[1]) :
                                     new FolderNode(currentNode, line[1]));
    }
}

currentNode = rootNode;
var sizeTotal = 0;
FolderNode directoryToDelete = rootNode;

var currentNodes = currentNode.Children.Where(node => node is FolderNode).Cast<FolderNode>().ToList();
var nextNodes = new List<FolderNode>();
while (currentNodes.Count > 0)
{
    foreach (FolderNode node in currentNodes)
    {
        if (node.Size <= MAX_FOLDER_SIZE) sizeTotal += node.Size; // Part 1
        if (TOTAL_DISK_SPACE - rootNode.Size + node.Size >= REQUIRED_DISK_SPACE && node.Size < directoryToDelete.Size) directoryToDelete = node; // Part 2
        nextNodes.AddRange(node.Children.Where(n => n is FolderNode).Cast<FolderNode>().ToList());
    }

    currentNodes = nextNodes.Select(x => x).ToList();
    nextNodes.Clear();
}

Console.WriteLine(sizeTotal);
Console.WriteLine(directoryToDelete.Size);