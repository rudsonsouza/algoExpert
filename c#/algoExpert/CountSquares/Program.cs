// See https://aka.ms/new-console-template for more information

/*
 * Count Squares
 *
 * Write a function that takes in a list of Cartesian coordinates(i.e., (x,y) coordinates) and returns the number of squares
 * that can be formed by these coordinates.
 *
 * A square must have its four corners amongst the coordinates in order to be counted. A single coordinate can be used as a
 * corner for multiple different squares.
 *
 * You can also assume that no coordinate will be farther than 100 units from the origin.
 */

Console.WriteLine("Hello, World!");

var points = new int[][] {
 new int[] { 1, 1 },
 new int[] { 0, 0 },
 new int[] { 0, 1 },
 new int[] { 1, 0 }
};

CountSquares(points);

int CountSquares(int[][] points)
{
   HashSet<string> pointsSet = new HashSet<string>();
   foreach (var point in points)
   {
       pointsSet.Add(pointToString(point));
   }

   int count = 0;
   foreach (var pointA in points)
   { 
    foreach (var pointB in points)
    {
      if (pointA == pointB) continue;
     
      double[] midPoint = new double[] { (pointA[0] + pointB[0]) / 2.0 , (pointA[1] + pointB[1]) / 2.0 };
      double xDistanceFromMid = pointA[0] - midPoint[0];
      double yDistanceFromMid = pointA[1] - midPoint[1];

      double[] pointC = new double[] { midPoint[0] + yDistanceFromMid, midPoint[1] - xDistanceFromMid };
      double[] pointD = new double[] { midPoint[0] - yDistanceFromMid, midPoint[1] + xDistanceFromMid };

      if (pointsSet.Contains(dbPointToString(pointC)) && pointsSet.Contains(dbPointToString(pointD))) count++;
    }
   }

   return count / 4;
}

string pointToString(int[] point)
{
 return point[0] + "," + point[1];
}

string dbPointToString(double[] point)
{
 if (point[0] % 1 == 0 && point[1] % 1 == 0)
  return (int)point[0] + "," + (int)point[1];
 
 return point[0] + "," + point[1];
}