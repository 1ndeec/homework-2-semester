// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw4;

/// <summary>
/// class for maximum spanning tree function.
/// </summary>
public class Routers
{
    /// <summary>
    /// maximum spanning tree function.
    /// </summary>
    /// <param name="pathInput"> path to input file. </param>
    /// <param name="pathOutput"> path to output file. </param>
    /// <exception cref="ArgumentNullException"> if null input data. </exception>
    /// <exception cref="ArgumentException"> if input graph is disconnected. </exception>
    public static void Optimum(string pathInput, string pathOutput)
    {
        var graph = new Dictionary<int, Dictionary<int, int>>();
        var sr = new StreamReader(pathInput);
        string current = sr.ReadLine()!;
        if (current == null)
        {
            throw new ArgumentNullException();
        }

        while (current != null)
        {
            string[] fragmentized = current.Split(" ").ToArray();
            int main = Convert.ToInt32(fragmentized[0][0..(fragmentized[0].Length - 1)]);
            if (!graph.ContainsKey(main))
            {
                graph.Add(main, new Dictionary<int, int>());
            }

            int currentVertex;
            int currentWeight;
            for (int i = 1; i < fragmentized.Length - 2; i += 2)
            {
                currentVertex = Convert.ToInt32(fragmentized[i]);
                currentWeight = Convert.ToInt32(fragmentized[i + 1][1..(fragmentized[i + 1].Length - 2)]);
                if (!graph.ContainsKey(currentVertex))
                {
                    graph.Add(currentVertex, new Dictionary<int, int>());
                }

                graph[main].Add(currentVertex, currentWeight);
            }

            currentVertex = Convert.ToInt32(fragmentized[^2]);
            currentWeight = Convert.ToInt32(fragmentized[^1][1..(fragmentized[^1].Length - 1)]);

            if (!graph.ContainsKey(currentVertex))
            {
                graph.Add(currentVertex, new Dictionary<int, int>());
            }

            graph[main].Add(currentVertex, currentWeight);
            current = sr.ReadLine()!;
        }

        sr.Close();

        if (!IsConnected(graph))
        {
            throw new ArgumentException("disconnected graph");
        }

        var maxGraph = new Dictionary<int, Dictionary<int, int>>();
        bool[] used = new bool[graph.Keys.Max() + 1];
        var queue = new PriorityQueue<(int, int, int), int>(Comparer<int>.Create((x, y) => y.CompareTo(x))); // previous vertex , next vertex , weight
        queue.Enqueue((graph.Keys.First(), graph.Keys.First(), 0), 0); // we well make one loop for root vertex and delete it later
        while (queue.Count != 0)
        {
            var currentEdge = queue.Dequeue();
            int previousVertex = currentEdge.Item1;
            int nextVertex = currentEdge.Item2;
            int weight = currentEdge.Item3;

            if (used[nextVertex])
            {
                continue;
            }

            used[nextVertex] = true;
            maxGraph.Add(nextVertex, new Dictionary<int, int>());
            maxGraph[previousVertex].Add(nextVertex, weight);

            foreach (var vertexWithWeight in graph[nextVertex])
            {
                queue.Enqueue((nextVertex, vertexWithWeight.Key, vertexWithWeight.Value), vertexWithWeight.Value);
            }
        }

        maxGraph[graph.Keys.First()].Remove(graph.Keys.First());

        var sw = new StreamWriter(pathOutput);

        foreach (var vertex in maxGraph)
        {
            if (vertex.Value.Count > 0)
            {
                sw.Write($"{vertex.Key}:");

                string textWithLast = string.Empty;

                foreach (var nextVertex in vertex.Value)
                {
                    textWithLast += $" {nextVertex.Key} ({nextVertex.Value}),";
                }

                sw.WriteLine(textWithLast[0..(textWithLast.Length - 1)]); // because we have extra ',' on the end
            }
        }

        sw.Close();
    }

    /// <summary>
    /// function that checks if graph is connected.
    /// </summary>
    /// <param name="graph"> graph in form of dictionary. </param>
    /// <returns> true if connected, false if not. </returns>
    private static bool IsConnected(Dictionary<int, Dictionary<int, int>> graph)
    {
        bool[] used = new bool[graph.Keys.Max() + 1];
        int currentVertex = graph.Keys.First();
        while (!used[currentVertex])
        {
            used[currentVertex] = true;
            foreach (var nextVertex in graph[currentVertex])
            {
                if (!used[nextVertex.Key])
                {
                    currentVertex = nextVertex.Key;
                    break;
                }
            }
        }

        foreach (var key in graph.Keys)
        {
            if (!used[key])
            {
                return false;
            }
        }

        return true;
    }
}