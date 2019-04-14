namespace Sorting.Example04.Comparator
{
    class Checker
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-comparator-sorting/problem?h_l=interview&playlist_slugs%5B%5D%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D%5B%5D=sorting
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int comparator(Player a, Player b)
        {
            if (a.score > b.score)
            {
                return 1;
            }
            if (a.score < b.score)
            {
                return -1;
            }
            if (a.name == b.name)
            {
                return 0;
            }

            if (a.name == b.name)
            {
                return 0;
            }
            if (a.name.Length > b.name.Length)
            {
                return -1;
            }
            return 1;
        }
    };
}
