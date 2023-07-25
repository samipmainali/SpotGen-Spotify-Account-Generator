using System;
using System.Threading;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Security;
using MimeKit;


namespace Spotgen.Preparing
{
    internal class foldercreate
    {
        public void VerifyEmail()
        {
            bool connected = false;

            while (!connected)
            {
                try
                {
                    // Connect to the IMAP server
                    using (Imap imap = new Imap())
                    {
                        imap.ConnectSSL(Variables.MailImap);
                        imap.Login(Variables.MailEmail, Variables.MailPassword);

                        // Create the "Spotify" folder in the root directory
                        var spotifyFolder = imap.GetFolder("Spotify");
                        if (!spotifyFolder.Exists)
                            imap.Create("Spotify", true);

                        // Create the filter rule to move messages to the "Spotify" folder
                        var rule = new ImapFilterRule
                        {
                            FromContains = "no-reply@spotify.com",
                            SubjectContains = "Confirm your account"
                        };

                        // Set the system flag to prevent other filters from being applied
                        rule.SystemFlags = MessageFlags.Seen;

                        // Apply the filter to the "Spotify" folder
                        imap.Inbox.AddFilter(spotifyFolder, rule);

                        // Disconnect from the server
                        imap.Disconnect(true);

                        connected = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to IMAP server: {ex.Message}");
                    Console.WriteLine("Retrying after 5 seconds...");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
