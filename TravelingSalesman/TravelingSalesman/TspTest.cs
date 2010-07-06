using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelingSalesman
{
    public static class TspTest
    {
        public static PointList Cycle = new PointList() {
            { 240, 50 },
            { 340, 100 },
            { 370, 170 },
            { 350, 260 },
            { 310, 300 },
            { 220, 300 },
            { 160, 250 },
            { 130, 180 },
            { 150, 100 }
        };

        public static PointList StraightLineSmall = new PointList() {
            { -21, 0 },
            { -5, 0 },
            { -1, 0 },
            { 0, 0 },
            { 1, 0 },
            { 3, 0 },
            { 11, 0 }
        };

        public static PointList StraightLine = new PointList(StraightLineSmall.ConvertAll(p => new Point(p.X * 25 + 550, p.Y + 250)));

        public static PointList RowsAndColumns = new PointList() {
            { 100, 100 },
            { 200, 100 },
            { 300, 100 },
            { 100, 199 },
            { 200, 199 },
            { 300, 199 }
        };

        
        public static PointList NearestNeighbor(PointList inputList)
        {
            return nearestNeighbor(inputList, inputList[(new Random()).Next(inputList.Count)]);
        }

        public static PointList NearestNeighborAll(PointList inputList)
        {
            return inputList.ConvertAll(point => nearestNeighbor(inputList, point)).OrderBy(path => CalculateCost(path)).ToList()[0];
        }

        private static PointList nearestNeighbor(PointList inputList, Point startingPoint)
        {
            Point last = startingPoint;
            PointList visited = new PointList() { last };
            PointList unvisited = inputList.Clone();
            unvisited.Remove(last);

            while (unvisited.Count > 0)
            {
                Point next = findClosestPair(unvisited.ConvertAll(p => new PairOfPoints(last, p))).B;
                visited.Add(next);
                unvisited.Remove(next);
                last = next;
            }

            visited.Add(visited[0]);

            return visited;
        }

        public static PointList ClosestPair(PointList inputList)
        {
            PointList endpoints = inputList.Clone();
            List<PointList> vertexChains = new List<PointList>();

            while (endpoints.Count > 2)
            {
                PairOfPoints closestPair = findClosestPair(forEachPair(endpoints).Where(pair => !inSameVertexChain(pair.A, pair.B, vertexChains)));

                PointList chainA = findChainWithEndpoint(closestPair.A, vertexChains);
                PointList chainB = findChainWithEndpoint(closestPair.B, vertexChains);

                if (chainA != null && chainB != null)
                {
                    vertexChains.Remove(chainA);
                    vertexChains.Remove(chainB);
                    chainA.Reverse();
                    vertexChains.Add(new PointList(chainA.Concat(chainB)));

                    endpoints.Remove(closestPair.A);
                    endpoints.Remove(closestPair.B);
                    continue;
                }

                if (chainB != null)
                {
                    closestPair = closestPair.Invert();
                    chainA = chainB;
                    chainB = null;
                }

                if (chainA != null)
                {
                    chainA.Insert(0, closestPair.B);
                    endpoints.Remove(closestPair.A);
                    continue;
                }

                vertexChains.Add(new PointList(new List<Point>() { closestPair.A, closestPair.B }));
            }

            if (vertexChains.Count > 1)
                throw new ApplicationException("More than one vertex chain was obtained.");

            vertexChains[0].Add(vertexChains[0][0]);

            return vertexChains[0];
        }

        public static PointList OptimalTsp(PointList inputList)
        {
            decimal minCost = decimal.MaxValue;
            PointList shortestPath = null;
            int cnt = 0;
            foreach (PointList permutation in AllPermutations(inputList))
            {
                decimal c = CalculateCost(permutation);
                if (c < minCost)
                {
                    minCost = c;
                    shortestPath = permutation;
                }
                cnt++;
            }

            shortestPath.Add(shortestPath[0]);

            return shortestPath;
        }

        public static PointList IncrementalInsertion(PointList inputList)
        {
            return incrementalInsertion(inputList, inputList[(new Random()).Next(inputList.Count)]);
        }

        public static PointList IncrementalInsertionAll(PointList inputList)
        {
            return inputList.ConvertAll(point => incrementalInsertion(inputList, point)).OrderBy(path => CalculateCost(path)).ToList()[0];
        }

        private static PointList incrementalInsertion(PointList inputList, Point startingPoint)
        {
            PointList pointsLeft = new PointList(inputList);
            pointsLeft.Remove(startingPoint);
            Point secondPoint = pointsLeft.OrderByDescending(point => Point.Distance(startingPoint, point)).ToList()[0];
            PointList path = new PointList() { startingPoint, secondPoint, startingPoint };
            pointsLeft.Remove(secondPoint);

            while (pointsLeft.Count > 0)
            {
                decimal maxDist = 0;
                int finalInsertionIndex = 0;
                Point farthestPoint = null;
                
                foreach (Point point in pointsLeft)
                {
                    decimal minDist = decimal.MaxValue;
                    int insertionIndex = 1;
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        decimal dist = Point.Distance(path[i], point) + Point.Distance(point, path[i + 1]);
                        if (dist < minDist)
                        {
                            minDist = dist;
                            insertionIndex = i + 1;
                        }
                    }

                    if (minDist > maxDist)
                    {
                        maxDist = minDist;
                        finalInsertionIndex = insertionIndex;
                        farthestPoint = point;
                    }
                }

                path.Insert(finalInsertionIndex, farthestPoint);
                pointsLeft.Remove(farthestPoint);
            }

            return path;
        }

        public static PointList RoughScan(PointList inputList)
        {
            int rowCount = (int)Math.Round(Math.Sqrt(inputList.Count) / 2f) * 2;
            
            decimal lowestY = inputList.Min(p => p.Y);
            decimal highestY = inputList.Max(p => p.Y);
            decimal rowHeight = (highestY - lowestY) / rowCount;
            
            List<int> rowIndices = new List<int>();
            for (int i = 0; i < rowCount; i++)
                rowIndices.Add(i);

            List<List<Point>> rows = rowIndices.ConvertAll(rowIndex => inputList.FindAll(point => point.Y >= (lowestY + rowHeight * rowIndex) &&
                                                                                                  point.Y < (lowestY + rowHeight * (rowIndex + 1))));
            rows[rows.Count - 1].AddRange(inputList.FindAll(point => point.Y == highestY));
            rows = rows.Where(r => r.Count > 0).ToList();
            
            PointList path = new PointList();
            for (int i = 0; i < rows.Count; i++)
            {
                PointList rowPath = new PointList(rows[i].OrderBy(point => point.X * (decimal)Math.Pow(-1f, i)));
                rowPath = nearestNeighbor(rowPath, rowPath[0]);
                rowPath.RemoveAt(rowPath.Count - 1);
                path.AddRange(rowPath);
            }

            path.Add(path[0]);
            return path;
        }

        public static PointList Scan(PointList inputList)
        {
            PointList result = new PointList(inputList);
            result.Sort((p, q) => p.Y.CompareTo(q.Y) != 0 ? p.Y.CompareTo(q.Y) : p.X.CompareTo(q.X));
            result.Add(result[0]);

            return result;
        }
        
        public static PointList RadialScan(PointList inputList)
        {
            PointList result = new PointList(inputList);
            Point origin = result[(new Random()).Next(result.Count)];

            result.Sort((p, q) => Point.Distance(origin, p).CompareTo(Point.Distance(origin, q)));
            result.Add(result[0]);

            return result;
        }

        public static PointList RandomPath(PointList inputList)
        {
            PointList pointsLeft = new PointList(inputList);
            PointList result = new PointList();
            Random rnd = new Random();

            while (pointsLeft.Count > 0)
            {
                Point p = pointsLeft[rnd.Next(pointsLeft.Count)];
                result.Add(p);
                pointsLeft.Remove(p);
            }

            result.Add(result[0]);

            return result;
        }


        public static decimal CalculateCost(PointList permutation)
        {
            decimal cost = 0m;
            for (int i = 0; i < permutation.Count - 1; i++)
                cost += Point.Distance(permutation[i], permutation[i + 1]);

            cost += Point.Distance(permutation[permutation.Count - 1], permutation[0]);

            return cost;
        }

        public static IEnumerable<PointList> AllPermutations(PointList inputList)
        {
            if (inputList.Count < 2)
                yield return inputList;
            else
                foreach (Point p in inputList)
                {
                    PointList shorterList = new PointList(inputList);
                    shorterList.Remove(p);
                    foreach (PointList permutation in AllPermutations(shorterList))
                    {
                        PointList newPermutation = new PointList(permutation);
                        newPermutation.Add(p);
                        yield return newPermutation;
                    }
                }
        }

        private static PairOfPoints findClosestPair(IEnumerable<PairOfPoints> pairs)
        {
            decimal minDist = decimal.MaxValue;
            PairOfPoints closestPair = null;
            foreach (PairOfPoints pair in pairs)
            {
                decimal d = pair.Distance;
                if (d < minDist)
                {
                    minDist = d;
                    closestPair = pair;
                }
            }
            return closestPair;
        }

        private static IEnumerable<PairOfPoints> forEachPair(PointList points)
        {
            for (int i = 0; i < points.Count - 1; i++)
                for (int j = i + 1; j < points.Count; j++)
                    yield return new PairOfPoints(points[i], points[j]);
        }

        private static bool inSameVertexChain(Point a, Point b, List<PointList> vertexChains)
        {
            foreach (PointList chain in vertexChains)
                if (chain.Contains(a) && chain.Contains(b))
                    return true;

            return false;
        }

        private static PointList findChainWithEndpoint(Point p, List<PointList> vertexChains)
        {
            foreach (PointList chain in vertexChains)
            {
                if (chain[0] == p)
                    return chain;
                if (chain[chain.Count - 1] == p)
                {
                    chain.Reverse();
                    return chain;
                }
            }
            return null;
        }
    }
}
