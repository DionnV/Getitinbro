﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GDD_Library;
using GDD_Library.Shapes;
using GDD_Library.LevelDesign;
using System.Diagnostics;
using GDD_Library.Obstacles;


namespace GDD_Game_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //The circle that will be falling
        GDD_Object circle1 = new GDD_Object(new GDD_Circle());

        //The bucket that will be the end of the level
        GDD_Object bucket = new GDD_Object(new GDD_Bucket());
       
        /// <summary>
        /// All the lines that needs to be added
        /// </summary>
        List<GDD_Object> Lines = new List<GDD_Object>();

        /// <summary>
        /// The preview for a straight line
        /// </summary>
        GDD_Object Line_Preview = new GDD_Object(new GDD_Line());
        
        /// <summary>
        /// The delegate for calling reset
        /// </summary>
        private delegate void ResetDelegate();

        /// <summary>
        /// Resetting the level to it's org
        /// </summary>
        private void Reset()
        {
            //Lines.Clear();
            
            //Creating the scene and adding the square
            GDD_View1.Scene.Objects.Clear();

            //The bounce test
            BucketTest();
            //BounceTest();
            //AngularMomentumTest();
            //LineTest2();
            //LineTest();          
            //ZoneTest();
            //LevelTest();
 //           GDD_Level DemoLevel = new GDD_Level();
 //           DemoLevel.LoadNoDraw("C:/Users/Dion/Documents/Visual Studio 2010/Projects/BallZ2D/GDD_Game_Window/bg.png");
            //Only do this once
   /*
            if (!done)
            {
                try
                {
                    GDD_Level demo = GDD_IO.Load(1, levelno);
                    List<GDD_Object> newlist = new List<GDD_Object>();
                    foreach (GDD_Object obj in demo.Objects)
                    {
                        GDD_Object temp = new GDD_Object(obj.Shape);
                        temp.Location = obj.Location;
                        temp.Shape.Size = obj.Shape.Size;
                        temp.Mass = obj.Mass; ;
                        temp.Rotation = obj.Rotation;
                        temp.Velocity = obj.Velocity;
                        temp.GravityType = obj.GravityType;
                        newlist.Add(temp);
                    }
                    GDD_View1.Scene.Objects = newlist;
                    foreach (GDD_Object c in GDD_View1.Scene.Objects)
                    {
                        if (c.Shape is GDD_Circle)
                        {
                            circle1 = c;
                        }
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                levelno++;
                if (levelno > 10)
                {
                    done = true;
                }
            }
    */
            //Setting bacvkground
            //GDD_View1.BackgroundImage = Image.FromFile("bg.png");

            //Default size?
            this.ClientSize = new Size(800, 480) ;
 
            //Looping each object adding them again
            foreach (GDD_Object obj in Lines)
            {
                GDD_View1.Scene.Objects.Add(obj);
            }

            //The buttons need to be reset
            button_Reset.Visible = false;
            button_GO.Visible = true;

            //We don't want the circle to fall just yet
            circle1.GravityType = GDD_GravityType.Static;
        }


        GDD_Point2F Line_Start;
        GDD_Point2F Line_End;

        private void GDD_View1_MouseDown(object sender, MouseEventArgs e)
        {

            if (!GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X,e.Y), GDD_ZoneType.NoDraw))
            {
                //Recording the start of the Line
                Line_Start = new GDD_Point2F(e.X, e.Y);

                //Creating a new line
                if (lineToolStripMenuItem.Checked == true)
                {
                    Line_Preview = GDD_Line.Create(Line_Start, Line_Start);
                    Line_Preview.GravityType = GDD_GravityType.Static;

                    GDD_View1.Scene.Objects.Add(Line_Preview);
                    Lines.Add(Line_Preview);
                }
            }
        }

        /// <summary>
        /// Will execute whenever the mouse moves over GDD_View1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GDD_View1_MouseMove(object sender, MouseEventArgs e)
        {
            //Only proceding if the mousebutton is down
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Making the right frontcolor depending on the current end of the line
                Line_Preview.FrontColor = GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X, e.Y), GDD_ZoneType.NoDraw) ? Color.Red : Color.Black;

                GDD_View1.Scene.LineThroughObject(Line_Preview);

                //Redording the end of the line
                Line_End = new GDD_Point2F(e.X, e.Y);

                //Using the Start and End to add a new line to ther scene
                GDD_Object obj = GDD_Line.Create(Line_Start, Line_End);

                //Determining what to do with the start and end
                if (/*pencilToolStripMenuItem.Checked == */true)
                {
                    //Adding the line
                    GDD_View1.Scene.Objects.Add(obj);
                    Lines.Add(obj);

                    //Updating the start
                    Line_Start = Line_End;
                }

                //
                if (lineToolStripMenuItem.Checked == true)
                    //if (!nodraw.Contains(new Point(e.X, e.Y)))
                    //{
                    //Only proceding if the mousebutton is down
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //Modifying line_preview
                        Line_Preview.Rotation = obj.Rotation;
                        Line_Preview.Shape.Size = obj.Shape.Size;
                    }
            }
        }
                
                                
        private void GDD_View1_MouseUp(object sender, MouseEventArgs e)
        {
            //Only applies to a line
            if (lineToolStripMenuItem.Checked == true)
            {
                //Checking if the end is in the zone
                if (GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X,e.Y), GDD_ZoneType.NoDraw))
                {
                    //Removing line, preview
                    GDD_View1.Scene.Objects.Remove(Line_Preview);
                    Lines.Remove(Line_Preview);
                }
            }
        }



        private void button_GO_Click(object sender, EventArgs e)
        {
            //Letting the ball fall
            circle1.GravityType = GDD_GravityType.Normal;

            button_Reset.Visible = true;
            button_GO.Visible = true;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //The clientsize should be good
            this.ClientSize = new System.Drawing.Size(600, 600);

            //Placing the level
            Reset();

            //Starting the graphics
            GDD_View1.graphicsTimer.Start();
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            //Resetting
            Reset();
        }

        private void levelsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Will force the application to close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void BucketTest()
        {          
            circle1.Location = new GDD_Point2F(400f, 50f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 0f);
            circle1.Velocity = new GDD_Point2F(0f, 0f);

            GDD_Object grav = new GDD_Object(new GDD_GravityLift());
            grav.Location = new GDD_Point2F(400f, 400f);
            grav.Shape.Size = 110f;
            grav.Mass = 100f;
            grav.Rotation = new GDD_Vector2F(0f, 0f);
            grav.Velocity = new GDD_Point2F(0f, 0f);
            grav.GravityType = GDD_GravityType.Static;
            //grav.OnCollision += new EventHandler(grav_OnCollision);
            /*
            //Placing a few boxes
            for (int i = 0; i < 4; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());

                //square1.Location = new GDD_Point2F(200f + dxdy.x*i, 200f + dxdy.y *i);
                square1.Location = new GDD_Point2F(212f  + 125f * i, 125f );
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(0, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }

            //Placing a few boxes
            for (int i = 0; i < 3; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());

                //square1.Location = new GDD_Point2F(200f + dxdy.x*i, 200f + dxdy.y *i);
                square1.Location = new GDD_Point2F(275f + 125f * i, 250f);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(0, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }
            */
            //Adding a no-draw zone

            /*GDD_Zone zone = new GDD_Zone();
            GDD_Object obj = new GDD_Object(zone);
           
            zone.PolygonPoints = new GDD_Point2F[4];
            zone.PolygonPoints[0] = new GDD_Point2F(0, 275f);
            zone.PolygonPoints[1] = new GDD_Point2F(800, 275f);
            zone.PolygonPoints[2] = new GDD_Point2F(800, 455);
            zone.PolygonPoints[3] = new GDD_Point2F(0, 455);
            zone.ZoneType = GDD_ZoneType.NoDraw;
            zone.EdgeSize = 200f;
            obj.FrontColor = Color.LightGray;
            obj.Rotation = new GDD_Vector2F(0f, 0f);
            GDD_View1.Scene.Zones.Add(obj);

            */
            //Adding the circles
            GDD_View1.Scene.Objects.Add(circle1);
            GDD_View1.Scene.Objects.Add(grav);
        }

        Stopwatch bucketCollisionTimer = new Stopwatch();
        int bucketCollisionCounter = 0;
        void bucket1_OnCollision(object sender, EventArgs e)
        {
            if (bucketCollisionTimer.ElapsedMilliseconds >= 2000)
            {
                bucketCollisionCounter = 0;
                bucketCollisionTimer.Restart();
                             
            }

            //We're looking for 10 bounces in 2 seconds
            bucketCollisionCounter++;

            //Have we finished?
            if (bucketCollisionCounter >= 10)
            {
                bucketCollisionCounter = 0;
                MessageBox.Show("YOU WON!");
                this.Invoke(new ResetDelegate(this.Reset), new object[0]);
            }
        }

        private void LineTest()
        {
            circle1.Location = new GDD_Point2F(200f, 150f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 0f);
            circle1.Velocity = new GDD_Point2F(500f, 0f);

            float r = 250f;
            float f = 360 / ((2f * r * (float)Math.PI) / 50f);

            //Looping 32 boxes
            for (int i = 0; i < 32; i++)
            {
                GDD_Point2F p1 = new GDD_Vector2F(f * i, 250f).ToDXDY();
                GDD_Point2F p2 = new GDD_Vector2F(f * (i + 1), 250f).ToDXDY();
                
                GDD_Object line1 = new GDD_Object(new GDD_Line());
                line1.Location = new GDD_Point2F(300f + p1.x, 300f + p1.y);
                line1.Shape.Size = 50f;
                line1.Mass = 50f;
                line1.Rotation = new GDD_Point2F(p2.x - p1.x, p2.y - p1.y).ToVector();
                line1.Velocity = new GDD_Point2F(0f, 0f);
                line1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(line1);

            }
            GDD_View1.Scene.Objects.Add(circle1);
        }

        private void LineTest2()
        {
            circle1.Location = new GDD_Point2F(100f, 50f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 1f);
            circle1.Velocity = new GDD_Point2F(0f, 0f);
            
            float angle = 10;
            float LongSize = (float)(Math.Sqrt(2d) * 50f);
            GDD_Point2F dxdy = new GDD_Vector2F(90f + angle, 50f).ToDXDY();


            //Placing a few lines
            for (int i = 0; i < 8; i++)
            {
                GDD_Object line1 = new GDD_Object(new GDD_Line());

                line1.Location = new GDD_Point2F(50f + dxdy.x * i, 400f + dxdy.y * i);
                line1.Shape.Size = 50f;
                line1.Mass = 50f;
                line1.Rotation = new GDD_Vector2F(angle + 90f, 0f);
                line1.Velocity = new GDD_Point2F(0f, 0f);
                line1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(line1);

            }
            GDD_View1.Scene.Objects.Add(circle1);
        }

        private void BounceTest()
        {
            circle1.Location = new GDD_Point2F(300f, 300f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 5f);
            circle1.Velocity = new GDD_Point2F(-200f, -200f);

            float r = 250f;
            float f = 360 / ((2f * r * (float)Math.PI) / 50f);

            //Looping 32 boxes
            for (int i = 0; i < 32; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());
                GDD_Point2F dxdy = new GDD_Vector2F(270f - f * i, 250f).ToDXDY();

                square1.Location = new GDD_Point2F(300f + dxdy.x, 300f + dxdy.y);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(-f * i, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }

            //Adding the circles
            GDD_View1.Scene.Objects.Add(circle1);
        }

        private void AngularMomentumTest()
        {
            circle1.Location = new GDD_Point2F(50f, 50f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 2f);
            circle1.Velocity = new GDD_Point2F(0f, 0f);
           
            //Angle of the boxes;
            float angle = 10;
            float LongSize = (float)(Math.Sqrt(2d) * 50f);
            GDD_Point2F dxdy = new GDD_Vector2F(90f + angle, 50f).ToDXDY();

            //Placing a few boxes
            for (int i = 0; i < 4; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());
               
                square1.Location = new GDD_Point2F(50f + dxdy.x * i, 200f + dxdy.y * i);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(angle, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }

            dxdy = new GDD_Vector2F(90f - angle, 50f).ToDXDY();

            //Placing a few boxes
            for (int i = 0; i < 8; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());

                square1.Location = new GDD_Point2F(150f + dxdy.x * i, 450f + dxdy.y * i);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(-angle, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }


            //Adding the circles
            GDD_View1.Scene.Objects.Add(circle1);
        }

        private void pencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.pencilToolStripMenuItem.Checked = true;
            lineToolStripMenuItem.Checked = false;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineToolStripMenuItem.Checked = true;
            //pencilToolStripMenuItem.Checked = false;
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Lines.Clear();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add some tests here
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        
    }
}
