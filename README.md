![Capture](https://github.com/samipmainali/SpotGen-Spotify-Account-Generator/assets/32693847/864e00f4-e76e-4d99-8266-ca815f201ed0)

# Spotify Account Generator/Verifier SpotGen

The Spotgen is a C# console application that automates the process of signing up for Spotify and verifying the email.

## Features

- Automated signup for Spotify
- Email verification

## Disclaimer

This application is provided for educational and testing purposes only. The use of this application for any illegal activities or unauthorized access to Spotify or any other services is strictly prohibited. The developer assumes no responsibility for any misuse or damage caused by the use of this application.

## Prerequisites

- Zoho Mail account
- IMAP enabled in Zoho Mail
- Two folders named "Spotify" created in the root directory of your Mail account
- Filters created in Mail provider to move Spotify confirmation emails to the "Spotify" folder

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

## Setting up Mail and IMAP

1. Create a Mail account by visiting any Mail provider and following the signup process.

2. Enable IMAP in your Mail account by going to Settings > Mail Accounts > IMAP Access and toggling the switch to enable IMAP(Setting might be different for different provider).

3. Create folder named "Spotify" in the root directory of your Mail account.

4. Create a filter in Mail to automatically move Spotify confirmation emails to the "Spotify" folder:

 Go to Settings > Filters > New Filter.
 Set the condition type to AND.
 Set the condition to Header contains and enter "Confirm your account".
 Set the condition to From email is and enter "no-reply@spotify.com".
 Set the action to Move to folder and select the "Spotify" folder.
 
6. Once the setup is complete, the application will be able to access the appropriate folders in your Mail account to perform email verification

7.  Below are the instructions for the user to fill in the values in the configuration.JSON file with suitable information:

"Threads": (Numeric value) Set the number of threads you want to use for generating accounts. This determines how many accounts will be created simultaneously. 

"ProxyType": (string) Choose the type of proxy you want to use. Options are "proxyless","http","socks4" and "socks5".

"Total_Account_to_be_generated": (Numeric value) Specify the total number of accounts you want to generate. If you only need one account, keep it as "1".

"Mail_Username": (string) Enter a preferred username for the email account. This will be used as the part before the "@" symbol in the email address. Can be left blank of catch all is enabled in the domain.

"Mail_Domain": (string) Choose the domain for your email address. You can either use a custom domain you own or a free domain service.

"Mail_Imap": (string) Provide the IMAP server address for your chosen email domain. This is required for email verification.

"Mail_Email": (string) The complete email address with the chosen username and domain. This will be used for account verification and communication.

"Mail_Password": (string) Provide the password for the email account. This will be used for account verification and communication.

"Custom_Password": (string) If you want to use a different password for the generated accounts, you can set it here. Otherwise, you can leave it the as it is.

"Is_Domain_with_catchall": (string) Set this to "y" if your email domain supports catch-all emails. Otherwise, set it to "n".

"Enable_Mail_Verifier": (string) If you want to verify the email accounts after generation, set this to "y". Otherwise, set it to "n".

"Client_Token": (string) This is token key used for the account generation process. If you dont know where to get it. Dm me for one.

## Contribution

Contributions are welcome! If you find any bugs or have suggestions for improvement, please feel free to open an issue or submit a pull request. Please make sure to follow the existing coding style and guidelines.

## License

This project is licensed under the [MIT License](LICENSE).
Feel free to copy the entire content and modify it as needed.

## Important

# For now i am working on getting the client token for the mobile device. Might take a while till then join the discord and dm for me the token. 

## Discord

# https://discord.gg/QMUt3vrZXB
