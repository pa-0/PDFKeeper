﻿// *****************************************************************************
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
// *****************************************************************************

using PDFKeeper.Core.Commands;
using PDFKeeper.Core.Presenters;
using PDFKeeper.WinForms.Helpers;
using PDFKeeper.WinForms.Views;

namespace PDFKeeper.WinForms.Commands
{
    public class SelectAllCommand : ICommand
    {
        private readonly MainForm form;
        private readonly MainPresenter presenter;

        /// <summary>
        /// Initializes a new instance of the SelectAllCommand class that selects all text in the
        /// text box with focus into the clipboard when executed.
        /// </summary>
        /// <param name="form">The MainForm instance.</param>
        /// <param name="presenter">The MainPresenter instance.</param>
        public SelectAllCommand(MainForm form, MainPresenter presenter)
        {
            this.form = form;
            this.presenter = presenter;
        }

        public void Execute()
        {
            var textBox = TextBoxHelper.GetFocusedTextBox(form);
            textBox.SelectAll();
            TextBoxHelper.SyncSelectedTextWithViewModel(textBox, form, presenter.ViewModel);
            presenter.SetStateForTextBoxSelectedText();
        }
    }
}
