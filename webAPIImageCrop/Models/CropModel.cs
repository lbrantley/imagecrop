using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAPIImageCrop.Models
{
    public class CropModel
    {
        public Coordinate RightAnglePoint { get; set; }
        public Coordinate UpperPoint { get; set; }
        public Coordinate LowerPoint { get; set; }
    }

    public class Coordinate
    {
        //Horizontal (left and right point position)
        public string X { get; set; }

        //Vertical (up and down point position
        public string Y { get; set; }
    }

    public class ImageGraphic
    {

    }

    public enum Row
    {
        A,
        B,
        C,
        D,
        E,
        F
    }

    public enum Column
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Tweleve
    }
}
