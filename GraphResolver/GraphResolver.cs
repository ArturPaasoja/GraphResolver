class Program
{
    static void Main()
    {
        List<Tuple<int, int>> graph = new List<Tuple<int, int>>
        {
            Tuple.Create(1, 2),
            Tuple.Create(1, 3),
            Tuple.Create(2, 4),
            Tuple.Create(3, 4),
            Tuple.Create(4, 5),
            Tuple.Create(4, 6)
        };

        List<List<int>> paths = GraphResolver.ConnectingPaths(graph, 1, 4);

        foreach (var path in paths)
        {
            Console.WriteLine("[" + string.Join(",", path) + "]");
        }
    }
}

class GraphResolver
{
    public static List<List<int>> ConnectingPaths(List<Tuple<int, int>> graph, int node1, int node2)
    {
        // Init variables
        List<List<int>> paths = new List<List<int>>();

        // Start finding path
        PathFinder(graph, node1, node2, paths, new List<int>());

        return paths;
    }

    private static void PathFinder(List<Tuple<int, int>> graph, int currentNode, int destinationNode, List<List<int>> paths, List<int> currentPath)
    {
        currentPath.Add(currentNode);

        // Check, if currentNodes has reached the destination
        if (currentNode == destinationNode)
        {
            paths.Add(new List<int>(currentPath));
        }
        else
        {
            foreach (var node in graph)
            {
                if (node.Item1 == currentNode)
                {
                    if (!currentPath.Contains(node.Item2))
                    {
                        PathFinder(graph, node.Item2, destinationNode, paths, currentPath);
                    }
                }
            }
        }

        // Backtrack for other nodes
        currentPath.Remove(currentNode);
    }
}