using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webAPIImageCrop.Models;

namespace webAPIImageCrop.Controllers
{
    public class CropController : ApiController
    {
        // GET: api/crop
        public string Get(string id)
        {
            var rightAngleCoordinate = GetRightAngleCoordinates(id);

            var allCoors = GetNonHypotenuseCoordinates(id, rightAngleCoordinate);

            List<string> coordinates = new List<string>();

            foreach (var coor in allCoors)
            {
                coordinates.Add(string.Format("{0}, {1}", coor.X, coor.Y));
            }

            return string.Join("|", coordinates.ToArray());
        }

        private Coordinate GetRightAngleCoordinates(string rowColumn)
        {
            var coor = new Coordinate();

            var row = rowColumn.Substring(0, 1);

            var column = int.Parse(rowColumn.Substring(1, rowColumn.Length - 1));

            var isEven = column % 2 == 0;

            coor.Y = GetYcoordinate(row, isEven);
            coor.X = GetXCoordinate(column);
            
            return coor;
        }

        private IEnumerable<Coordinate> GetNonHypotenuseCoordinates(string rowColumn, Coordinate rightAngleCoor)
        {
            var coors = new List<Coordinate>();
            var coor1 = new Coordinate();
            var coor2 = new Coordinate();

            var row = rowColumn.Substring(0, 1);

            var column = int.Parse(rowColumn.Substring(1, rowColumn.Length - 1));

            var isEven = column % 2 == 0;

            if (isEven)
            {
                coor1.X = (int.Parse(rightAngleCoor.X) - 1).ToString();
                coor1.Y = rightAngleCoor.Y;

                coor2.X = rightAngleCoor.X;
                coor2.Y = (int.Parse(rightAngleCoor.Y) + 1).ToString();
            } else
            {
                coor1.X = rightAngleCoor.X;
                coor1.Y = (int.Parse(rightAngleCoor.Y) - 1).ToString();

                coor2.X = (int.Parse(rightAngleCoor.X) + 1).ToString();
                coor2.Y = rightAngleCoor.Y;
            }


            coors.Add(rightAngleCoor);
            coors.Add(coor1);
            coors.Add(coor2);

            return coors;
        }

        private string GetXCoordinate(int column)
        {
            double val;
            val = column / 2;

            return ((int) Math.Floor(val)).ToString();
        }

        private string GetYcoordinate(string row, bool columnIsEven)
        {
            switch (row)
            {
                case "A":
                    return columnIsEven ? "0" : "1";
                case "B":                
                    return columnIsEven ? "1" : "2";
                case "C":               
                    return columnIsEven ? "2" : "3";
                case "D":               
                    return columnIsEven ? "3" : "4";
                case "E":                
                    return columnIsEven ? "4" : "5";
                case "F":                
                    return columnIsEven ? "5" : "6";
            }

            return "-1";
        }


    }
}