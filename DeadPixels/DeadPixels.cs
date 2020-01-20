using System;
using System.Linq;

namespace DeadPixels
{
    public class DeadPixels
    {
        /// <summary>
        /// Counts how many dead pixels groups are in a monitor
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns></returns>
        public int CountGroups(char[][] monitor)
        {
            if (monitor == null) throw new ArgumentNullException("monitor");
            if (monitor.Length == 0) throw new ArgumentException("The monitor must contain at least 1 pixel");
            if (monitor.Length > 4320) throw new ArgumentException("The monitor must contain less than 4320 vertical pixels");
            if (monitor.Any(row => row.Length == 0 || row.Length > 7680)) throw new ArgumentException("The monitor horizontal pixels count must be between 1 and 7680 pixels");

            // Stores the DeadPixels group count
            int count = 0;

            // Keeps track of visited pixels
            bool[][] visited = new bool[monitor.Length][];
            for (int i = 0; i < monitor.Length; i++) visited[i] = new bool[monitor[i].Length];

            // Iterate through all pixels
            for (int y = 0; y < monitor.Length; y++)
            {
                for (int x = 0; x < monitor[y].Length; x++)
                {
                    count += CountGroupsRecursive(y, x);
                }
            }

            return count;

            // Internal function to perform a DFS search with the first found dead pixel as a root node
            int CountGroupsRecursive(int y, int x)
            {
                // Validate the range of the matrix (or if we visited it before)
                if (y < 0 || y >= monitor.Length || x < 0 || x >= monitor[y].Length || visited[y][x]) return 0;

                // Marks as visited
                visited[y][x] = true;

                // Checks if it is a bad pixel
                if (monitor[y][x] == '1')
                {
                    // Iterate through horizontally/vertically adjacent pixels
                    // If they are dead pixels, they'll be marked as visited, but the count of groups will still be one
                    CountGroupsRecursive(y - 1, x); // Up
                    CountGroupsRecursive(y + 1, x); // Down
                    CountGroupsRecursive(y, x - 1); // Left
                    CountGroupsRecursive(y, x + 1); // Right

                    // This is a bad pixel group
                    return 1;
                }

                // Not a bad pixel
                return 0;
            }
        }
    }
}