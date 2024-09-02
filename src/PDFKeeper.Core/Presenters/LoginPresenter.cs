// ****************************************************************************
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

using PDFKeeper.Core.DataAccess;
using PDFKeeper.Core.DataAccess.Repository;
using PDFKeeper.Core.Services;
using PDFKeeper.Core.ViewModels;
using System;
using System.Collections;

namespace PDFKeeper.Core.Presenters
{
    public class LoginPresenter : PresenterBase<LoginViewModel>
    {
        private readonly IntPtr handle;
        private readonly IMessageBoxService messageBoxService;
        private IDocumentRepository documentRepository;

        /// <summary>
        /// Initializes a new instance of the LoginPresenter class.
        /// </summary>
        /// <param name="handle">The handle of the view.</param>
        /// <param name="messageBoxService">The MessageBoxService instance.</param>
        public LoginPresenter(IntPtr handle, IMessageBoxService messageBoxService)
        {
            this.handle = handle;
            this.messageBoxService = messageBoxService;
            ViewModel = new LoginViewModel();
        }

        public void Login()
        {
            OnApplyPendingChangesRequested();
            OnLongRunningOperationStarted();
            try
            {
                IList list = Enum.GetValues(typeof(DatabaseSession.CompatiblePlatformName));
                for (int i = 0, loopTo = list.Count - 1; i <= loopTo; i++)
                {
                    var platform = list[i];
                    if (platform.ToString().Equals(ViewModel.DbManagementSystem,
                        StringComparison.Ordinal))
                    {
                        DatabaseSession.PlatformName = (
                            DatabaseSession.CompatiblePlatformName)platform;
                    }
                }
                DatabaseSession.UserName = ViewModel.UserName;
                DatabaseSession.Password = ViewModel.Password;
                DatabaseSession.DataSource = ViewModel.DataSource;
                documentRepository = DocumentRepositoryFactory.Instance;
                documentRepository.TestConnection();
                OnViewCloseRequested();
            }
            catch (ArgumentException ex)
            {
                messageBoxService.ShowMessage(handle, ex.Message, true);
                OnViewResetRequested();
            }
            catch (DatabaseException ex)
            {
                messageBoxService.ShowMessage(handle, ex.Message, true);
                try
                {
                    documentRepository.ResetCredential();
                }
                catch (NotSupportedException) { }
                OnViewResetRequested();
            }
            finally
            {
                OnLongRunningOperationFinished();
            }
        }
    }
}
