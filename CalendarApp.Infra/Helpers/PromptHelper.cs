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
                info.UseShellExecute = true;
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

        public bool Run(string Path, string NomeArquivo, string[] Args, DateTime HorarioExecucao, DateTime DataExecucao)
        {
            bool isExecutado = false;

            try
            {
                if (Tolerancia((double)5, HorarioExecucao) && ComparaData(DataExecucao, DateTime.Now))
                {

                    ProcessStartInfo info = new ProcessStartInfo();
                    info.UseShellExecute = true;
                    info.WorkingDirectory = Path;
                    info.FileName = NomeArquivo;
                    info.Arguments = PercorreArgumentos(Args);

                    Process start = new Process();
                    
                    start.StartInfo = info;
                    start.Start();

                    isExecutado = true;

                }
            }
            catch (Exception)
            {
                //TODO : Colocar um log para capturar os erros
                isExecutado = false; 
            }

            return isExecutado;
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

        private string PercorreArgumentos(string[] Args)
        {
            StringBuilder Argumento = new StringBuilder();

            foreach (var args in Args)
            {
                Argumento.Append(" " + args + " ");
            }

            return Argumento.ToString();

        }

        private bool Tolerancia(double Minuto, DateTime Data)
        {
            if (Data <= DateTime.Now.AddMinutes(Minuto) && Data >= DateTime.Now.AddMinutes(-Minuto))
                return true;
            return false;
        }

        private bool ComparaData(DateTime DataExecucao, DateTime DataVigente)
        {
            return DataExecucao.ToString("dd-MM-yyyy").Equals(DataVigente.ToString("dd-MM-yyyy"));
        }

    }
}
