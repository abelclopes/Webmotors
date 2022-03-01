using System;
using Xunit;

namespace Tests._Util
{
    public static class AssertExtension
    {
        public static void CompareMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem: '{message}'");
            }
        }
    }
}
