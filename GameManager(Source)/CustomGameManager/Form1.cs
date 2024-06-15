using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace CustomGameManager
{
    public partial class Form1 : Form
    {
        List<Button> games = new List<Button>();
        int offset = 0;
        int rows = 1;


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
                foreach(Button b in games)
                {
                    b.Click += Global_Button_Click;
                }
            }
            catch
            {

                int whl = games.Count;
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
                int whl = games.Count;
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
                int whl = games.Count;
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

        private void Global_Button_Click(object sender, EventArgs e)
        {
            setupButton((Button)sender);
        }

       

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }


        void iconSetup()
        {
            try
            {
                int whl = games.Count;
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
            int whl = games.Count;
            while (whl > 0)
            {
                whl -= 1;
                games[whl].BackColor = bgColor.Color;
            }
          
        }

        void SaveFile()
        {
            Properties.Settings.Default.bgColor = this.BackColor;

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

                int whl = games.Count;
                while (whl > 0)
                {
                    whl -= 1;
                    games[whl].FlatStyle = FlatStyle.Standard;
                }

            }
            if (comboBox1.SelectedIndex == 1)
            {
                int whl = games.Count;
                while (whl > 0)
                {
                    whl -= 1;
                    games[whl].FlatStyle = FlatStyle.Flat;
                }

            }

            Properties.Settings.Default.ButtonStyle = comboBox1.SelectedIndex;
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.Text = vScrollBar1.Value.ToString();
            foreach (Button b in games)
            {
                b.Location = new Point(b.Location.X, vScrollBar1.Value + (150 * (games.Count / 6)));
            }
        }

        public bool IsDivisible(int x, int n)
        {
            return (x % n) == 0;
           
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(offset >= 6){
                 offset = 0;
            }
            vScrollBar1.Maximum = rows * 20;
            Button newButton = new Button();
            newButton.Enabled = true;
            newButton.Visible = true;
            this.Controls.Add(newButton);
            Double d = (games.Count / 6);
            newButton.Location = new Point((30 + (offset * 150)), 150 * (games.Count / 6));
            newButton.Size = new Size(130, 130);
            games.Add(newButton);
            offset++;
            foreach (Button b in games)
            {
                b.Click += Global_Button_Click;
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {

        }
    }
}
