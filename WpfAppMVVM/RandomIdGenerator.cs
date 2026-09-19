using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppMVVM
{
    public static class RandomIdGenerator
    {
        public static int RandomId()
        {
            Random rnd = new Random();

            return rnd.Next(1, int.MaxValue);
        }
    }
}
