using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CalendarApp.Infra.Interfaces
{
    public interface IPrompt
    {
        void Run(string Path);

        void Run(string Path, string[] Args);

        bool Run(string Path, string NomeArquivo, string[] Args, DateTime HorarioExecucao, DateTime DataExecucao);

        void Run(string Path, Action<object, DataReceivedEventArgs> Output);

        bool IsExists(string Path);

        bool IsFileExists(string Path, string FileName);

    }
}
