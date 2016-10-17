using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071984.Contracts
{
    public interface IInterpreter
    {
        void InterpretCommand(IExecutable command);
    }
}
