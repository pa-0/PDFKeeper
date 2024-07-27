﻿// ****************************************************************************
// * PDFKeeper -- Open Source PDF Document Management
// * Copyright (C) 2009-2024 Robert F. Frasca
// *
// * This file is part of PDFKeeper.
// *
// * PDFKeeper is free software: you can redistribute it and/or modify it
// * under the terms of the GNU General Public License as published by the
// * Free Software Foundation, either version 3 of the License, or (at your
// * option) any later version.
// *
// * PDFKeeper is distributed in the hope that it will be useful, but WITHOUT
// * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// * FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
// * more details.
// *
// * You should have received a copy of the GNU General Public License along
// * with PDFKeeper. If not, see <https://www.gnu.org/licenses/>.
// ****************************************************************************

using PDFKeeper.Core.Application;
using PDFKeeper.Core.DataAccess;
using PDFKeeper.Core.Extensions;
using PDFKeeper.WinForms.Helpers;
using PDFKeeper.WinForms.Properties;
using PDFKeeper.WinForms.Services;
using PDFKeeper.WinForms.Views;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PDFKeeper.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(
                ExceptionEventHandler.HandleThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(
                ExceptionEventHandler.HandleUnhandledException);
            using (var mutex = new Mutex(true, Application.ProductName))
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    if (!Startup())
                    {
                        using (var form = new MainForm())
                        {
                            Application.Run(form);
                        }
                    }
                    Shutdown();
                    mutex.ReleaseMutex();
                    mutex.Dispose();
                }
            }
        }

        /// <summary>
        /// Application startup actions.
        /// </summary>
        /// <returns>User cancelled? (true or false)</returns>
        static bool Startup()
        {
            var helpFile = new HelpFile();
            var userSettingsHelper = new UserSettingsHelper();
            userSettingsHelper.Upgrade();
            if (UserSettingsHelper.IsFirstUse)
            {
                helpFile.Show("PDFKeeper.html");
            }
            if (Settings.Default.DbManagementSystem.Length.Equals(0))
            {
                if (File.Exists(DatabaseSession.LocalDatabasePath))
                {
                    Settings.Default.DbManagementSystem = 
                        DatabaseSession.CompatiblePlatformName.Sqlite.ToString();
                }
            }
            DatabaseSession.SetMessageBoxService(new MessageBoxService());
            if (!Settings.Default.DbManagementSystem.Equals(
                DatabaseSession.CompatiblePlatformName.Sqlite.ToString(),
                StringComparison.Ordinal))
            {
                // NOTE: Oracle is the only supported RDBMS at this time. To add future systems,
                // add a ComboBox to LoginForm containing the supported Databases and bind it to
                // the DbManagementSystem setting.
                Settings.Default.DbManagementSystem = 
                    DatabaseSession.CompatiblePlatformName.Oracle.ToString();
                using (var form = new LoginForm())
                {
                    if (form.ShowDialog().Equals(DialogResult.Cancel))
                    {
                        return true;
                    }
                }
            }
            else
            {
                DatabaseSession.PlatformName = DatabaseSession.CompatiblePlatformName.Sqlite;
            }
            return false;
        }

        static void Shutdown()
        {
            var applicationDirectory = new ApplicationDirectory();
            applicationDirectory.DeleteUploadDirectoryShortcuts();
            applicationDirectory.GetDirectory(ApplicationDirectory.SpecialName.Cache).Empty();
            applicationDirectory.GetDirectory(ApplicationDirectory.SpecialName.Temp).Empty();
            Settings.Default.Save();
        }
    }
}
