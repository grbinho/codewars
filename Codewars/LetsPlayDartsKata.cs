using System;
using System.Collections.Generic;

namespace Codewars
{
    /*
    The coordinates are (x, y) are always relative to the center of the board (0, 0). 
    The unit is millimeters. If you throw your dart 5 centimeters to the left and 3 centimeters below, 
    it is written as:
    var score = dartboard.GetScore(-50, -30);

    Possible scores are:
    Outside of the board: "X"
    Bull's eye: "DB"
    Bull: "SB"
    A single number, example: "10"
    A triple number: "T10"
    A double number: "D10"

    A throw that ends exactly on the border of two sections results in a bounce out. 
    You can ignore this because all the given coordinates of the tests are within the sections.

    The diameters of the circles on the dartboard are:

    Bull's eye: 12.70 mm
    Bull: 31.8 mm
    Triple ring inner circle: 198 mm
    Triple ring outer circle: 214 mm
    Double ring inner circle: 324 mm
    Double ring outer circle: 340 mm
    */

    public class Dartboard
    {

        private int GetScoreFromAngle(double angle)
        {
            // 360/20 => 18 degree steps 

            if(angle > 0 && angle <= 9) return 6;
            if(angle > 9 && angle <= 27) return 13;
            if(angle > 27 && angle <= 45) return 4;
            if(angle > 45 && angle <= 63) return 18;
            if(angle > 63 && angle <= 81) return 1;
            if(angle > 81 && angle <= 99) return 20;
            if(angle > 99 && angle <= 117) return 5;
            if(angle > 117 && angle <= 135) return 12;
            if(angle > 135 && angle <= 153) return 9;
            if(angle > 153 && angle <= 171) return 14;
            if(angle > 171 && angle <= 189) return 11;
            if(angle > 189 && angle <= 207) return 8;
            if(angle > 207 && angle <= 225) return 16;
            if(angle > 225 && angle <= 243) return 7;
            if(angle > 243 && angle <= 261) return 19;
            if(angle > 261 && angle <= 279) return 3;
            if(angle > 279 && angle <= 297) return 17;
            if(angle > 297 && angle <= 315) return 2;
            if(angle > 315 && angle <= 333) return 15;
            if(angle > 333 && angle <= 351) return 10;
            if(angle > 351 && angle <= 360) return 6;

            return 0;
        }

        public string GetScore(double x, double y)
        {
            // Start your coding here...

            // Angle determines the score. Distance from center determines if it's multiplied.
            // Bull and bulls eye are special cases (no angle necessary)

            var r = Math.Sqrt(x*x + y*y);
            if (r > 340.0/2.0) return "X";
            if (r <= 12.7/2.0) return "DB";
            if (r <= 31.8/2.0) return "SB";

            //Get the number
            //Calculate the angle
            var tang = y/x;
            var angle = Math.Atan(tang) * 180 / Math.PI;            
            if(x > 0 && y < 0) angle+=360;
            else if(x < 0 || y < 0) angle+=180;
            string score = GetScoreFromAngle(angle).ToString();

            if(r >= 198/2.0 && r<=214/2.0) return "T" + score;
            if(r >= 324/2.0 && r<=340/2.0) return "D" + score;
            
            return score;
        }

    }
}