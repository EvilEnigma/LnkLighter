using IWshRuntimeLibrary;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        string entryArt = @"

 .----------------.  .-----------------. .----------------. 
| .--------------. || .--------------. || .--------------. |
| |   _____      | || | ____  _____  | || |  ___  ____   | |
| |  |_   _|     | || ||_   \|_   _| | || | |_  ||_  _|  | |
| |    | |       | || |  |   \ | |   | || |   | |_/ /    | |
| |    | |   _   | || |  | |\ \| |   | || |   |  __'.    | |
| |   _| |__/ |  | || | _| |_\   |_  | || |  _| |  \ \_  | |
| |  |________|  | || ||_____|\____| | || | |____||____| | |
| |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------' 

";
        Console.WriteLine(entryArt);

        if (args.Length != 1)
        {
            Console.WriteLine("Please provide a target IP address.");
            return;
        }

        string target = args[0];

        WshShell shell = new WshShell();

        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut("linktester.lnk");

        shortcut.TargetPath = "cmd.exe";
        shortcut.Arguments = "/c ping " + target;
        shortcut.Description = "Ping a computer";
        shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
        shortcut.IconLocation = "%SystemRoot%\\system32\\ping.exe";
        shortcut.WindowStyle = 7;

        // Set lnk file attribute to hidden
        /*        FileInfo fileInfo = new FileInfo(shortcut.FullName);
                fileInfo.Attributes |= FileAttributes.Hidden;*/
        shortcut.Save();
            Console.WriteLine("linktester.lnk is now created");
    }
}