﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDD_Library.Shapes;

namespace GDD_Library
{
    public class GDD_Object
    {
        /// <summary>
        /// Creating a new instance 
        /// </summary>
        /// <param name="Shape"></param>
        public GDD_Object(GDD_Shape Shape)
        {
            //Setting it's shape
            this.Shape = Shape;
        }

        /// <summary>
        /// Mass in Kg
        /// </summary>
        public float Mass { get { return this._Mass; } set { this._Mass = value; } }
        private float _Mass = 1f;

        /// <summary>
        /// The shape of this object
        /// </summary>
        public GDD_Shape Shape { get { return this._Shape;} set { this._Shape = value; this._Shape.Owner = this; }}
        private GDD_Shape _Shape = new GDD_Square();

        /// <summary>
        /// The velocity 
        /// </summary>
        public GDD_Vector2F Velocity { get { return this._Velocity; } set { this._Velocity = value; } }
        private GDD_Vector2F _Velocity = new GDD_Vector2F(0f, 0f);

        /// <summary>
        /// The rotation
        /// </summary>
        public GDD_Vector2F Rotation { get { return this._Rotation; } set { this._Rotation = value; } }
        private GDD_Vector2F _Rotation = new GDD_Vector2F(180f, 0f);

        /// <summary>
        /// The object's current location
        /// </summary>
        public GDD_Point2F Location { get { return this._Location; } set { this._Location = value; } }
        private GDD_Point2F _Location = new GDD_Point2F(0f, 0f);

        /// <summary>
        /// The font color of the object
        /// </summary>
        public Color FrontColor { get { return this._FrontColor; } set { this._FrontColor = value; this._FrontPen = new Pen(new SolidBrush(this._FrontColor)); } }
        private Color _FrontColor = Color.Black;

        /// <summary>
        /// The frontpen used for drawing
        /// </summary>
        public Pen FrontPen { get { return _FrontPen; }}
        private Pen _FrontPen = new Pen(new SolidBrush(Color.Black));

        /// <summary>
        /// The gravity Type
        /// </summary>
        public GDD_GravityType GravityType { get { return this._GravityType; } set { this._GravityType = value; } }
        private GDD_GravityType _GravityType = GDD_GravityType.Normal;
    }

    public enum GDD_GravityType
    {
        Static,
        Normal
    }
}
