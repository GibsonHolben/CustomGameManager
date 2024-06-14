using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace CustomGameManager
{
    public partial class Form1 : Form
    {
        Button[] games;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedIndex = Properties.Settings.Default.ButtonStyle;

                UpdateButtonStyle();
            }
            catch
            {
                games = new Button[] { Game1, Game2, Game3, Game4, Game5, Game6, Game7, Game8, Game9, Game10 };

                int whl = games.Length;
                while (whl > 0)
                {
                    whl -= 1;
                    games[whl].FlatStyle = FlatStyle.Standard;
                }
            }
          
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            nameSetup();
            iconSetup();
            try
            {
                this.BackColor = Properties.Settings.Default.bgColor;
                ColorButton.BackColor = Properties.Settings.Default.bgColor;
            }
            catch
            {
                this.BackColor = Color.Black;
                ColorButton.BackColor = Color.White;
            }
            try
            {
                ButtonColor.BackColor = Properties.Settings.Default.buttonColor;
                int whl = games.Length;
                while (whl > 0)
                {
                    whl -= 1;
                    games[whl].BackColor = Properties.Settings.Default.buttonColor;
                }
                reset.BackColor = Properties.Settings.Default.buttonColor;
                Save.BackColor = Properties.Settings.Default.buttonColor; 
                Settings.BackColor = Properties.Settings.Default.buttonColor; 
                richTextBox1.BackColor = Properties.Settings.Default.buttonColor;
            }
            catch
            {
                MessageBox.Show("Unable to find button color");
            }
           

        }

        public static Icon ExtractIconFromFilePath(string executablePath)
        {
            Icon result = (Icon)null;

            try
            {
                result = Icon.ExtractAssociatedIcon(executablePath);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to extract the icon from the binary");
            }

            return result;
        }

        private void reset_Click(object sender, EventArgs e){
            if(richTextBox1.Text == ""){
                MessageBox.Show("Please Input The Game Slot You Would Like To Reset");
            }
            else if (richTextBox1.Text == "all"){
                int whl = games.Length;
                while (whl > 0){
                    whl -= 1;
                    if (games[whl].Image != null)
                        games[whl].Image = null;
                    if (games[whl].Text != "")
                        games[whl].Text = "";
                }
            }
            else
            {

                try{
                    clear(games[Int32.Parse(richTextBox1.Text)]);
                }
                catch{
                    MessageBox.Show("Please enter a number");
                }
                iconSetup();
            }
        }

        private void setupButton(Button game)
        {
            if (game.Text == "")
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.ShowDialog();
                game.Text = fd.FileName;
            }
            else
            {
                try
                {
                    Process.Start(game.Text);
                }
                catch
                {
                    MessageBox.Show("Path was not found");

                }
            }

            if (game.Text != "")
            {
                Icon theIcon2 = ExtractIconFromFilePath(game.Text);
                game.Image = theIcon2.ToBitmap();
            }
        }
        private void clear(Button b)
        {
            b.Text = ""; 
            b.Image = null;
        }
        private void Game1_Click(object sender, EventArgs e)
        {
            setupButton(Game1);
        }

        private void Game2_Click(object sender, EventArgs e)
        {
            setupButton(Game2);
        }

        private void Game3_Click(object sender, EventArgs e)
        {
            setupButton(Game3);
        }

        private void Game4_Click(object sender, EventArgs e)
        {
            setupButton(Game4);

        }

        private void Game5_Click(object sender, EventArgs e)
        {
            setupButton(Game5);

        }

        private void Game6_Click(object sender, EventArgs e)
        {
            setupButton(Game6);

        }

        private void Game7_Click(object sender, EventArgs e)
        {
            setupButton(Game7);

        }

        private void Game8_Click(object sender, EventArgs e)
        {
            setupButton(Game8);

        }

        private void Game9_Click(object sender, EventArgs e)
        {
            setupButton(Game9);

        }

        private void Game10_Click(object sender, EventArgs e)
        {
            setupButton(Game10);

        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }


        void iconSetup()
        {
            try
            {
                int whl = games.Length;
                while (whl > 0)
                {
                    whl -= 1;
                    if (games[whl].Text != "")
                    {
                        try
                        {
                            Icon theIcon1 = ExtractIconFromFilePath(games[whl].Text);
                            games[whl].Image = theIcon1.ToBitmap();
                        }
                        catch
                        {
                           MessageBox.Show("Could not find bitmap image for: " + games[whl].Text);
                        }

                    }
                }
            }
            catch
            {

            }
        }
        

        void nameSetup()
        {
            games = new Button[] {Game1, Game2, Game3, Game4, Game5, Game6, Game7, Game8, Game9, Game10 };
           

            Game1.Text = Properties.Settings.Default.one;
            Game2.Text = Properties.Settings.Default.two;
            Game3.Text = Properties.Settings.Default.three;
            Game4.Text = Properties.Settings.Default.four;
            Game5.Text = Properties.Settings.Default.five;
            Game6.Text = Properties.Settings.Default.six;
            Game7.Text = Properties.Settings.Default.seven;
            Game8.Text = Properties.Settings.Default.eight;
            Game9.Text = Properties.Settings.Default.nine;
            Game10.Text = Properties.Settings.Default.ten;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            settingsPanel.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            reset.BackColor = Properties.Settings.Default.buttonColor;
            Save.BackColor = Properties.Settings.Default.buttonColor;
            Settings.BackColor = Properties.Settings.Default.buttonColor;
            richTextBox1.BackColor = Properties.Settings.Default.buttonColor;
            ButtonColor.BackColor = Properties.Settings.Default.buttonColor;
            settingsPanel.Hide();
            SaveFile();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            ColorButton.BackColor = bgColor.Color;
            this.BackColor = bgColor.Color;
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            Properties.Settings.Default.buttonColor = bgColor.Color;
            int whl = games.Length;
            while (whl > 0)
            {
                whl -= 1;
                games[whl].BackColor = bgColor.Color;
            }
          
        }

        void SaveFile()
        {
            Properties.Settings.Default.bgColor = this.BackColor;


            Properties.Settings.Default.one = Game1.Text;
            Properties.Settings.Default.two = Game2.Text;
            Properties.Settings.Default.three = Game3.Text;
            Properties.Settings.Default.four = Game4.Text;
            Properties.Settings.Default.five = Game5.Text;
            Properties.Settings.Default.six = Game6.Text;
            Properties.Settings.Default.seven = Game7.Text;
            Properties.Settings.Default.eight = Game8.Text;
            Properties.Settings.Default.nine = Game9.Text;
            Properties.Settings.Default.ten = Game10.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonStyle();
        }

        void UpdateButtonStyle()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                games = new Button[] { Game1, Game2, Game3, Game4, Game5, Game6, Game7, Game8, Game9, Game10 };

                int whl = games.Length;
                while (whl > 0)
                {
                    whl -= 1;
                    games[whl].FlatStyle = FlatStyle.Standard;
                }

            }
            if (comboBox1.SelectedIndex == 1)
            {
                games = new Button[] { Game1, Game2, Game3, Game4, Game5, Game6, Game7, Game8, Game9, Game10 };

                int whl = games.Length;
                while (whl > 0)
                {
                    whl -= 1;
                    games[whl].FlatStyle = FlatStyle.Flat;
                }

            }

            Properties.Settings.Default.ButtonStyle = comboBox1.SelectedIndex;
            
        }
    }
}
