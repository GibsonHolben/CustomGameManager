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
        List<String> PathButtonstrueText = new List<String>();


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

        Color background = Color.Black;
        Color button = Color.White;
        int  Style = 0;


        /**initilizes the form*/
        public Form1()
        {
            InitializeComponent();

        }

        /**Sets up the variables and load settings*/
        private void Form1_Load(object sender, EventArgs e){
            path = homePath + "/Documents/GameManager.ini";

            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
               
            LoadButtons();
            try{
                
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
        }

        /**Loads the color and such settings for the buttons*/
        private void ButtonSettingsLoad(Color background, Color button){
            try {
                this.BackColor = background;
                Taskbar.BackColor = background;
                settingsPanel.BackColor = background;
                ColorButton.BackColor = background;
                ButtonColor.BackColor = button;
                //reset.BackColor = Properties.Settings.Default.buttonColor;
                Save.BackColor = button;
                Settings.BackColor = button;
                //richTextBox1.BackColor = Properties.Settings.Default.buttonColor;
                Add.BackColor = button;
                minus.BackColor = button;
                delete.BackColor = button;

                foreach (Button b in PathButtons)
                {
                    b.BackColor = button;
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
            try
            {
                string settingsString = "";
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        settingsString += s;
                    }
                }
                string[] settings = settingsString.Split('|');
                string[] buttonsSettings = settings[1].Split(',');
                for (int i = 0; i < Int32.Parse(settings[0]); i++)
                {
                    createButton();
                    PathButtons[i].Text = buttonsSettings[i];
                }
                String[] colorSettingsPre = settings[2].Split(',');
                Color[] colorSettings = new Color[colorSettingsPre.Length];

                for (int i = 0; i < colorSettingsPre.Length; i++)
                {
                    colorSettings[i] = ColorTranslator.FromHtml(colorSettingsPre[i]);
                }

                comboBox1.SelectedIndex = Int32.Parse(settings[3]);
                UpdateButtonStyle();
                background = colorSettings[0];
                button = colorSettings[1];
                ButtonSettingsLoad(colorSettings[0], colorSettings[1]);
            }catch
            {
              
              
                for (int i = 0; i < 12; i++)
                {
                    createButton();
                }


                comboBox1.SelectedIndex = Style;
                UpdateButtonStyle();
                ButtonSettingsLoad(background, button);
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

        private void ButtonMouseOverEvent(Button game, EventArgs e)
        {
            int colorFade = -30;
            game.Location = new Point(game.Location.X, game.Location.Y - 5);
            game.BackColor = Color.FromArgb(
                Math.Min(game.BackColor.R + colorFade, 255), 
                Math.Min(game.BackColor.G + colorFade, 255),
                Math.Min(game.BackColor.B + colorFade, 255)
            );
        }
        private void ButtonMouseExitEvent(Button game, EventArgs e)
        {
            int colorFade = -30;
            game.Location = new Point(game.Location.X, game.Location.Y + 5);
            game.BackColor = Color.FromArgb(
                Math.Min(game.BackColor.R - colorFade, 255),
                Math.Min(game.BackColor.G - colorFade, 255),
                Math.Min(game.BackColor.B - colorFade, 255)
            );
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

        private void Global_Mouse_Over(object sender, EventArgs e)
        {
            ButtonMouseOverEvent((Button)sender, e);
        }
        private void Global_Mouse_Exit(object sender, EventArgs e)
        {
            ButtonMouseExitEvent((Button)sender, e);
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
            settingsPanel.Hide();
            SaveFile();
            ButtonSettingsLoad(background, button);
        }
        /**Opens the color chooser for the background*/
        private void ColorButton_Click(object sender, EventArgs e){
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            ColorButton.BackColor = bgColor.Color;
            background = bgColor.Color;
            this.BackColor = bgColor.Color;
        }
        /**Opens the color chooser for the buttons*/
        private void ButtonColor_Click(object sender, EventArgs e){
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            ButtonColor.BackColor = bgColor.Color;
            button = bgColor.Color;
            foreach(Button b in PathButtons){
                b.BackColor = bgColor.Color;
            }
          
        }
        /**Saves the settings to a file*/
        void SaveFile(){
            background = this.BackColor;
            String settingBuild = PathButtons.Count + "|";

            foreach (Button b in PathButtons){
                settingBuild += b.Text + ",";
            }
            string hexColorback = $"#{background.R:X2}{background.G:X2}{background.B:X2}";
            string hexColorbutton = $"#{button.R:X2}{button.G:X2}{button.B:X2}";
            settingBuild += "|" + hexColorback + "," + hexColorbutton + "|" + Style; 


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
                MessageBox.Show("An eror has happened. If this issue persists please open an issue on the github \n" + ex.ToString());
                Console.WriteLine(ex.ToString());
            }

        }
        /**calls the update for the style of the buttons*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
            UpdateButtonStyle();
        }

        /**Updates the style of the button*/
        void UpdateButtonStyle(){
            Style = comboBox1.SelectedIndex;

            if (comboBox1.SelectedIndex == 0){
                foreach (Button b in PathButtons)
                { 
                    b.FlatStyle = FlatStyle.Standard;
                }
            }
            else if (comboBox1.SelectedIndex == 1){
                foreach (Button b in PathButtons){
                    b.FlatStyle = FlatStyle.Flat;
                }

            }   
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
            newButton.MouseEnter += Global_Mouse_Over;
            newButton.MouseLeave += Global_Mouse_Exit;
            try
            {
                newButton.BackColor = button;
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
                    b.BackColor = button;
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
