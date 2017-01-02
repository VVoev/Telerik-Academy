namespace _01.Point3D
{
    using System;

    static class Distance
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double distanceX = firstPoint.X - secondPoint.X;
            double distanceY = firstPoint.Y - secondPoint.Y;
            double distanceZ = firstPoint.Z - secondPoint.Z;

            double distancePow = distanceX * distanceX + 
                                 distanceY * distanceY + 
                                 distanceZ * distanceZ;
            return Math.Sqrt(distancePow);
        }
    }
}
