using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.Models
{
    public class EnumClass
    {
        public enum ChechkHashType
        {
            NoConsensus = 0,
            CorrectHash,
            Conflict,
            UpdateTransaction
        }
    }
}
