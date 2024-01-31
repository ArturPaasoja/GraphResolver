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