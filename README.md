# Dead Pixels Count
The goal of this algorithm is to count how many dead pixels groups there are in a monitor. A dead pixel group is a set of pixels where one pixel is horizontally or vertically adjacent to at least one pixel. The pixels are represented by 0 (good pixel) and 1 (bad pixel).
Example 1: ['1','1','0'],['0','1','0'],['0','0','1'] = 2

# Implementation
The implementation can be found on the project DeadPixels, class DeadPixels, method CountGroups. The method signature is `public int CountGroups(char[][] monitor)`
Basic validation is executed on the begining of the algorithm. If a pixel contains a value different than 0 or 1, it is considered as a good pixel (0).

# Tests
The project DeadPixels.Tests contains BDD tests with example data based on the requirements.
