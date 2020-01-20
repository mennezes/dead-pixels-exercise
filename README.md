# Dead Pixels Count
The goal of this algorithm is to count how many dead pixels groups there are in a monitor. A dead pixel group is a set of pixels where one pixel is horizontally or vertically adjacent to at least one pixel. The pixels are represented by 0 (good pixel) and 1 (bad pixel).
Example 1: ['1','1','0'],['0','1','0'],['0','0','1'] = 2

# Implementation
The implementation can be found on the project DeadPixels, class DeadPixels, method CountGroups. The method signature is `public int CountGroups(char[][] monitor)`
Basic validation is executed on the begining of the algorithm. If a pixel contains a value different than 0 or 1, it is considered as a good pixel (0).
## Complexity
The time complexity of the algorithm is **O(V×H)** and the space complexity is **O(2(VxH))** where **V** is the number of pixel lines of the monitor and **H** is the number of pixels per line.

# Tests
The project DeadPixels.Tests contains BDD tests with example data based on the requirements.

# Remarks
If we could change the data provided, we could decrease the complexity to **O(VxH)**. Currently, the algorithm keeps tracks of visited pixels in a matrix with equal size of the input. Alternatively, we could change the visited bad pixels to 0, as it is one of the conditions to backtrack and removing the need of keeping track of visited nodes. The time complexity would be the same, as calculations are only done on unvisited pixels.
