﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GDD_Library.Shapes
{
    public abstract class GDD_Polygon: GDD_Shape
    {
        /// <summary>
        /// Creates a new instance of GDD Polygon
        /// </summary>
        public GDD_Polygon()
        {
            //Initializing the points
            this.PolygonPoints = new GDD_Point2F[0];
        }

        /// <summary>
        /// The points of the polygon, normalized to a shape of 100 units
        /// </summary>
        public GDD_Point2F[] PolygonPoints { get; set; }

        /// <summary>
        /// Translating the polygon, applying owner's rotation and a scale
        /// </summary>
        /// <returns></returns>
        public PointF[] TranslatePolygonPoints()
        {
            return TranslatePolygonPoints(Owner.Rotation.Direction, this.Size / 100f, Owner.Location);
        }

        /// <summary>
        /// Translating the polygon, applying rotation and a scale
        /// </summary>
        /// <param name="Rotation">Rotation in degrees to rotate the Polygon for</param>
        /// <param name="Scale">The scale factor for the size</param>
        /// <returns></returns>
        public PointF[] TranslatePolygonPoints(float Rotation, float Scale, GDD_Point2F offset)
        {
            //Initializing result
            PointF[] result = new PointF[this.PolygonPoints.Length];

            //Initializing a vector and point that will do all the calculations for us
            GDD_Vector2F vector;
            GDD_Point2F dxdy;

            //Looping each point, translating the individual rotation and scale
            for (int i = 0; i < this.PolygonPoints.Length; i++)
            {
                //Creating a vector
                vector = this.PolygonPoints[i].ToVector();

                //Applying the rotation change
                vector.Direction += Rotation;

                //Applying the size change
                vector.Size *= Scale;

                //Translating to a dxdy
                dxdy = vector.ToDXDY();

                //Translating to a XY
                result[i] = new PointF(offset.x + dxdy.x, offset.y + dxdy.y);
            }

            //Returning the result
            return result;
        }

        /// <summary>
        /// Translating the polygon, applying rotation and a scale
        /// </summary>
        /// <param name="Rotation">Rotation in degrees to rotate the Polygon for</param>
        /// <param name="Scale">The scale factor for the size</param>
        /// <returns></returns>
        public GDD_Point2F[] TranslatePolygonGDDPoints(float Rotation, float Scale, GDD_Point2F offset)
        {
            //Initializing result
            GDD_Point2F[] result = new GDD_Point2F[this.PolygonPoints.Length];

            //Initializing a vector and point that will do all the calculations for us
            GDD_Vector2F vector;
            GDD_Point2F dxdy;

            //Looping each point, translating the individual rotation and scale
            for (int i = 0; i < this.PolygonPoints.Length; i++)
            {
                //Creating a vector
                vector = this.PolygonPoints[i].ToVector();
                
                //Applying the rotation change
                vector.Direction += Rotation;

                //Applying the size change
                vector.Size *= Scale;

                //Translating to a dxdy
                dxdy = vector.ToDXDY() ;

                //Translating to a XY
                result[i] = new GDD_Point2F(offset.x + dxdy.x, offset.y + dxdy.y);
            }

            //Returning the result
            return result;
        }

        /// <summary>
        /// Converts the polygon to a set of faces / lines
        /// </summary>
        /// <returns></returns>
        public GDD_Object[] TranslatePolygon_ToLines()
        {
            //Getting all the translated points
            GDD_Point2F[] Points = TranslatePolygonGDDPoints(Owner.Rotation.Direction, this.Size / 100f, Owner.Location);

            //Initializing a list of lines
            GDD_Object[] Lines = new GDD_Object[Points.Length];
        
            //Looping all the points, making lines and collisions
            for (int i = 0; i < Points.Count(); i++)
            {
                //Making a line
                Lines[i] = GDD_Line.Create(Points[i], Points[(i + 1) % Points.Length]);
                Lines[i].Rotation = new GDD_Vector2F(Lines[i].Rotation.Direction % 360f, Lines[i].Rotation.Size);
            }

            //Returning the lines
            return Lines;
        }

        /// <summary>
        /// Draws this shape on a Graphics g
        /// </summary>
        /// <param name="G"></param>
        public override void Draw(Graphics G)
        {
            //Draws the shape using the poligon data
            G.DrawPolygon(Owner.FrontPen, this.TranslatePolygonPoints(Owner.Rotation.Direction, Size / 100f, Owner.Location));
        }
    }
}