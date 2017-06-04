using System;

namespace Codewars
{
    public class RectangleRotationKata
    {
        Line AB;
        Line BC;
        Line CD;
        Line DA;
		public int RectangleRotation(int a, int b)
		{
			//2 <= a <= 10000
			//2 <= b <= 10000			
            Point A = new Point(-a / 2.0, b / 2.0);
            Point B = new Point(a / 2.0, b / 2.0);
            Point C = new Point(a / 2.0, -b / 2.0);
            Point D = new Point(-a / 2.0, -b / 2.0);

            A.Rotate(45);
            B.Rotate(45);
            C.Rotate(45);
            D.Rotate(45);

            AB = new Line(A, B);
            BC = new Line(B, C);
            CD = new Line(C, D);
            DA = new Line(D, A); 

            var count = 0;
            var count_y_0 = 0;

			// Solve a determinant for a point and a line for all lines (A,B,C,D).
			// Point (p,q)

			//(x1 - p)*(y2 - q) - (x2-p)*(y1 -q) 
			// for A <= 0
			// for B <= 0
			// for C >= 0
			// for D >= 0

			//-max(Abs(x)) to +max(Abs(x))
			//-max(Abs(y)) to +max(Abs(y))
            var minX = -Math.Ceiling(Math.Abs(A.X));
            var maxX = Math.Ceiling(Math.Abs(A.X));
            var maxY = Math.Ceiling(Math.Abs(B.Y));

            for (var x = minX; x <= maxX; x++)                
            {
                var p = new Point(x, 0);
                if(CountPoint(p))
                {
                    count_y_0++;
                }                                               
            }            

            count+=count_y_0;            

            for (var y = 1; y <= maxY; y++){               
                //Just check the edges. If the edges are still in, double,
                //else remove the edges and check again
                var p1 = new Point(minX, y);
                var p2 = new Point(maxX, y);

                while((!CountPoint(p1) || !CountPoint(p2)) &&  minX <= maxX){
                    if(!CountPoint(p1)) minX += 1;
                    if(!CountPoint(p2)) maxX -= 1;

                    p1 = new Point(minX, y);
                    p2 = new Point(maxX, y);                    
                }

                if(CountPoint(p1) && CountPoint(p2))
                { 
                    var line = 0;                    
                    line += (int)(maxX - minX) + 1;                       
                    count+=line;      

                    Console.WriteLine($"Y:{y}\tX:[{minX},{maxX}]\tCount: {line}");
                }  

                maxX+=1;  
                minX-=1;              
            }
                          
            return count*2 - count_y_0;
        }

        public bool CountPoint(Point p){
            var orientation_AB = AB.PointOrientation(p);
            var orientation_BC = BC.PointOrientation(p);
            var orientation_CD = CD.PointOrientation(p);
            var orientation_DA = DA.PointOrientation(p);

            if(orientation_AB <= 0 &&
            orientation_BC <= 0 &&
            orientation_CD <= 0 &&
            orientation_DA <= 0)
            {                            
                return true;                       
            } 

            return false;      
        }

        public class Point {

            public double X { get; private set; }
            public double Y { get; private set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public void Rotate(double degrees)
            {
                var radians =  Math.PI * degrees / 180.0;
                var x = X * Math.Cos(radians) - Y * Math.Sin(radians);
                var y = X * Math.Sin(radians) + Y * Math.Cos(radians);

                X = x;
                Y = y;
            }
        }

        public class Line {

            public Point A { get; }
            public Point B { get; }

            public Line(Point a, Point b)
            {
                A = a;
                B = b;                    
            }
            			
            public double PointOrientation(Point C)
            {
                return (A.X - C.X) * (B.Y - C.Y) - (B.X - C.X) * (A.Y - C.Y);
            }
        }
    }
}
