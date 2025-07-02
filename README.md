# Text to Baybayin Translator

![Version](https://img.shields.io/badge/version-v1.0.0-blue)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple)

A simple and stylish Windows desktop application that translates Filipino text into a custom Baybayin-inspired script based on a unique set of rules. This project was built using C# and Windows Forms with a modern, dark-mode interface.

## Screenshot

*You should replace the image below with a real screenshot of your application! Use the Windows Snipping Tool (or Shift + Win + S) to capture your app, save it, and upload it to your repository.*

![Application Screenshot](httpsd://i.imgur.com/your-screenshot-url.png)

## Features

- **Live Translation:** See the translation appear instantly as you type.
- **Custom Script Rules:** Implements a unique ruleset for the "Bagwis Baybayin" font, including special handling for consonants and the "ng" digraph.
- **Modern Dark Mode UI:** A clean, professional, and easy-to-use dark theme.
- **Custom Font Integration:** Natively uses the beautiful `BagwisBaybayin.ttf` font for an authentic display.
- **Easy Installation:** Deployed with a ClickOnce installer that handles all dependencies.

## Requirements

- Windows 7, 8, 10, or 11.
- .NET Framework 4.7.2 (The installer will automatically prompt you to install this if it's missing).

## Installation and Usage

1.  Go to the **[Releases Page](https://github.com/YOUR_USERNAME/Text-to-Baybayin-App/releases)**. 
    *(Important: Replace YOUR_USERNAME with your actual GitHub username!)*
2.  Under the latest release, download the `.zip` file (e.g., `Text-to-Baybayin-Installer-v1.0.zip`).
3.  Unzip the downloaded folder to a location on your computer.
4.  Run the **`setup.exe`** file to begin the installation. Follow the on-screen prompts.
5.  Once installed, you can find the "Text to Baybayin" application in your Start Menu.

## The "Bagwis Baybayin" Translation Rules

This application does not use the traditional Baybayin script rules. It uses a custom ruleset designed to work with the `BagwisBaybayin.ttf` font:

1.  **"ng" is Special:** Any occurrence of "ng" is replaced with a capital "N". This is processed first.
    - *Example:* `ngayon` → `Nayon`
2.  **Vowel Capitalization:** The first letter of a word is capitalized if it is any vowel (`a`, `e`, `i`, `o`, `u`).
    - *Example:* `aliw` → `Aliw`
3.  **Consecutive Consonants:** An 'x' is inserted between any two consonants that appear next to each other.
    - *Example:* `banta` → `banxta`
4.  **Final Consonants:** An 'x' is added to the end of any word that ends with a consonant.
    - *Example:* `hagdan` → `hagxdanx`

Putting it all together: `ngayon` → `Nayon` → `Nayonx`.

## Technologies Used

-   **C#** with **Windows Forms (.NET Framework 4.7.2)**
-   **Visual Studio** as the development environment
-   **ClickOnce** for deployment

## License

This project is licensed under the MIT License. See the details below.

<details>
<summary>Click to view MIT License</summary>

MIT License

Copyright (c) 2025 [Your Name]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

</details>

## Acknowledgments

-   Thank you to the creator of the **Bagwis Baybayin** font.