using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


// Should not get an exception based on the asserts
Should_Print_Spiral();

[Fact]
void Should_Print_Spiral()
{
    var matrix = new int[][] {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 } };
    var expectedResult = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
    var result = SpiralOrder(matrix);
    Assert.True(expectedResult.SequenceEqual(result));


    matrix = new int[][] {
                new int[]{ 1, 2, 3, 4 },
                new int[]{ 5, 6, 7, 8 },
                new int[]{ 9, 10, 11, 12 } };
    expectedResult = new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };
    result = SpiralOrder(matrix);
    Assert.True(expectedResult.SequenceEqual(result));
}

IList<int> SpiralOrder(int[][] matrix)
{
    var flatMap = new List<int>();
    int top = 0, bottom = matrix.Length - 1, left = 0, right = matrix[0].Length - 1;
    int dir = 0;
    while (top <= bottom && left <= right)
    {
        if (dir == 0)
        {
            for (var x = left; x <= right; x++)
                flatMap.Add(matrix[top][x]);
            dir = 1;
            top++;
        }
        else if (dir == 1)
        {
            for (var x = top; x <= bottom; x++)
                flatMap.Add(matrix[x][right]);
            dir = 2;
            right--;
        }
        else if (dir == 2)
        {
            for (var x = right; x >= left; x--)
                flatMap.Add(matrix[bottom][x]);
            dir = 3;
            bottom--;
        }
        else if (dir == 3)
        {
            for (var x = bottom; x >= top; x--)
                flatMap.Add(matrix[x][left]);
            dir = 0;
            left++;
        }
    }
    return flatMap;
}