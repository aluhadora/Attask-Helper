using System.Diagnostics;

namespace Attask_Helper.Utilities
{
  public static class Command
  {
    public static string Run(string path, string command)
    {
      var cmdProcess = GenerateProcess(path);

      cmdProcess.StandardInput.WriteLine(command);
      cmdProcess.StandardInput.WriteLine("exit");

      string output = cmdProcess.StandardOutput.ReadToEnd();
      cmdProcess.WaitForExit();

      return output;
    }

    private static Process GenerateProcess(string directory)
    {
      var cmdProcess = new Process
      {
        StartInfo =
        {
          FileName = @"C:\Windows\System32\cmd.exe",
          RedirectStandardOutput = true,
          RedirectStandardError = true,
          RedirectStandardInput = true,
          WorkingDirectory = directory,
          UseShellExecute = false,
          CreateNoWindow = true
        },
      };
      cmdProcess.Start();

      return cmdProcess;
    }
  }
}
