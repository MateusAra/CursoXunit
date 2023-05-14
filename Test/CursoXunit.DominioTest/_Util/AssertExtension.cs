using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoXunit.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void HaveMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
            {
                Assert.True(true);
            }
            else
                Assert.False(true, $"Esperava mensagem '{message}'");
        }
    }
}
