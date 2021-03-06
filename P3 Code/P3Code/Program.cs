﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3Code
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

            FormLogin loginCheck = new FormLogin();
            Application.Run(loginCheck);
            if (loginCheck.UserAuthed)
            {
                FormProjSelect selectproj = new FormProjSelect();
                Application.Run(selectproj);
                
                if (FakePreferencceRepository.GetPreference(loginCheck.UserN, selectproj.selectedName) == null);
                    FakePreferencceRepository.SetPreference(loginCheck.UserN, selectproj.selectedName, selectproj.Id);
                Application.Run(new FormMain(selectproj.selectedName));
            }
        }
    }
}
