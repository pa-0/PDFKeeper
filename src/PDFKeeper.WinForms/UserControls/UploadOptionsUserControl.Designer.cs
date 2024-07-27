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

namespace PDFKeeper.WinForms.UserControls
{
    partial class UploadOptionsUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadOptionsUserControl));
            this.OcrPdfTextAndImageDataPagesCheckBox = new System.Windows.Forms.CheckBox();
            this.FlagDocumentCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OcrPdfTextAndImageDataPagesCheckBox
            // 
            resources.ApplyResources(this.OcrPdfTextAndImageDataPagesCheckBox, "OcrPdfTextAndImageDataPagesCheckBox");
            this.OcrPdfTextAndImageDataPagesCheckBox.Name = "OcrPdfTextAndImageDataPagesCheckBox";
            this.OcrPdfTextAndImageDataPagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // FlagDocumentCheckBox
            // 
            resources.ApplyResources(this.FlagDocumentCheckBox, "FlagDocumentCheckBox");
            this.FlagDocumentCheckBox.Name = "FlagDocumentCheckBox";
            this.FlagDocumentCheckBox.UseVisualStyleBackColor = true;
            // 
            // UploadOptionsUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OcrPdfTextAndImageDataPagesCheckBox);
            this.Controls.Add(this.FlagDocumentCheckBox);
            this.Name = "UploadOptionsUserControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox OcrPdfTextAndImageDataPagesCheckBox;
        internal System.Windows.Forms.CheckBox FlagDocumentCheckBox;
    }
}
