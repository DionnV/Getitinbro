﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDD_Library.Shapes;

namespace GDD_Library
{
    /// <summary>
    /// This class hold the intelligence to create a shape.
    /// </summary>
    public abstract class GDD_Shape : ICloneable
    {
        /// <summary>
        /// Any object derived from this class should contain a Draw().
        /// </summary>
        /// <param name="G"></param>
        public abstract void Draw(Graphics G);

        /// <summary>
        /// Any object derived from this class should contain a ContainsPoint().
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract bool ContainsPoint(GDD_Point2F p);

        /// <summary>
        /// The size of this Square
        /// </summary>
        public float Size { get { return _Size; } set { this._Size = value; } }
        private float _Size = 1f;

        /// <summary>
        /// The Owner of this shape
        /// </summary>
        public GDD_Object Owner { get { return _Owner; } set { this._Owner = value; } }
        private GDD_Object _Owner;

        /// <summary>
        /// The color of the shape
        /// </summary>
        public SolidBrush DrawingColor { get { return _DrawingColor; } set { _DrawingColor = value; } }
        private SolidBrush _DrawingColor = new SolidBrush(Color.White);

        /// <summary>
        /// returns a clone of this object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static GDD_CollisionInfo Collides(GDD_Shape shape1, GDD_Shape shape2)
        {
            //Making 2 circle's collide
            if (shape1 is GDD_Circle)
            {  
                if (shape2 is GDD_Circle)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Circle)shape2);
                }
        
                if (shape2 is GDD_Polygon)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Polygon)shape2);
                }

                if (shape2 is GDD_Line)
                {
                    return GDD_CollisionInfo.get((GDD_Circle)shape1, (GDD_Line)shape2);
                
                }
            }
            return null;
        }      
    }
}
