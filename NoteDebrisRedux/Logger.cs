﻿
using IPALogger = IPA.Logging.Logger;

namespace NoteDebrisRedux
{
    internal static class Logger
    {
        public static IPALogger Log { get; set; }

		public static int NoteLogCapacity { get; set; }

		
    }
}