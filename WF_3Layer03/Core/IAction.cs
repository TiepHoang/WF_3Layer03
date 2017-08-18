﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IAction
    {
        ResultRunCode Run();
        void Save(string path);
    }

}
