﻿using System;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.CommandLine.Rendering;

namespace IKVM.Tools.Core.CommandLine
{

    class ParseErrorResult : IInvocationResult
    {

        readonly int? _errorExitCode;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="errorExitCode"></param>
        public ParseErrorResult(int? errorExitCode)
        {
            _errorExitCode = errorExitCode;
        }

        /// <inheritdoc />
        public void Apply(InvocationContext context)
        {
            var terminal = context.Console.GetTerminal();
            terminal.ResetColor();
            terminal.ForegroundColor = ConsoleColor.Red;

            foreach (var error in context.ParseResult.Errors)
                if (error.SymbolResult != null)
                    terminal.Error.WriteLine($"{error.SymbolResult.Symbol}: {error.Message}");
                else
                    terminal.Error.WriteLine(error.Message);

            terminal.ResetColor();

            context.ExitCode = _errorExitCode ?? 1;
        }

    }

}
