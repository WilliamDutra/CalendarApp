using CalendarApp.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CalendarApp.Infra.Helpers
{
    public class PromptHelper : IPrompt
    {
        public bool IsExists(string Path)
        {
            try
            {
                return Directory.Exists(Path);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsFileExists(string Path, string FileName)
        {
            try
            {
                return File.Exists($"{Path}{FileName}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Run(string Path)
        {
            try
            {
                if (!IsExists(Path))
                    throw new Exception("O caminho inserido não existe");

                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = false;
                info.FileName = Path;

                Process start = new Process();
                start.StartInfo = info;
                start.Start();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Run(string Path, string[] Args)
        {
            throw new NotImplementedException();
        }

        public void Run(string Path, Action<object, DataReceivedEventArgs> Output)
        {
            try
            {
                
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = false;
                info.FileName = Path;

                Process start = new Process();
                start.StartInfo = info;
                start.OutputDataReceived += (sender, e) => Output(sender, e);

                start.Start();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
