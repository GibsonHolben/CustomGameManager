using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace CustomGameManager
{
    public partial class Form1 : Form
    {
        /**Holds all the buttons for the tasks*/
        List<Button> PathButtons = new List<Button>();

        /**The x offset of the buttons*/
        int offset = 0;

        /**How many rows of buttons there are (used for buttons array)*/
        int rows = 1;

        /**Holds the last momement of the scrollbar*/
        int lastVMove = 0;

        /**The path to the .ini File*/
        string path;

        /**The home path of the user*/
        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                           Environment.OSVersion.Platform == PlatformID.MacOSX)
                         ? Environment.GetEnvironmentVariable("HOME")
                         : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        //Is the form in button deletion mode
        bool deleteMode = false;


        /**initilizes the form*/
        public Form1()
        {
            InitializeComponent();

        }

        /**Sets up the variables and load settings*/
        private void Form1_Load(object sender, EventArgs e){
            path = homePath + "/Documents/GameManager.ini";
            LoadButtons();
            try{
                comboBox1.SelectedIndex = Properties.Settings.Default.ButtonStyle;
                UpdateButtonStyle();
                foreach(Button b in PathButtons){
                    try{b.Click -= Global_Button_Click;}
                    catch{Console.WriteLine("no event to rem");}
                    b.Click += Global_Button_Click;
                }
            }
            catch{
                foreach (Button b in PathButtons)
                {
                    b.FlatStyle = FlatStyle.Standard;
                }
            }
          
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            iconSetup();
            ButtonSettingsLoad();
        }

        /**Loads the color and such settings for the buttons*/
        private void ButtonSettingsLoad(){
            try {
                this.BackColor = Properties.Settings.Default.bgColor;
                Taskbar.BackColor = Properties.Settings.Default.bgColor;
                settingsPanel.BackColor = Properties.Settings.Default.bgColor;
                ColorButton.BackColor = Properties.Settings.Default.bgColor;
                ButtonColor.BackColor = Properties.Settings.Default.buttonColor;
                //reset.BackColor = Properties.Settings.Default.buttonColor;
                Save.BackColor = Properties.Settings.Default.buttonColor;
                Settings.BackColor = Properties.Settings.Default.buttonColor;
                //richTextBox1.BackColor = Properties.Settings.Default.buttonColor;
                Add.BackColor = Properties.Settings.Default.buttonColor;
                minus.BackColor = Properties.Settings.Default.buttonColor;
                delete.BackColor = Properties.Settings.Default.buttonColor;

                foreach (Button b in PathButtons)
                {
                    b.BackColor = Properties.Settings.Default.buttonColor;
                }
            }
            catch
            {
                this.BackColor = Color.Black;
                Taskbar.BackColor = Color.Black;
                ColorButton.BackColor = Color.White;
            }

        }

        /**Extracts the icon from a file*/
        public static Icon ExtractIconFromFilePath(string executablePath){
            Icon result = (Icon)null;
            try{
                result = Icon.ExtractAssociatedIcon(executablePath);
            }
            catch (Exception){
                Console.WriteLine("Unable to extract the icon from the binary");
            }
            return result;
        }


        /**Resets the given button
        
        private void reset_Click(object sender, EventArgs e){
            if(richTextBox1.Text == ""){
                MessageBox.Show("Please Input The Game Slot You Would Like To Reset (index starts at 0)");
            }
            else if (richTextBox1.Text == "all"){
                int whl = PathButtons.Count;
                while (whl > 0){
                    whl -= 1;
                    if (PathButtons[whl].Image != null)
                        PathButtons[whl].Image = null;
                    if (PathButtons[whl].Text != "")
                        PathButtons[whl].Text = "";
                }
            }
            else{
                try{
                    clear(PathButtons[Int32.Parse(richTextBox1.Text)]);
                }
                catch{
                    MessageBox.Show("Please enter a number");
                }
                iconSetup();
            }
        }*/

        /**Loads the buttons from the settings file*/
        private void LoadButtons(){
            string settingsString = "";
            using (StreamReader sr = File.OpenText(path)){
                string s = "";
                while ((s = sr.ReadLine()) != null){
                    settingsString += s;
                }
            }
            string[] settings = settingsString.Split('|');
            string[] buttonsSettings = settings[1].Split(',');
            for(int i = 0; i < Int32.Parse(settings[0]); i++)
            {
                createButton();
                PathButtons[i].Text = buttonsSettings[i];
            }
        }

        /**Opens the file manager if no path has been saved, else attempts to run the application*/
        private void ButtonClickEvent(Button game, EventArgs e){

            if (!deleteMode)
            {
                if (game.Text == "")
                {
                    OpenFileDialog fd = new OpenFileDialog();
                    fd.ShowDialog();
                    game.Text = fd.FileName;
                    if (game.Text != "")
                    {
                        Icon theIcon2 = ExtractIconFromFilePath(game.Text);
                        game.Image = theIcon2.ToBitmap();
                    }
                }
                else
                {
                    try
                    {
                        Process.Start(game.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Path was not found/File could not be run");
                    }
                }
            }
            else
            {
                clear(game);
            }

           
        }

        /**Clears a buttons information*/
        private void clear(Button b){
            b.Text = ""; 
            b.Image = null;
        }

        /**Runs when any button from the array has been clicked*/
        private void Global_Button_Click(object sender, EventArgs e){
            ButtonClickEvent((Button)sender, e);
        }


        /**Calls SaveFile*/
        private void Save_Click(object sender, EventArgs e){
            SaveFile();
        }

        /**Sets the icon for all the buttons*/
        void iconSetup(){
            foreach (Button b in PathButtons)
            {

                if (b.Text != "")
                {
                    try
                    {
                        Icon theIcon1 = ExtractIconFromFilePath(b.Text);
                        b.Image = theIcon1.ToBitmap();
                    }
                    catch
                    {
                        MessageBox.Show("Could not find bitmap image for: " + b.Text);
                    }
                }
            }
        }

        /**Shows the setting menu*/
        private void Settings_Click(object sender, EventArgs e) {
            if(deleteMode){
                toggleDelete();
            }
            settingsPanel.Show();
        }
        /**updates the settings and closed the setting menu*/
        private void update_Click(object sender, EventArgs e){
            ButtonSettingsLoad();
            settingsPanel.Hide();
            SaveFile();
        }
        /**Opens the color chooser for the background*/
        private void ColorButton_Click(object sender, EventArgs e){
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            ColorButton.BackColor = bgColor.Color;
            Properties.Settings.Default.bgColor= bgColor.Color;
            this.BackColor = bgColor.Color;
        }
        /**Opens the color chooser for the buttons*/
        private void ButtonColor_Click(object sender, EventArgs e){
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            ButtonColor.BackColor = bgColor.Color;
            Properties.Settings.Default.buttonColor = bgColor.Color;
            foreach(Button b in PathButtons){
                b.BackColor = bgColor.Color;
            }
          
        }
        /**Saves the settings to a file*/
        void SaveFile(){
            Properties.Settings.Default.bgColor = this.BackColor;
            Properties.Settings.Default.Save();
            String settingBuild = PathButtons.Count + "|";

            foreach (Button b in PathButtons){
                settingBuild += b.Text + ",";
            }

            try{
                if (File.Exists(path)){
                    //writes to file
                    System.IO.File.WriteAllText(path, settingBuild);
                }
                else{
                    // Create the file.
                    using (FileStream fs = File.Create(path)){
                        System.IO.File.WriteAllText(path, settingBuild);
                        fs.Close();
                    }

                }
            }
            catch (Exception ex){
                MessageBox.Show("An eror has happened. If this issue persists please open an issue on the github");
                Console.WriteLine(ex.ToString());
            }

        }
        /**calls the update for the style of the buttons*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
            UpdateButtonStyle();
        }

        /**Updates the style of the button*/
        void UpdateButtonStyle(){
            if (comboBox1.SelectedIndex == 0){

                foreach (Button b in PathButtons)
                { 
                    b.FlatStyle = FlatStyle.Standard;
                }
            }
            if (comboBox1.SelectedIndex == 1){
                foreach (Button b in PathButtons){
                    b.FlatStyle = FlatStyle.Flat;
                }

            }
            Properties.Settings.Default.ButtonStyle = comboBox1.SelectedIndex; 
        }
        /**Controlls the scrolling of the buttons (A bit buggy and needs work)*/
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e){

            int moveY = 0;
            if (lastVMove > vScrollBar1.Value)
                moveY = 1;
            else if (lastVMove == vScrollBar1.Value)
                moveY = 0;
            else
                moveY = -1;

            foreach (Button b in PathButtons){
                for(int i =0; i < FindDifference(lastVMove, vScrollBar1.Value); i++){
                    b.Location = new Point(b.Location.X, b.Location.Y + (moveY * 10));
                }
            }
            lastVMove = vScrollBar1.Value;

        }
        /**Finds the differance between 2 numbers */
        public decimal FindDifference(decimal nr1, decimal nr2){
            return Math.Abs(nr1 - nr2);
        }
        
        /**Adds a button*/
        private void Add_Click(object sender, EventArgs e){
            createButton();
        }
        /**Creates a button (used for init and click)*/
        private void createButton(){
            if (offset >= 6){
                offset = 0;
                rows += 1;
            }
            vScrollBar1.Maximum = rows * 20;
            Button newButton = new Button();
            this.Controls.Add(newButton);
            Double d = (PathButtons.Count / 6);
            newButton.TextAlign = ContentAlignment.BottomCenter;
            newButton.Location = new Point((30 + (offset * 150)), 30 + (150 * (PathButtons.Count / 6)));
            newButton.Size = new Size(130, 130);
            newButton.Click += Global_Button_Click;
            try
            {
                newButton.BackColor = Properties.Settings.Default.buttonColor;
            }
            catch
            {
                newButton.BackColor = Color.White;
            }
            PathButtons.Add(newButton);
            offset++;
        }

        private void minus_Click(object sender, EventArgs e){ 
            Controls.Remove(PathButtons[PathButtons.Count - 1]);
            PathButtons.Remove(PathButtons[PathButtons.Count - 1]);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            toggleDelete();
        }

        void toggleDelete()
        {
            if (deleteMode == true)
            {
                deleteMode = false;
                delete.Text = "Enable delete mode";
                foreach (Button b in PathButtons)
                {
                    b.BackColor = Properties.Settings.Default.buttonColor;
                }
            }
            else
            {
                deleteMode = true;
                delete.Text = "Disable delete mode";
                foreach (Button b in PathButtons)
                {
                    b.BackColor = Color.Red;
                }

            }
        }
    }
}
