using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Text;
using System.Linq;

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
            // First, load the custom font for the textbox
            LoadCustomFont();
            // Next, apply all the visual styles
            ApplyStyling();
        }

        private void ApplyStyling()
        {
            // --- Color Palette ---
            Color backColor = Color.FromArgb(28, 28, 28);      // Very dark gray for the window background
            Color foreColor = Color.FromArgb(241, 241, 241);    // Off-white for text
            Color accentColor = Color.FromArgb(0, 122, 204);   // A vibrant blue for the main title
            Color controlBackColor = Color.FromArgb(45, 45, 48); // Lighter dark gray for text boxes

            // --- Style the Main Window (the Form itself) ---
            this.BackColor = backColor;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Prevents resizing for a cleaner look
            this.MaximizeBox = false;

            // --- Style the Labels ---
            label1.ForeColor = accentColor; // The main title gets the accent color

            label2.ForeColor = foreColor;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            label3.ForeColor = foreColor;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));


            // --- Style the Text Boxes ---
            // Input Filipino Textbox
            textBox1.BackColor = controlBackColor;
            textBox1.ForeColor = foreColor;
            textBox1.BorderStyle = BorderStyle.None; // Key for a modern, flat look

            // Output Baybayin Textbox
            textBox2.BackColor = controlBackColor;
            textBox2.ForeColor = foreColor;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ReadOnly = true; // Makes it feel like a display panel instead of an input field
        }

        private void LoadCustomFont()
        {
            try
            {
                // Using a more reliable path starting from the application's directory
                string customFontFilePath = Path.Combine(Application.StartupPath, "assets", "fonts", "BagwisBaybayin.ttf");
                if (File.Exists(customFontFilePath))
                {
                    var privateFontCollection = new PrivateFontCollection();
                    privateFontCollection.AddFontFile(customFontFilePath);
                    // The font for textBox2 is set here, but we will adjust its color and background in ApplyStyling()
                    var customFont = new Font(privateFontCollection.Families[0], 20);
                    textBox2.Font = customFont;
                }
                else
                {
                    MessageBox.Show("Font file not found! Please check the path: " + customFontFilePath, "Font Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading custom font: " + ex.Message, "Font Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Translate the input text using the new algorithm
            textBox2.Text = TranslateText(textBox1.Text);
        }

        /// <summary>
        /// Applies a specific set of translation rules to an input string.
        /// </summary>
        private string TranslateText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            // Split the input text into words
            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var translatedWords = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower(); // Rule: All input should be lowercase
                string translatedWord = ApplyTranslationRules(word);
                translatedWords.Append(translatedWord);

                // Add a space after each word, except the last one
                if (i < words.Length - 1)
                {
                    translatedWords.Append(" ");
                }
            }
            return translatedWords.ToString();
        }

        /// <summary>
        /// Applies the specific rules to a single word.
        /// </summary>
        private string ApplyTranslationRules(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return "";
            }

            var newWord = new StringBuilder(word);

            // --- Rule 1 (NEW): Replace "ng" with "N" ---
            // This is done first to prevent "ng" from being treated as two consonants.
            newWord.Replace("ng", "N");

            // --- Rule 2: Capitalize the first letter if it's a vowel ---
            if ("aeiou".Contains(newWord[0]))
            {
                newWord[0] = char.ToUpper(newWord[0]);
            }

            // --- Rule 3: Add 'x' between two succeeding consonants ---
            for (int i = newWord.Length - 2; i >= 0; i--)
            {
                // Convert characters to lowercase for the check to ignore capitalization
                bool isCurrentConsonant = !"aeiou".Contains(char.ToLower(newWord[i]));
                bool isNextConsonant = !"aeiou".Contains(char.ToLower(newWord[i + 1]));

                if (isCurrentConsonant && isNextConsonant)
                {
                    newWord.Insert(i + 1, 'x');
                }
            }

            // --- Rule 4: Add 'x' if the last letter is a consonant ---
            if (newWord.Length > 0)
            {
                // Convert the last character to lowercase for the check
                if (!"aeiou".Contains(char.ToLower(newWord[newWord.Length - 1])))
                {
                    newWord.Append('x');
                }
            }

            return newWord.ToString();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Your KeyPress logic is fine.
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}