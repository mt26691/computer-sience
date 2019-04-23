using System;

namespace Graph.Example._01.RoadAndLib
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/torque-and-development/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=graphs
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var cities = new int[6][];
            //cities[0] = new int[] { 1, 3 };
            //cities[1] = new int[] { 3, 4 };
            //cities[2] = new int[] { 2, 4 };
            //cities[3] = new int[] { 1, 2 };
            //cities[4] = new int[] { 2, 3 };
            //cities[5] = new int[] { 5, 6 };
            //roadsAndLibraries(6, 2, 5, cities);

            var cities = new int[3][];
            cities[0] = new int[] { 1, 2 };
            cities[1] = new int[] { 3, 1 };
            cities[2] = new int[] { 2, 3 };
            roadsAndLibraries(3, 2, 1, cities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">number of cities</param>
        /// <param name="c_lib">cost of libs</param>
        /// <param name="c_road">cost of roads</param>
        /// <param name="cities">that describe a bidirectional road that connects cities</param>
        /// <returns></returns>
        public static void roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            // if road cost >= lib cost, just build lib between city
            //if (c_road >= c_lib)
            //{
            //    return c_lib * n;
            //}

            Graph graph = new Graph(n, c_lib);

            for (int i = 0; i < cities.Length; i++)
            {
                graph.AddEdge(cities[i][0], cities[i][1], c_road);
            }
            
            graph.MinimumSpanningTree();
            Console.ReadLine();
        }
    }
}
