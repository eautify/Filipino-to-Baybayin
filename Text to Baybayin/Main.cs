using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace Text_to_Baybayin
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();


        }


        private void Main_Load(object sender, EventArgs e)
        {
            LoadCustomFont();
        }

        private void LoadCustomFont()
        {
            try
            {
                string customFontFilePath = Path.GetFullPath("../../assets/fonts/Baybayin-2020.otf");

                // Check if the font file exists
                if (File.Exists(customFontFilePath))
                {
                    // Load the custom font file
                    using (var fontStream = new FileStream(customFontFilePath, FileMode.Open))
                    {
                        // Load the font from the font stream
                        var privateFontCollection = new PrivateFontCollection();
                        privateFontCollection.AddFontFile(customFontFilePath);

                        // Use the first font in the collection
                        var customFont = new Font(privateFontCollection.Families[0], 20); // Change the size as needed

                        // Set the font of textBox2 to the custom font
                        textBox2.Font = customFont;
                    }
                }
                else
                {
                    MessageBox.Show("Custom font file not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading custom font: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press
                e.Handled = true;
            }
        }
    }
}
