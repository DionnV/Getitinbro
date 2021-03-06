﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDD_Library;
using GDD_Library.Shapes;
using GDD_Library.Controls;
using GDD_Library.LevelDesign;
using System.IO;

namespace GDD_Game_Windows
{
    /// <summary>
    /// This class holds the whole menu.
    /// </summary>
    public partial class FormMain : Form
    {
        
        private Panel CurrentPanel;
        private Panel PreviousPanel;
        private bool SoundOn = false;
        private GDD_Level level;
        private string currentChapter = null;

        private LevelDesigner playzone;

        /// <summary>
        /// Contructor will initialize all components.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            this.PanelCustomLevels.SendToBack();
            this.PanelChapterSelect.SendToBack();
            this.PanelLevelSelect.SendToBack();
            this.PanelMain.SendToBack();
            this.PanelPlayNow.SendToBack();
            this.PanelSettings.SendToBack();
        }

        /// <summary>
        /// This will load the FormMain and start the graphics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //Setting the proper size
            this.ClientSize = new Size(800, 480);

            //Loading the background scene
            LoadBGScene();
            LoadMainMenu();
        }

        private void FormMain_Shown(object sender, System.EventArgs e)
        {
            this.GDD_View1.graphicsTimer.Start();
            if (CurrentPanel == PanelLevelSelect)
            {
                LoadLevelSelect(null);
            }          
        }                      


        /// <summary>
        /// This will load the main menu screen.
        /// </summary>
        private void LoadMainMenu()
        {
            if (CurrentPanel != null)
            {
                CurrentPanel.SendToBack();
                PreviousPanel = CurrentPanel;
            }
            else
            {
                PreviousPanel = PanelMain;
            }
            this.PanelMain.BringToFront();
            CurrentPanel = PanelMain;
            Button_Back_Main.Text = "Main menu";
            Button_PlayNow.Text = "Play now";
            Button_Settings.Text = "Settings";
            Button_Store.Text = "Store";
            Button_LevelDesign.Text = "Level Designer";
            Button_Designer_Back.Text = "Level Designer";
        }

        /// <summary>
        /// This will load the play menu screen.
        /// </summary>
        private void LoadPlayMenu()
        {
            CurrentPanel.SendToBack();
            this.PanelPlayNow.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelPlayNow;
            Button_Back_PlayNow.Text = "Choose a mode.";
            Button_Competitive.Text = "Competitive";
            Button_Custom.Text = "Custom";
        }

        /// <summary>
        /// This will load the level designer.
        /// </summary>
        private void OpenDesigner(bool _isDesigner)
        {
            //Hide this form.
            this.Hide();
            
            //Create a new one if the current one is null
            if (this.playzone == null )
            {
                this.playzone = new LevelDesigner();
            }

            //Add the FormClosed Event
            this.playzone.FormClosed += playzone_FormClosed;           

            //We have designer rights.
            this.playzone.isDesigner = _isDesigner;

            //Set location and show the form.
            this.playzone.Location = this.Location;
            this.playzone.Invoke(new Action(delegate() 
                {
                    this.playzone.Show();
                }));

            //Stopping the graphics timer
            this.GDD_View1.graphicsTimer.Stop();
        }

        /// <summary>
        /// This will load the settings menu.
        /// </summary>
        private void LoadSettings()
        {
            CurrentPanel.SendToBack();
            this.PanelSettings.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelSettings;
            Button_Back_Settings.Text = "Settings";
            Button_Sound.Text = "Sound: off";
        }

        /// <summary>
        /// This will load the chapter select menu.
        /// </summary>
        private void LoadChapterSelect()
        {
            //We will make 1 column
            int col = 1;

            //Tile location
            int x = 50;
            int y = 50;

            //Add tiles to the panel
            System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo("./Levels/");
            DirectoryInfo[] dirs = dirinfo.GetDirectories();
            for (int i = 0; i < dirs.Length - 1; i++)
            {
                //Add a new row after every tile
                if ((i % col) == 0)
                {
                    y += 50;
                }

                string name = dirs[i].Name;
                string chapterno = name.Substring(7);

                //Add the button
                GDD_Button b = new GDD_Button();
                b.Note = "";
                b.Text = "Chapter" + chapterno;
                b.Location = new Point(x, y);
                b.BackColor = System.Drawing.Color.White;
                b.BorderWidth = 2F;
                b.Name = chapterno;
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = System.Drawing.Color.Black;
                b.Padding = new System.Windows.Forms.Padding(3);
                b.Size = new System.Drawing.Size(350, 50);
                b.TabIndex = 4;
                b.Click += new EventHandler(Button_Chapter_Click);
                PanelChapterSelect.Controls.Add(b);
            }
            CurrentPanel.SendToBack();
            this.PanelChapterSelect.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelChapterSelect;
            Button_Back_ChapterSelect.Text = "Choose a chapter.";
        }

        /// <summary>
        /// This will load the level select menu.
        /// </summary>
        private void LoadLevelSelect(string chapterno)
        {
            if (chapterno != null)
            {
                currentChapter = chapterno;
            }
            else if (currentChapter == null)
            {
                return;
            }
            
            //First clear the PanelLevelSelect
            PanelLevelSelect.Controls.Clear();

            //And add the back button
            PanelLevelSelect.Controls.Add(Button_Back_LevelSelect);
            //We will make 3 columns
            int col = 3;

            //Tile size
            int x = 50;
            int y = 20;

            //Add tiles to the panel
            System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo("./Levels/Chapter" + currentChapter + "/");
            DirectoryInfo[] dirs = dirinfo.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                //Add a new row after 3 tiles
                if ((i % col) == 0)
                {
                    y += 85;
                    x = 50;
                }

                string name = dirs[i].Name;
                string levelno = name.Substring(6);

                //Add the button
                GDD_Button b = new GDD_Button();
                b.Note = "";
                b.Text = levelno;
                b.Location = new Point(x, y);
                b.BackColor = System.Drawing.Color.White;
                b.BorderWidth = 2F;
                b.Name = "/Chapter1/ch1lev" + levelno;
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = System.Drawing.Color.Black;
                b.Padding = new System.Windows.Forms.Padding(3);
                b.Size = new System.Drawing.Size(100, 75);
                b.TabIndex = 4;
                b.Click += new EventHandler(Button_LoadLevel);
                b.Medals = GetMedalAmount("./Levels" + b.Name);                
                PanelLevelSelect.Controls.Add(b);

                if (b.Medals == 0)
                {
                    break;
                }

                //Increase x for the next button
                x += 113;
            }

            CurrentPanel.SendToBack();
            this.PanelLevelSelect.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelLevelSelect;
            Button_Back_LevelSelect.Text = "Choose a level.";
        }

        /// <summary>
        /// This will load the custom level menu.
        /// </summary>
        private void LoadCustomLevels()
        {
            CurrentPanel.SendToBack();
            this.PanelCustomLevels.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelCustomLevels;
            Button_Back_CustomLevels.Text = "Choose a custom level.";
        }

       
        /// <summary>
        /// This will load the store menu.
        /// </summary>
        private void LoadStore()
        {
            //Not implemented yet
        }

        /// <summary>
        /// This will load the background.
        /// </summary>
        private void LoadBGScene()
        {
            //Load the default background.
            LoadDefaultBG();
        }

        
        /// <summary>
        /// This will handle the clicking on the PlayNow button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PlayNow_Click(object sender, System.EventArgs e)
        {
            //Load the play menu.
            LoadPlayMenu();
        }

        /// <summary>
        /// This will handle the clicking on the LevelDesign button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_LevelDesign_Click(object sender, System.EventArgs e)
        {
            //Load the level designer.
            CurrentPanel.SendToBack();
            this.panelDesigner.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = panelDesigner;
            Button_Designer_New.Text = "New game";
            Button_Designer_Load.Text = "Load game";

            Button_Designer_Load.Visible = true;
            Button_Designer_Load.Enabled = false;
            Button_Designer_Load.Note = "Soon";
            Button_Designer_Load.Refresh();
            
        }

        private void Button_Designer_New_Click(object sender, System.EventArgs e)
        {
            //Load the level designer.
            OpenDesigner(true);
        }

        private void Button_EditCustomLevel_Click(object sender, System.EventArgs e)
        {
            panelEditCustomLevels_Levels.Controls.Clear();

            //We will make 3 columns
            int col = 3;

            //Tile size
            int x = 50;
            int y = 0;

            //Add tiles to the panel
            System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo("./Levels/Custom/");

            //Getting all the files in the directory
            DirectoryInfo[] dirs = dirinfo.GetDirectories();

            for (int i = 0; i < dirs.Length; i++)
            {
                //Add a new row after 3 tiles
                if ((i % col) == 0)
                {
                    y += 85;
                    x = 50;
                }

                string name = dirs[i].Name;

                //Add the button
                GDD_Button b = new GDD_Button();
                b.Note = "";
                b.Text = name;
                b.Location = new Point(x, y);
                b.BackColor = System.Drawing.Color.White;
                b.BorderWidth = 2F;
                b.Name = "./Custom/" + name;
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = System.Drawing.Color.Black;
                b.Padding = new System.Windows.Forms.Padding(3);
                b.Size = new System.Drawing.Size(100, 75);
                b.TabIndex = 4;
                b.Click += new EventHandler(Button_EditCustomLevel);
                panelEditCustomLevels_Levels.Controls.Add(b);

                //Increase x for the next button
                x += 113;
            }

            //Load the level designer.
            CurrentPanel.SendToBack();
            this.panelEditCustomLevel.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelCustomLevels;
            Button_EditCustomLevels_Back.Text = "Edit a custom level";

        }

        /// <summary>
        /// This will handle the clicking on the Settings button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Settings_Click(object sender, System.EventArgs e)
        {
            //Load the settings menu.
            LoadSettings();
        }

        /// <summary>
        /// This will handle the clicking on the Sound button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sound_Click(object sender, System.EventArgs e)
        {
            //Sound is not implemented yet            
            Button_Sound.Text = SoundOn ? "Sound: off" : "Sound: on";                            
            SoundOn = !SoundOn;
            Button_Sound.Refresh();
        }

        /// <summary>
        /// This will handle the clicking on the Chapter1 button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Chapter_Click(object sender, System.EventArgs e)
        {
            GDD_Button button = (GDD_Button)sender;          
            //Load the levelselect.
            LoadLevelSelect(button.Name);
        }

        /// <summary>
        /// This will load the selected level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_LoadLevel(object sender, EventArgs e)
        {
            //Who pressed me?
            GDD_Button button = (GDD_Button)sender;

            LoadLevel(@".\Levels\Chapter" + currentChapter + @"\ch" + currentChapter + "lev" + button.Text, false);
        }


        /// <summary>
        /// This will load the selected level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PlayCustomLevel(object sender, EventArgs e)
        {
            //Who pressed me?
            GDD_Button button = (GDD_Button)sender;

            LoadLevel(@".\Levels\Custom\" + button.Text, false);
        }

        /// <summary>
        /// This will load the selected level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_EditCustomLevel(object sender, EventArgs e)
        {
            //Who pressed me?
            GDD_Button button = (GDD_Button)sender;

            LoadLevel(@".\Levels\Custom\" + button.Text, true); 
        }

        public void LoadLevel(string name, bool Designer)
        {
            //Run a check if the level is custom or from a chapter
            if (System.IO.Directory.Exists(name))
            {
                level = GDD_Level.LoadFromFolder(name);
            }
            else
            {
                return;
            }

            //Put the levels in a new list, because serializing gives errors with the Owners.
            List<GDD_Object> newlist = new List<GDD_Object>();

            //Adding all the objects
            foreach (GDD_Object obj in level.Objects)
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

            //This works fine though.
            level.Objects = newlist;

            //Loading level designer
            OpenDesigner(Designer);

            //Load the level
            this.playzone.LoadLevel(level);

            //Show the playzone
            this.playzone.Show();
            this.Hide();
        }

        /// <summary>
        /// This will handle the clicking on the custom button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PlayCustom_Click(object sender, System.EventArgs e)
        {
            PanelCustomLevels_Levels.Controls.Clear();

            //We will make 3 columns
            int col = 3;

            //Tile size
            int x = 50;
            int y = 20;

            //Add tiles to the panel
            System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo("./Levels/Custom/");

            //Getting all the files in the directory
            DirectoryInfo[] dirs = dirinfo.GetDirectories();

            for (int i = 0; i < dirs.Length; i++)
            {
                //Add a new row after 3 tiles
                if ((i % col) == 0)
                {
                    y += 85;
                    x = 0;
                }

                string name = dirs[i].Name;

                //Add the button
                GDD_Button b = new GDD_Button();
                b.Note = "";
                b.Text = name;
                b.Location = new Point(x, y);
                b.BackColor = System.Drawing.Color.White;
                b.BorderWidth = 2F;
                b.Name = "./Custom/" + name;
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = System.Drawing.Color.Black;
                b.Padding = new System.Windows.Forms.Padding(3);
                b.Size = new System.Drawing.Size(100, 75);
                b.TabIndex = 4;
                b.Click += new EventHandler(Button_PlayCustomLevel);
                PanelCustomLevels_Levels.Controls.Add(b);

                //Increase x for the next button
                x += 113;
            }
            //Load the custom levels menu.
            LoadCustomLevels();
        }

        /// <summary>
        /// This will handle the clicking on the competitive button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Competitive_Click(object sender, System.EventArgs e)
        {
            //Load the chapter select.
            LoadChapterSelect();
        }

        /// <summary>
        /// This will handle the closing of the playzone form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playzone_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            //Disposes and set to true
            this.playzone.Dispose();
            this.playzone = null;          

            //Showing ourself
            this.Show();
            FormMain_Shown(new object(), new EventArgs());                  
        }       

        /// <summary>
        /// This will load the default background.
        /// </summary>
        private void LoadDefaultBG()
        {
            //For our convienence
            GDD_Scene Scene = this.GDD_View1.Scene;

            //Add a circle
            GDD_Object obj = new GDD_Object(new GDD_Circle());
            obj.Shape.Size = 50f;
            obj.Location = new GDD_Point2F(600f, 200f);
            obj.Rotation = new GDD_Vector2F(10f, 0);
            obj.GravityType = GDD_GravityType.Normal;
            obj.Velocity_Vector = new GDD_Vector2F(80f, 200f);
            obj.FrontColor = Color.Black;
            ((GDD_Circle)obj.Shape).RestitutionRate = 0.98f;
            Scene.Objects.Add(obj);

            //Add 3 lines.
            obj = new GDD_Object(new GDD_Line());
            obj.Shape.Size = 460f;
            obj.Location = new GDD_Point2F(780f, 470f);
            obj.Rotation = new GDD_Vector2F(0f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
            Scene.Objects.Add(obj);

            obj = new GDD_Object(new GDD_Line());
            obj.Shape.Size = 370f;
            obj.Location = new GDD_Point2F(410f, 470);
            obj.Rotation = new GDD_Vector2F(90f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
            Scene.Objects.Add(obj);

            obj = new GDD_Object(new GDD_Line());
            obj.Shape.Size = 460f;
            obj.Location = new GDD_Point2F(410f, 10f);
            obj.Rotation = new GDD_Vector2F(180f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
            Scene.Objects.Add(obj);

            //Add a bucket.
            obj = new GDD_Object(new GDD_Bucket());
            obj.Shape.Size = 100f;
            obj.Location = new GDD_Point2F(600f, 430f);
            obj.Rotation = new GDD_Vector2F(180f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;

            GDD_Button exit = new GDD_Button();
            exit.Click += new EventHandler(exit_Click);
            exit.Note = "";
            exit.Text = "X";
            exit.Location = new Point(10, 10);
            exit.BackColor = System.Drawing.Color.White;
            exit.BorderWidth = 2F;
            exit.Name = "Exit_Button";
            exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exit.ForeColor = System.Drawing.Color.Black;
            exit.Padding = new System.Windows.Forms.Padding(3);
            exit.Size = new System.Drawing.Size(30, 30);
            exit.TabIndex = 4;
            PanelMain.Controls.Add(exit);

            //Or not
            //Scene.Objects.Add(obj);           
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            //Updating all buttons to the right location
            
        }

        private void Button_Back_PlayNow_Click(object sender, System.EventArgs e)
        {
            LoadMainMenu();
        }

        private void Button_Back_Settings_Click(object sender, System.EventArgs e)
        {
            LoadMainMenu();
        }

        private void Button_Back_ChapterSelect_Click(object sender, System.EventArgs e)
        {
            LoadPlayMenu();
        }

        private void Button_Back_Custom_Click(object sender, System.EventArgs e)
        {
            LoadPlayMenu();
        }

        private void Button_Back_LevelSelect_Click(object sender, System.EventArgs e)
        {
            LoadChapterSelect();
        }

        private int GetMedalAmount(string levelfolder)
        {
            return GDD_Level.LoadFromFolder(levelfolder).info.MedalsAchieved;
        }

        private void Button_Designer_Back_Click(object sender, EventArgs e)
        {
            LoadMainMenu();
        }

        private void Button_Designer_Load_Click(object sender, EventArgs e)
        {

        }

    }
}
