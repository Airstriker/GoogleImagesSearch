// Copyright (c) 2016 Julian Sychowski
// License: For non-commercial use only

using System;
using System.Windows.Forms;

namespace GoogleImagesSearch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GoogleImagesSearchForm());
        }
    }
}
