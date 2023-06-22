# Spotify Account Generator/Verifier SpotGen

The Spotgen is a C# console application that automates the process of signing up for Spotify, verifying the email, and changing the password.

## Features

- Automated signup for Spotify
- Email verification
- Password change functionality

## Disclaimer

This application is provided for educational and testing purposes only. The use of this application for any illegal activities or unauthorized access to Spotify or any other services is strictly prohibited. The developer assumes no responsibility for any misuse or damage caused by the use of this application.

## Prerequisites

- Zoho Mail account
- IMAP enabled in Zoho Mail
- Two folders named "Spotify" and "PasswordChanged" created in the root directory of your Zoho Mail account
- Filters created in Zoho Mail to move Spotify confirmation emails to the "Spotify" folder and password change emails to the "PasswordChanged" folder

## Usage

 # Clone the repository: Or Download the .exe from Release. 

git clone https://github.com/your-username/spotify-account-generator.git
Open the project in your preferred C# development environment (e.g., Visual Studio).

Build the project to restore NuGet packages and compile the application.

Before running the application, make sure to edit the config.json file located in the project's root directory.

If the config.json file is not present, run the application once and close it. It will generate the file, and you can then edit it with your own information.
Run the application and follow the on-screen instructions to generate Spotify accounts.

Monitor the console output for the status of each account generation process.

Once the account generation is complete, you can find the generated accounts in the specified output directory.

Use the generated accounts responsibly and in accordance with Spotify's terms of service.

## Setting up Zoho Mail and IMAP

1. Create a Zoho Mail account if you don't have one already.

2. Enable IMAP in your Zoho Mail account. Check the Zoho Mail documentation for instructions on how to enable IMAP.

3. Create two folders named "Spotify" and "PasswordChanged" in the root directory of your Zoho Mail account.

4. Create filters in Zoho Mail to automatically move Spotify confirmation emails and password change emails to the respective folders. Refer to the instructions provided earlier in this README for creating the filters.

5. Once the setup is complete, the application will be able to access the appropriate folders in your Zoho Mail account to perform email verification and password change operation

## Contribution

Contributions are welcome! If you find any bugs or have suggestions for improvement, please feel free to open an issue or submit a pull request. Please make sure to follow the existing coding style and guidelines.

## License

This project is licensed under the [MIT License](LICENSE).
Feel free to copy the entire content and modify it as needed.

## Discord

# https://discord.gg/QMUt3vrZXB
